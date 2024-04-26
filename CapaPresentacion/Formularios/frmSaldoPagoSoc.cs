using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using CapaPresentacion.Utiles;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmSaldoPagoSoc : Form
    {
        string detalle, dd, mm, yyyy, desde, hasta, fecha;
        string cmdSocie, cmdCtasCtes, cmd;
        int numero, pos1;
        decimal importe;

        public frmSaldoPagoSoc()
        {
            InitializeComponent();
        }

        private void frmSaldoPagoSoc_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA ENTER *****
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LeerSociedad();
            }
        }

        //***** PROCEDIMIENTO CUANDO SE PRESIONA F1 EN EL CAMPO MATRICULA *****
        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Consulta();
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE SOCIEDADES *****
        private void Consulta()
        {
            mdlSociedades SaldoPagoSoc = new mdlSociedades("btnSaldoPago");
            AddOwnedForm(SaldoPagoSoc);
            SaldoPagoSoc.ShowDialog();
        }

        //***** PROCEDIMIENTO PARA LEER LA SOCIEDFAD INGRESADA *****
        private void LeerSociedad()
        {
            string mensaje = string.Empty;
            List<CE_Sociedades> ListaBuscado = new CN_Sociedades().ListaBuscado(txtNumero.Text, out mensaje);

            foreach (CE_Sociedades item in ListaBuscado)
            {
                txtId.Text = Convert.ToString(item.id_Soc);
                txtNumero.Text = Convert.ToString(item.Numero);
                lblNombre.Text = item.Nombre.ToString().Trim();
            }
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            rdbSaldos.Checked = true;
            rdbPagos.Checked = false;
            cboOrden.Text = "MATRICULA";
            cboEstado.Text = "TODOS";
            lblNombre.Text = string.Empty;
            dtpDesde.Text = DateTime.Now.ToString("01/01/1900");
            dtpHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");

            int idSP = new CN_SaldosPagos().Blanquear();

            rdbSaldos.Select();
        }

        //***** SI PRESIONO SALDOS DESACTIVO LA FECHA DESDE *****
        private void rdbSaldos_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            dtpDesde.Text = "1/1/1900";
            dtpHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        //***** SI PRESIONO PAGOS ACTIVO LA FECHA DESDE *****
        private void rdbPagos_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Visible = true;
            dtpHasta.Visible = true;
            dtpDesde.Text = "1/1/1900";
        }

        //***** PROCESO PARA SELECCIONAR LOS DATOS A IMPRIMIR *****
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            fecha = new ProcesarFecha().Proceso(dtpDesde.Text);
            dd = new PonerCeros().Proceso(fecha.Substring(0, 2), 2);
            mm = new PonerCeros().Proceso(fecha.Substring(3, 2), 2);
            yyyy = fecha.Substring(6, 4);
            desde = yyyy + "/" + mm + "/" + dd;

            fecha = new ProcesarFecha().Proceso(dtpHasta.Text);
            dd = new PonerCeros().Proceso(fecha.Substring(0, 2), 2);
            mm = new PonerCeros().Proceso(fecha.Substring(3, 2), 2);
            yyyy = fecha.Substring(6, 4);
            hasta = yyyy + "/" + mm + "/" + dd;

            detalle = "Listado de ";

            cmdSocie = "SELECT * FROM Sociedades ";
            cmdCtasCtes = "SELECT * FROM CtasCtesSoc ";

            if (rdbSaldos.Checked)
            {
                detalle = detalle + "Saldos ";
                cmdCtasCtes = cmdCtasCtes + "WHERE Saldo != 0 ";
            }
            else
            {
                detalle = detalle + "Pagos entre el " + dtpDesde.Text + " y el " + dtpHasta.Text + " ";
                cmdCtasCtes = cmdCtasCtes + "WHERE Fecha BETWEEN '" + desde + "' AND '" + hasta + "' AND Tipo BETWEEN 'BCO' AND 'CIC' ";
            }

            if (cboEstado.Text == "TODOS")
            {
                detalle = detalle + "Estado: " + cboEstado.Text + " - ";
            }
            else
            {
                detalle = detalle + "Estado: " + cboEstado.Text + " - ";
                cmdSocie = cmdSocie + "WHERE Estado = '" + cboEstado.Text + "' ";
            }

            if (txtNumero.Text != "")
            {
                detalle = detalle + "Mat.: " + txtNumero.Text + " - " + lblNombre.Text;
                cmdSocie = cmdSocie + "WHERE Numero = '" + txtNumero.Text + "' ";
            }
            else
            {
                //***** ORDENADOS POR *****
                if (cboOrden.Text == "NOMBRE")
                {
                    detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                    cmdSocie = cmdSocie + "ORDER BY Nombre ";
                }
                else
                {
                    detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                    cmdSocie = cmdSocie + "ORDER BY Numero ";
                }
            }

            //***** GENERO EL ARCHIVO PARA EL LISTADO *****

            ArmarListado();

            //***** IMPRIMO SEGÚN EL TIPO DE LISTADO QUE SE ELIGIÓ *****
            mdlSaldoPago Mostrar = new mdlSaldoPago();
            Mostrar.detalle = detalle;
            Mostrar.user = txtUserRegistro.Text;
            Mostrar.ShowDialog();
            txtNumero.Text = string.Empty;
            Limpiar();
        }

        //***** PROCEDIMIENTO PARA CREAR LA LISTA DE SALDOS O PAGOS DE SOCIEDADES *****
        private void ArmarListado()
        {
            string mensaje = string.Empty;

            List<CE_Sociedades> ListaSocie = new CN_Sociedades().ListaPadron(cmdSocie);

            foreach (CE_Sociedades item1 in ListaSocie)
            {
                numero = item1.Numero;
                cmd = cmdCtasCtes + "AND Numero = '" + numero + "' ";

                List<CE_CtasCtesSoc> Listado = new CN_CtasCtesSoc().ListarSaldoPago(cmd);

                foreach (CE_CtasCtesSoc item2 in Listado)
                {
                    if (rdbSaldos.Checked)
                    {
                        importe = item2.Saldo;
                    }
                    else
                    {
                        importe = item2.Pagado;
                    }

                    CE_SaldosPagos cESaldosPagos = new CE_SaldosPagos()
                    {
                        Numero = item1.Numero,
                        Nombre = item1.Nombre,
                        Telefono = item1.Telefono,
                        Estado = item1.Estado,
                        Fecha = item2.Fecha,
                        Detalle = item2.Detalle,
                        Periodo = item2.Periodo,
                        Debe = 0,
                        Haber = 0,
                        Saldo = importe
                    };

                    int idSP = new CN_SaldosPagos().Registrar(cESaldosPagos, out mensaje);
                }
            }
        }

    }


}

