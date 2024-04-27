using CapaEntidad;
using CapaNegocio;
using System;
using CapaPresentacion.Utiles;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmMovimCaja : Form
    {
        SoloNumeros validar = new SoloNumeros();

        string estado, respuesta, fecha, usuario, tipo;
        int senial;
        decimal importe, importe1, importe2, importe3;

        DateTime fechavto;

        public frmMovimCaja()
        {
            InitializeComponent();
        }

        private void frmMovimCaja_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            List<CE_Cajas> Lista = new CN_Cajas().ListaCaja();

            //***** CARGO EL DGV *****
            foreach (CE_Cajas item in Lista)
            {
                dgvCaja.Rows.Add(new object[] { "", item.id_Caja, item.Fecha, item.Tipo, item.Prefijo, item.Subfijo, item.Item,item.Numero, item.Nombre, item.Detalle,
                                                item.Periodo, item.Efectivo, item.Transferencia,item.Tarjeta, item.Estado, item.FechaCierre, item.Obs });
            }

            Colorear();
            Limpiar();

            cboTipo.Select();
        }

        //***** COLOREO LA CELDA SI LA CAJA SEGÚN INGRESO O EGRESO *****
        private void Colorear()
        {
            for (int i = 0; i < dgvCaja.Rows.Count; i++)
            {
                tipo = dgvCaja.Rows[i].Cells["Tipo"].Value.ToString().Trim();

                if (tipo == "INGRESO")
                {
                    dgvCaja.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
                if (tipo == "EGRESO")
                {
                    dgvCaja.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (tipo == "DEPOSITO")
                {
                    dgvCaja.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            txtId.Text = "0";
            cboTipo.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            txtDetalle.Visible = true;
            lblDetalle.Visible = true;
            txtDeposito.Text = string.Empty;
            txtDeposito.Visible = false;
            lblDeposito.Visible = false;
            txtImporte.Text = string.Empty;
            cboForma.Text = string.Empty;
            txtObs.Text = string.Empty;
            btnAgregar.Visible = true;
            importe = 0;
            importe1 = 0;
            importe2 = 0;
            importe3 = 0;

            cboTipo.Select();
        }

        //***** PROCEDIMIENTO PARA SALIR DE LA PANTALLA *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO PARA LIMPIAR LOS DATOS INGRESADOS *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO BOTON GUARDAR *****
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE MOVIMIENTODE LA CAJA...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                if (cboTipo.Text != "INGRESO")
                {
                    importe = Convert.ToDecimal(txtImporte.Text) * -1;
                }
                if (cboForma.Text == "EFECTIVO")
                {
                    importe1 = importe;
                    importe2 = 0;
                    importe3 = 0;
                }
                if (cboForma.Text == "TRANSFERENCIA")
                {
                    importe1 = 0;
                    importe2 = importe;
                    importe3 = 0;
                }
                if (cboForma.Text == "TARJETA")
                {
                    importe1 = 0;
                    importe2 = 0;
                    importe3 = importe;
                }

                CE_Cajas cE_Cajas = new CE_Cajas()
                {
                    id_Caja = Convert.ToInt32(txtId.Text),
                    Fecha = DateTime.Now.Date,
                    Tipo = cboTipo.Text,
                    Prefijo = "INGR.",
                    Subfijo = "MANUAL",
                    Item = 1,
                    Numero = 1,
                    Nombre = "INGRESO MANUAL",
                    Detalle = txtDetalle.Text,
                    Periodo = "-",
                    Efectivo = importe1,
                    Transferencia = importe2,
                    Tarjeta = importe3,
                    Estado = "ABIERTA",
                    FechaCierre = Convert.ToDateTime("01-01-1900"),
                    Obs = txtObs.Text,
                };

                //***** SI EL ID DE LA CAJA = 0 REGISTRA, SINO EDITA *****
                int idCaja = new CN_Cajas().Registrar(cE_Cajas, out mensaje);

                if (idCaja != 0)
                {
                    DataGridViewRow row = dgvCaja.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id_Caja"].Value = txtId.Text;
                    row.Cells["Fecha"].Value = DateTime.Now.Date;
                    row.Cells["Tipo"].Value = cboTipo.Text;
                    row.Cells["Pjo"].Value = "INGR.";
                    row.Cells["Subfijo"].Value = "MANUAL";
                    row.Cells["It"].Value = 1;
                    row.Cells["Numero"].Value = 1;
                    row.Cells["Nombre"].Value = "INGRESO MANUAL";
                    row.Cells["Detalle"].Value = txtDetalle.Text;
                    row.Cells["Pdo"].Value = "-";
                    row.Cells["Efectivo"].Value = importe1;
                    row.Cells["Transf"].Value = importe2;
                    row.Cells["Tarjeta"].Value = importe3;
                    row.Cells["FecCierre"].Value = "";
                    row.Cells["Obs"].Value = txtObs.Text;
                    row.Cells["UserRegistro"].Value = txtUserRegistro.Text;

                    if (row.Cells["FecCierre"].Value.ToString() == "1/1/1900 00:00:00")
                    {
                        row.Cells["FecCierre"].Value = "";
                    }
                    Colorear();
                    Limpiar();
                }
                else
                {
                    mensaje += ". VERIFIQUE...!!!";
                    frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                    msg1.ShowDialog();
                }
            }
        }

        //***** VALIDO QUE SE INGRESE UN NUMERO EN EL DEPÓSITO *****
        private void txtDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** VALIDO QUE SE INGRESE UN NUMERO EN EL IMPORTE *****
        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** PROCEDIMIENTO PARA ACTIVAR DEPÓSITO *****
        private void cboTipo_TextChanged(object sender, EventArgs e)
        {
            if (cboTipo.Text == "DEPOSITO")
            {
                txtDetalle.Text = string.Empty;
                txtDetalle.Visible = false;
                lblDetalle.Visible = false;
                txtDeposito.Text = string.Empty;
                txtDeposito.Visible = true;
                lblDeposito.Visible = true;
                txtDeposito.Select();
            }
            else
            {
                txtDetalle.Text = string.Empty;
                txtDetalle.Visible = true;
                lblDetalle.Visible = true;
                txtDeposito.Text = string.Empty;
                txtDeposito.Visible = false;
                lblDeposito.Visible = false;
                txtDetalle.Select();
            }

        }


    }
}
