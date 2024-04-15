using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmCargarEstratos : Form
    {
        string nombre, control, causal, detalle, referencia;
        string debito, credito, importe, fecha, dd, mm, yyyy;
        int contlineas, pos1, pos2, pos3, pos4, pos5, signo;
        decimal debe, haber;
        char[] ToTrim = { ',', '.' };

        public frmCargarEstratos()
        {
            InitializeComponent();
            CargoCboBanco();
            txtUserRegistro.Text = CE_UserLogin.Usuario;
        }

        //***** CARGO EL COMBO DE BANCOS *****
        private void CargoCboBanco()
        {
            List<CE_Bancos> ListaBanco = new CN_Bancos().ListaBancos();

            cboBancos.Items.Clear();
            cboBancos.DataSource = ListaBanco;
            cboBancos.DisplayMember = "Nombre";
            cboBancos.ValueMember = "id_Bco";
        }

        //***** PROCEDIMIENTO DEL BOTON DE BÚSQUEDA DEL ARCHIVO *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            string buscar = "PathEstratos";
            string ruta = new LeerConfig().Proceso(buscar);
            file.DefaultExt = "Archivos Estratos (*.txt)|*.txt";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.Title = "SELECCIONAR EL ARCHIVO DE ESTRATO DE BANCO";

            if (file.ShowDialog() == DialogResult.OK)
            {
                btnProcesar.Enabled = true;
                nombre = file.FileName.ToString();
                //nombre = Path.GetFileName(nombre);
                txtArchivo.Text = nombre;
            }
        }

        //***** PROCEDIMIENTO PARA SALIR DE LA PANTALLA *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        //***** PROCEDIMIENTO PARA PROCESAR EL ARCHIVO SELECCIONADO *****
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cboBancos.Text == "NUEVO BANCO DE SANTA FE")
            {
                ProcesarSF();
            }

            if (cboBancos.Text == "BANCO MACRO")
            {
                ProcesarMC();
            }
        }

        //***** PROCEDIMIENTO PARA PROCESAR EL BANCO DE SANTA FE *****
        private void ProcesarSF()
        {
            string[] lineas = File.ReadAllLines(nombre);

            contlineas = 0;
            control = "";

            foreach (string renglon in lineas)
            {
                debe = 0;
                haber = 0;
                detalle = "";
                contlineas = contlineas + 1;

                fecha = renglon.Substring(11, 10);
                dd = renglon.Substring(11, 2);
                mm = renglon.Substring(14, 2);
                yyyy = renglon.Substring(17, 4);
                referencia = renglon.Substring(23, 8);
                detalle = renglon.Substring(32, 30);
                debito = renglon.Substring(67, 20).Replace(".", "");
                if (debito.Trim() == "") debito = "0,00";
                debe = Convert.ToDecimal(debito);
                credito = renglon.Substring(89, 20).Replace(".", "");
                if (credito.Trim() == "") debito = "0,00";
                haber = Convert.ToDecimal(credito);

                GrabarEstrato();

            }

            if (contlineas > 0)
            {
                string detmsg = string.Empty;

                detmsg += "CANTIDAD DE REGISTROS: " + Convert.ToString(contlineas) + ".";
                frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                _ = msje.ShowDialog();
            }
            else
            {
                string detmsg = string.Empty;

                detmsg += "LOTE SIN REGISTROS...!!!";
                frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                _ = msje.ShowDialog();
            }

            string mensaje = string.Empty;

            mensaje += "PROCESO TERMINADO...!!!";
            frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
            DialogResult dialogo = msg.ShowDialog();
        }

        //***** PROCEDIMIENTO PARA PROCESAR EL BANCO MACRO *****
        private void ProcesarMC()
        {
            string[] lineas = File.ReadAllLines(nombre);

            contlineas = 0;
            control = "";

            foreach (string renglon in lineas)
            {
                debe = 0;
                haber = 0;
                detalle = "";
                contlineas = contlineas + 1;

                fecha = renglon.Substring(0, 10);
                dd = renglon.Substring(0, 2);
                mm = renglon.Substring(3, 2);
                yyyy = renglon.Substring(6, 4);

                pos1 = renglon.IndexOf(" ");
                pos2 = renglon.IndexOf(" ", pos1 + 1);
                pos3 = renglon.IndexOf(" ", pos2 + 1);
                pos4 = renglon.IndexOf("$", pos3 + 1);
                pos5 = renglon.IndexOf("$", pos4 + 1);
                referencia = renglon.Substring(pos1 + 1, (pos2 - 1) - pos1);
                causal = renglon.Substring(pos2 + 1, (pos3 - 1) - pos2);
                detalle = renglon.Substring(pos3 + 1, (pos4 - 1) - pos3);
                importe = renglon.Substring(pos4 + 1, (pos5 - 1) - pos4).Replace(".", "");
                signo = importe.IndexOf("-");

                if (signo == 1) debe = (Convert.ToDecimal(importe)) * -1;
                if (signo == -1) haber = Convert.ToDecimal(importe);

                GrabarEstrato();

            }

            if (contlineas > 0)
            {
                string detmsg = string.Empty;

                detmsg += "CANTIDAD DE REGISTROS: " + Convert.ToString(contlineas) + ".";
                frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                _ = msje.ShowDialog();
            }
            else
            {
                string detmsg = string.Empty;

                detmsg += "LOTE SIN REGISTROS...!!!";
                frmMsgBox msje = new frmMsgBox(detmsg, "info", 1);
                _ = msje.ShowDialog();
            }

            string mensaje = string.Empty;

            mensaje += "PROCESO TERMINADO...!!!";
            frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
            DialogResult dialogo = msg.ShowDialog();
        }

        //***** PROCEDIMIENTO PARA GRABAR EL ESTRATO PROCESADO *****
        private void GrabarEstrato()
        {
            string mensaje = string.Empty;

            CE_Estratos cE_Estratos = new CE_Estratos()
            {
                NroBanco = Convert.ToInt32(cboBancos.ValueMember),
                Fecha = Convert.ToDateTime(fecha),
                Referencia = referencia,
                Causal = causal,
                Concepto = detalle,
                Debito = debe,
                Credito = haber,
                FechaConci = Convert.ToDateTime("01/01/1900"),
                Titular = 0,
                NroCic = 0,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idEstrato = new CN_Estratos().Registrar(cE_Estratos, out mensaje);
            
        }
    }
}
