using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using CapaPresentacion.Utiles;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmSaldoPagoColeg : Form
    {
        string detalle,dd,mm,yyyy,desde,hasta, fecha;
        string cmdColeg, cmdCtasCtes, cmd;
        int matri, pos1;
        decimal importe;

        public frmSaldoPagoColeg()
        {
            InitializeComponent();
        }

        private void frmSaldoPagoColeg_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            CargarCombo();
            Limpiar();
        }

        //***** CARGO EL COMBO DE CONCEPTOS *****
        private void CargarCombo()
        {
            List<CE_Debitos> ListaDebitosBol = new CN_Debitos().ListaDebitoBol();

            cboConcepto.Items.Clear();
            cboConcepto.DataSource = ListaDebitosBol;
            cboConcepto.DisplayMember = "Detalle";
            cboConcepto.ValueMember = "id_Debito";
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO CUENDO SE PRESIONA F1 EN EL CAMPO MATRICULA *****
        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Consulta();
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA ENTER *****
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LeerColegiado();
            }
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE COLEGIADOS *****
        private void Consulta()
        {
            mdlColegiado SaldoPagoColeg = new mdlColegiado("btnSaldoPago");
            AddOwnedForm(SaldoPagoColeg);
            SaldoPagoColeg.ShowDialog();
        }

        //***** PROCEDIMIENTO PARA LEER EL COLEGIADO INGRESADO *****
        private void LeerColegiado()
        {
            string mensaje = string.Empty;
            List<CE_Colegiados> ListaBuscado = new CN_Colegiados().ListaBuscado(txtMatricula.Text, out mensaje);

            foreach (CE_Colegiados item in ListaBuscado)
            {
                txtId.Text = Convert.ToString(item.id_Coleg);
                txtMatricula.Text = Convert.ToString(item.Matricula);
                lblApelNombres.Text = item.ApelNombres.ToString().Trim();
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
            lblApelNombres.Text = string.Empty;
            cboConcepto.Text = "";
            cboConcepto.Enabled = true;
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
            cboConcepto.Enabled = true;
            dtpDesde.Text = "1/1/1900";
            dtpHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        //***** SI PRESIONO PAGOS ACTIVO LA FECHA DESDE *****
        private void rdbPagos_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Visible = true;
            cboConcepto.Enabled = false;
            cboConcepto.Text = "";
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

            cmdColeg = "SELECT * FROM Colegiados ";
            cmdCtasCtes = "SELECT * FROM CtasCtesColeg ";

            if (rdbSaldos.Checked)
            {
                detalle = detalle + "Saldos ";
                cmdCtasCtes = cmdCtasCtes + "WHERE Saldo != 0 ";
                if (cboConcepto.Text != "")
                {
                    cmdCtasCtes = cmdCtasCtes + "AND Detalle = '" + cboConcepto.Text + "' ";
                }
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
                cmdColeg = cmdColeg + "WHERE Estado = '" + cboEstado.Text + "' ";
            }

            if (txtMatricula.Text != "")
            {
                detalle = detalle + "Mat.: " + txtMatricula.Text + " - " + lblApelNombres.Text;
                cmdColeg = cmdColeg + "WHERE Matricula = '" + txtMatricula.Text + "' ";
            }
            else
            {
                //***** ORDENADOS POR *****
                if (cboOrden.Text == "APELLIDO")
                {
                    detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                    cmdColeg = cmdColeg + "ORDER BY ApelNombres ";
                }
                else
                {
                    detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                    cmdColeg = cmdColeg + "ORDER BY Matricula ";
                }
            }

            //***** GENERO EL ARCHIVO PARA EL LISTADO *****

            ArmarListado();

            //***** IMPRIMO SEGÚN EL TIPO DE LISTADO QUE SE ELIGIÓ *****
            mdlSaldoPago Mostrar = new mdlSaldoPago();
            Mostrar.detalle = detalle;
            Mostrar.user = txtUserRegistro.Text;
            Mostrar.ShowDialog();
            txtMatricula.Text = string.Empty;
            Limpiar();

        }

        //***** PROCEDIMIENTO PARA CREAR LA LISTA DE SALDOS O PAGOS DE COLEGIADOS *****
        private void ArmarListado()
        {

            string mensaje = string.Empty;

            List<CE_Colegiados> ListaColeg = new CN_Colegiados().ListaPadron(cmdColeg);

            foreach (CE_Colegiados item1 in ListaColeg)
            {
                matri = item1.Matricula;
                cmd = cmdCtasCtes + "AND Matricula = '" + matri + "' ";

                List<CE_CtasCtesColeg> Listado = new CN_CtasCtesColeg().ListarSaldoPago(cmd);

                foreach (CE_CtasCtesColeg item2 in Listado)
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
                        Numero = item1.Matricula,
                        Nombre = item1.ApelNombres,
                        Telefono = item1.FijoParti,
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
