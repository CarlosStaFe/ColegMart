using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmCtasCtesColeg : Form
    {
        string dgvtipo = string.Empty;
        string dgvestado = string.Empty;
        string dgvitem = string.Empty;
        decimal saldoTot = 0;
        string matriculado = string.Empty;
        string estadoMat = string.Empty;
        string fianza = string.Empty;

        public frmCtasCtesColeg()
        {
            InitializeComponent();
        }

        private void frmCtasCtesColeg_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            txtMatricula.Select();
        }

        //***** PROCEDIMIENTO CUENDO SE PRESIONA F1 EN EL CAMPO MATRICULA *****
        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Consulta();
        }

        //***** PROCEDIMIENTO PARA PROCESO DEL BOTÓN DE COLEGIADO *****
        private void btnCtasCtes_Click(object sender, EventArgs e)
        {
            Consulta();
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE COLEGIADOS *****
        private void Consulta()
        {
            mdlColegiado CtasCtesColeg = new mdlColegiado("btnCtasCtes");
            AddOwnedForm(CtasCtesColeg);
            CtasCtesColeg.ShowDialog();

            int pos1 = txtFechaVence.Text.IndexOf(" ");
            string fecha = txtFechaVence.Text.Substring(0, pos1);

            lblFechaVence.Text = fecha;

            if (Convert.ToDateTime(txtFechaVence.Text) <= DateTime.Now)
            {
                lblFechaVence.ForeColor = Color.Red;
                lblVenceFianza.ForeColor = Color.Red;
            }
            else
            {
                lblFechaVence.ForeColor = Color.Lime;
                lblVenceFianza.ForeColor = Color.Lime;
            }
            CargarDGV();
        }

        //***** PROCEDIMIENTO PARA CARGAR EL DGV DE LAS CTASCTES *****
        private void CargarDGV()
        {
            int matri = Convert.ToInt32(txtMatricula.Text);

            List<CE_CtasCtesColeg> ListaCtaCte = new CN_CtasCtesColeg().ListaCtaCte(matri);

            if (ListaCtaCte.Count > 0)
            {
                foreach (CE_CtasCtesColeg item in ListaCtaCte)
                {
                    dgvCtasCtes.Rows.Add(new object[] { item.id_CtaCte, item.Matricula, item.Fecha, item.Tipo, item.Prefijo, item.Subfijo, item.Item, item.fk_idDebito,
                                                item.Detalle, item.Periodo, item.Debe, item.Pagado, item.Saldo, item.FechaPago, item.Estado, item.Obs,
                                                item.UserRegistro, item.FechaRegistro });
                }
                PintarDGV();
            }
            else
            {
                dgvCtasCtes.Rows.Clear();
                saldoTot = 0;
                txtMatricula.Select();

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

                    fila.Cells["Pjo"].Value = new PonerCeros().Proceso(Convert.ToString(fila.Cells["Pjo"].Value), 4);
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
                        fila.Cells["Pjo"].Value = DBNull.Value;
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
                txtMatricula.Select();
            }
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA EL BOTÓN DE BÚSQUEDA *****
        private void txtMatricula_Leave(object sender, EventArgs e)
        {
            if (txtMatricula.Text == "") txtMatricula.Text = "0";
            Limpiar();
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA ENTER *****
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Limpiar();
                LeerColegiado();
                CargarDGV();
            }
        }

        //***** PROCEDIMIENTO PARA LIMPIAR LOS DATOS *****
        private void Limpiar()
        {
            lblColegiado.Text = "-";
            lblFechaVence.Text = "-";
            txtSaldo.Text = string.Empty;
            dgvCtasCtes.Rows.Clear();
            saldoTot = 0;
            txtMatricula.Select();
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
                matriculado = item.ApelNombres.ToString().Trim();
                estadoMat = item.Estado.ToString().Trim();
                lblColegiado.Text = matriculado + " - Estado: " + estadoMat;
                txtFechaVence.Text = item.FecVenceFianza.ToString();
                int pos1 = txtFechaVence.Text.IndexOf(" ");
                string fecha = txtFechaVence.Text.Substring(0, pos1);
                fianza = fecha;
                lblFechaVence.Text = fecha;

                if (Convert.ToDateTime(txtFechaVence.Text) <= DateTime.Now)
                {
                    lblFechaVence.ForeColor = Color.Red;
                    lblVenceFianza.ForeColor = Color.Red;
                }
                else
                {
                    lblFechaVence.ForeColor = Color.Lime;
                    lblVenceFianza.ForeColor = Color.Lime;
                }
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
            txtMatricula.Text = string.Empty;
            Limpiar();
        }

        //***** PROCEDIMIENTO PARA EL BOTON IMPRIMIR *****
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            mdlRptCtaCteColeg Mostrar = new mdlRptCtaCteColeg();
            Mostrar.matri = Convert.ToInt32(txtMatricula.Text);
            Mostrar.detalle = "Listado de cuenta corriente de " + txtMatricula.Text + " - " + matriculado + " - Estado: " + estadoMat + " - Vto. Fianza: " + fianza;
            Mostrar.user = txtUserRegistro.Text;
            Mostrar.ShowDialog();
            txtMatricula.Text = string.Empty;
            Limpiar();
        }


    }
}
