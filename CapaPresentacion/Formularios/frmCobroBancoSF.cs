using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmCobroBancoSF : Form
    {
        string nombre, control, detalle, obs, nrolote, fechalote, transaccion, operacion, matricula, tipo, periodo;
        string importe, banco, sucursal, codpostal, nrocheque, cuenta, plazo, codbarra, fechapago, dd, mm, yyyy;
        string vencto, modopago, formapago;
        int contlineas, contreg, total;
        decimal debe, haber, saldo;

        public frmCobroBancoSF()
        {
            InitializeComponent();
            txtUserRegistro.Text = CE_UserLogin.Usuario;
        }

        //***** PROCEDIMIENTO DEL BOTON DE BÚSQUEDA DEL ARCHIVO *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            string buscar = "PathBancoSF";
            string ruta = new LeerConfig().Proceso(buscar);
            file.DefaultExt = "Archivos Cobro (*.*)|*.*";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.Title = "SELECCIONAR EL ARCHIVO DE COBRO BANCO SANTA FE";

            if (file.ShowDialog() == DialogResult.OK)
            {
                btnProcesar.Enabled = true;
                nombre = file.FileName.ToString();
                nombre = Path.GetFileName(nombre);
                txtArchivo.Text = nombre;
            }
        }

        //***** PROCEDIMIENTO PARA PROCESAR EL ARCHIVO SELECCIONADO *****
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string[] lineas = File.ReadAllLines(nombre);

            contlineas = 0;
            contreg = 0;
            total = 0;
            control = "";

            foreach (string renglon in lineas)
            {
                debe = 0;
                haber = 0;
                saldo = 0;
                detalle = "";
                obs = "";
                contlineas = contlineas + 1;

                if (contlineas == 1)
                {
                    nrolote = renglon.Substring(26, 5);
                    fechalote = renglon.Substring(18, 8);
                    LeerLote();

                    if (control == "noOK") goto finalizar;
                }

                if (renglon.Substring(1,5) == "DATOS")
                {
                    contreg = contreg + 1;
                    transaccion = new PonerCeros().Proceso(renglon.Substring(41, 8),8);

                    if (renglon.Substring(49, 2) == "A3") operacion = "efectivo";
                    if (renglon.Substring(49, 2) == "A2") operacion = "cheque v.impuestos";
                    if (renglon.Substring(49, 2) == "A5") operacion = "cheque común";

                    matricula = renglon.Substring(65, 5);
                    tipo = renglon.Substring(70, 2);
                    periodo = renglon.Substring(76,2) + "-" + renglon.Substring(72, 4);
                    importe = renglon.Substring(78, 11);
                    haber = Convert.ToInt32(importe) / 100;
                    total = total + (Convert.ToInt32(importe) / 100);
                    banco = renglon.Substring(136, 3);
                    sucursal = renglon.Substring(139, 3);
                    codpostal = renglon.Substring(142, 4);
                    nrocheque = renglon.Substring(146, 8);
                    cuenta = renglon.Substring(154, 8);
                    plazo = renglon.Substring(162, 3);
                    codbarra = renglon.Substring(165, 60);
                    fechapago = "20" + renglon.Substring(225, 6);
                    dd = renglon.Substring(194, 2);
                    mm = renglon.Substring(196, 2);
                    yyyy = "20" + renglon.Substring(198, 2);
                    vencto = yyyy + "-" + mm + "-" + dd;

                    modopago = "otros";
                    if (renglon.Substring(231, 1) == "1") modopago = "cheque presentado";
                    if (renglon.Substring(231, 1) == "2") modopago = "cheque conformado";
                    if (renglon.Substring(231, 1) == "3") modopago = "cheque rechazado";

                    if (renglon.Substring(248, 2) == "00") formapago = "efectivo";
                    if (renglon.Substring(248, 2) == "90") formapago = "débito";

                    detalle = "PAGO BANCO PERÍODO " + periodo;
                    obs = "Transacción: " + transaccion + " Período: " + periodo + " Forma: " + formapago;

                    GrabarPago();
                }

                if (renglon.Substring(1, 7) == "TRAILER")
                {
                    if (Convert.ToInt32(renglon.Substring(8, 8)) != contreg)
                    {
                        string detmsg = string.Empty;

                        detmsg += "CANTIDAD DE REGISTROS DIFERENTES... VERIFIQUE...!!!";
                        frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                        _ = msje.ShowDialog();
                    }

                    if (Convert.ToInt32(renglon.Substring(16, 13)) / 100 != total)
                    {
                        string detmsg = string.Empty;

                        detmsg += "IMPORTE DE CUPONES DIFERENTES... VERIFIQUE...!!!";
                        frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                        _ = msje.ShowDialog();
                    }

                    if (contreg > 0)
                    {
                        GrabarLote();
                        string detmsg = string.Empty;

                        detmsg += "CANTIDAD DE REGISTROS: " + Convert.ToString(contreg) + " * LOTE NRO.: " + Convert.ToString(nrolote) + ".";
                        frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                        _ = msje.ShowDialog();
                    }
                    else
                    {
                        GrabarLote();
                        string detmsg = string.Empty;

                        detmsg += "LOTE SIN REGISTROS...!!!";
                        frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                        _ = msje.ShowDialog();
                    }
                }
            }

            string mensaje = string.Empty;

            mensaje += "PROCESO TERMINADO...!!!";
            frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
            DialogResult dialogo = msg.ShowDialog();

        finalizar:;
        }

        //***** PROCEDIMIENTO PARA LEER SI EL LOTE YA FUE PROCESDO *****
        private void LeerLote()
        {
            List<CE_LoteBanco> BuscaLote = new CN_LoteBanco().BuscaLote(Convert.ToInt32(nrolote));

            foreach (CE_LoteBanco linea in BuscaLote)
            {
                if (Convert.ToInt32(nrolote) == linea.NroLote)
                {
                    control = "noOK";

                    string detmsg = string.Empty;

                    detmsg += "LOTE YA PROCESADO...!!! Lote: " + nrolote + " " ;
                    frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                    _ = msje.ShowDialog();
                }
            }
        }

        //***** PROCEDIMIENTO PARA GRABAR EL LOTE PROCESADO *****
        private void GrabarPago()
        {
            string mensaje = string.Empty;

            int cantidad = new CN_CtasCtesColeg().BuscaPago(Convert.ToInt32(matricula), periodo); //***** BUSCA SI FUE PAGADA

            if (cantidad == 0)
            {
                CE_CtasCtesColeg cE_CtasCtesColeg = new CE_CtasCtesColeg()
                {
                    id_CtaCte = 0,
                    Matricula = Convert.ToInt32(matricula),
                    Fecha = Convert.ToDateTime(fechapago),
                    Tipo = "BCO",
                    Prefijo = "0000",
                    Subfijo = transaccion,
                    Item = 1,
                    fk_idDebito = 109,
                    Detalle = "PAGO BANCO PERÍODO",
                    Periodo = periodo,
                    Debe = 0,
                    Pagado = Convert.ToDecimal(importe),
                    FechaPago = Convert.ToDateTime(fechapago),
                    Saldo = 0,
                    Estado = "PAGO BANCO",
                    Obs = "Transacción: " + transaccion + " - Período: " + periodo + " - Forma: " + operacion,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                int idCtaCte = new CN_CtasCtesColeg().Registrar(cE_CtasCtesColeg, out mensaje);

                GrabarCtaCte();
                GrabarCaja();
            }
            else
            {
                GrabarRepetido();

                string detmsg = string.Empty;

                detmsg += "PERÍODO REPETIDO, YA PAGADO ANTERIORMENTE...!!! Matrícula: " + matricula + " Período: " + periodo;
                frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                _ = msje.ShowDialog();

            }
        }

        //***** PROCEDIMIENTO PARA GRABAR EL LOTE PROCESADO *****
        private void GrabarCtaCte()
        {

        }

        //***** PROCEDIMIENTO PARA GRABAR EL LOTE PROCESADO *****
        private void GrabarCaja()
        {

        }

        //***** PROCEDIMIENTO PARA GRABAR EL LOTE PROCESADO *****
        private void GrabarLote()
        {

        }

        //***** PROCEDIMIENTO PARA GRABAR LOS MOVIMIENTOS REPETIDOS *****
        private void GrabarRepetido()
        {

        }
    }
}
