using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmCtasCtesSoc : Form
    {
        string dgvtipo = string.Empty;
        string dgvestado = string.Empty;
        string dgvitem = string.Empty;
        decimal saldoTot = 0;
        string sociedad = string.Empty;
        string estadoSoc = string.Empty;

        public frmCtasCtesSoc()
        {
            InitializeComponent();
        }

        private void frmCtasCtesSoc_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            txtNumero.Select();
        }

        //***** PROCEDIMIENTO CUENDO SE PRESIONA F1 EN EL CAMPO NUMERO *****
        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Consulta();
        }

        //***** PROCEDIMIENTO PARA PROCESO DEL BOTÓN DE LA SOCIEDAD *****
        private void btnCtasCtes_Click(object sender, EventArgs e)
        {
            Consulta();
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE SOCIEDADES *****
        private void Consulta()
        {
            mdlSociedades CtasCtesSoc = new mdlSociedades("btnCtasCtes");
            AddOwnedForm(CtasCtesSoc);
            CtasCtesSoc.ShowDialog();

            CargarDGV();
        }

        //***** PROCEDIMIENTO PARA CARGAR EL DGV DE LAS CTASCTES *****
        private void CargarDGV()
        {
            int nro = Convert.ToInt32(txtNumero.Text);

            List<CE_CtasCtesSoc> ListaCtaCte = new CN_CtasCtesSoc().ListaCtaCte(nro);

            if (ListaCtaCte.Count > 0)
            {
                foreach (CE_CtasCtesSoc item in ListaCtaCte)
                {
                    dgvCtasCtes.Rows.Add(new object[] { item.id_CtaCte, item.Numero, item.Fecha, item.Tipo, item.Prefijo, item.Subfijo, item.Item, item.fk_idDebito,
                                                item.Detalle, item.Periodo, item.Debe, item.Pagado, item.Saldo, item.FechaPago, item.Estado, item.Obs,
                                                item.UserRegistro, item.FechaRegistro });
                }
                PintarDGV();
            }
            else
            {
                dgvCtasCtes.Rows.Clear();
                saldoTot = 0;
                txtNumero.Select();

                string mensaje = string.Empty;

                mensaje += "NO REGISTRA MOVIMIENTOS EN CUENTA CORRIENTE...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
            }
        }

        //***** PROCEDIMIENTO PARA PINTAR EL DGV DE LAS CUENTAS CORRIENTES *****
        private void PintarDGV()
        {
            if (dgvCtasCtes.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvCtasCtes.Rows)
                {
                    dgvtipo = fila.Cells["Tipo"].Value.ToString();
                    dgvestado = fila.Cells["Estado"].Value.ToString();
                    dgvitem = fila.Cells["Item"].Value.ToString();
                    saldoTot = saldoTot + Convert.ToDecimal(fila.Cells["Saldo"].Value.ToString());

                    fila.Cells["Prjo"].Value = new PonerCeros().Proceso(Convert.ToString(fila.Cells["Prjo"].Value), 4);
                    fila.Cells["Subfijo"].Value = new PonerCeros().Proceso(Convert.ToString(fila.Cells["Subfijo"].Value), 8);

                    if (dgvtipo == "LIQ" && dgvestado == "PENDIENTE" || dgvestado == "LIQUIDADA")
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Orange;
                        fila.Cells["Estado"].Style.ForeColor = Color.Red;
                    }
                    if (dgvtipo == "LIQ" && dgvestado == "PAGADA")
                    {
                        fila.Cells["Estado"].Style.ForeColor = Color.LightGreen;
                    }
                    if (dgvtipo == "LIQ" && dgvestado == "PAGO BANCO")
                    {
                        fila.Cells["Estado"].Style.ForeColor = Color.LightGreen;
                    }
                    if (dgvtipo == "BCO" && dgvestado == "PAGO BANCO")
                    {
                        fila.DefaultCellStyle.ForeColor = Color.LightGreen;
                        fila.Cells["Estado"].Style.ForeColor = Color.Aqua;
                    }
                    if (dgvtipo == "CIP" || dgvtipo == "CIC")
                    {
                        fila.DefaultCellStyle.ForeColor = Color.LightGreen;
                    }
                    if (int.Parse(dgvitem) > 1)
                    {
                        fila.Cells["Fecha"].Value = DBNull.Value;
                        fila.Cells["Tipo"].Value = "";
                        fila.Cells["Prjo"].Value = DBNull.Value;
                        fila.Cells["Subfijo"].Value = DBNull.Value;
                    }
                    if (fila.Cells["FechaPago"].Value.ToString() == "1/1/1900 00:00:00")
                    {
                        fila.Cells["FechaPago"].Value = "";
                    }
                }

                dgvCtasCtes.FirstDisplayedScrollingRowIndex = dgvCtasCtes.RowCount - 1;
                //dgvCtasCtes.Rows[dgvCtasCtes.RowCount - 1].Selected = true; **** ESTO SELECCIONA TODA LA FILA
                dgvCtasCtes.CurrentCell = dgvCtasCtes.Rows[dgvCtasCtes.RowCount - 1].Cells[2];
                txtSaldo.Text = saldoTot.ToString("$##,###,##0.00");
                txtNumero.Select();
            }
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA EL BOTÓN DE BÚSQUEDA *****
        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "") txtNumero.Text = "0";
            Limpiar();
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA ENTER *****
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Limpiar();
                LeerSociedad();
                CargarDGV();
            }
        }

        //***** PROCEDIMIENTO PARA LIMPIAR LOS DATOS *****
        private void Limpiar()
        {
            lblSociedad.Text = "-";
            txtSaldo.Text = string.Empty;
            dgvCtasCtes.Rows.Clear();
            saldoTot = 0;
            txtNumero.Select();
        }

        //***** PROCEDIMIENTO PARA LEER LA SOCIEDAD INGRESADA *****
        private void LeerSociedad()
        {
            string mensaje = string.Empty;
            List<CE_Sociedades> ListaBuscado = new CN_Sociedades().ListaBuscado(txtNumero.Text, out mensaje);

            foreach (CE_Sociedades item in ListaBuscado)
            {
                txtId.Text = Convert.ToString(item.id_Soc);
                txtNumero.Text = Convert.ToString(item.Numero);
                sociedad = item.Nombre.ToString().Trim();
                estadoSoc = item.Estado.ToString().Trim();
                lblSociedad.Text = sociedad + " - Estado: " + estadoSoc;
            }
        }

        //***** PROCEDIMIENTO PARA EL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO PARA EL BOTON LIMPIAR *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumero.Text = string.Empty;
            Limpiar();
        }

        //***** PROCEDIMIENTO PARA EL BOTON IMPRIMIR *****
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            mdlRptCtaCteSoc Mostrar = new mdlRptCtaCteSoc();
            Mostrar.numero = Convert.ToInt32(txtNumero.Text);
            Mostrar.detalle = "Listado de cuenta corriente de " + txtNumero.Text + " - " + sociedad + " - Estado: " + estadoSoc;
            Mostrar.user = txtUserRegistro.Text;
            Mostrar.ShowDialog();
            txtNumero.Text = string.Empty;
            Limpiar();

        }
    }
}
