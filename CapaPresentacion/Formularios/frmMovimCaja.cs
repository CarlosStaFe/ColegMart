using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmMovimCaja : Form
    {
        SoloNumeros validar = new SoloNumeros();

        string respuesta, tipomov, pref, nombre;
        decimal importe, importe1, importe2, importe3, total1, total2, total3;

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
                dgvCaja.Rows.Add(new object[] { item.id_Caja, item.Fecha, item.Tipo, item.Prefijo, item.Subfijo, item.Item,item.Numero, item.Nombre, item.Detalle,
                                                item.Periodo, item.Efectivo, item.Transferencia,item.Tarjeta, item.Estado, item.FechaCierre, item.Obs, item.UserRegistro });
            }

            Colorear();
            Limpiar();

            cboTipo.Select();
        }

        //***** COLOREO LA CELDA SI LA CAJA SEGÚN INGRESO O EGRESO *****
        private void Colorear()
        {
            total1 = 0;
            total2 = 0;
            total3 = 0;

            for (int i = 0; i < dgvCaja.Rows.Count; i++)
            {
                tipomov = dgvCaja.Rows[i].Cells["Tip"].Value.ToString().Trim();
                importe1 = Convert.ToDecimal(dgvCaja.Rows[i].Cells["Efectivo"].Value.ToString().Trim());
                importe2 = Convert.ToDecimal(dgvCaja.Rows[i].Cells["Transf"].Value.ToString().Trim());
                importe3 = Convert.ToDecimal(dgvCaja.Rows[i].Cells["Tarjeta"].Value.ToString().Trim());

                total1 = total1 + importe1;
                total2 = total2 + importe2;
                total3 = total3 + importe3;

                if (tipomov == "INGRESO")
                {
                    dgvCaja.Rows[i].DefaultCellStyle.ForeColor = Color.Lime;
                }
                if (tipomov == "EGRESO")
                {
                    dgvCaja.Rows[i].DefaultCellStyle.ForeColor = Color.Orange;
                }
                if (tipomov == "DEPOSITO")
                {
                    dgvCaja.Rows[i].DefaultCellStyle.ForeColor = Color.Aqua;
                }
            }

            txtEfectivo.Text = Convert.ToString(total1);
            txtTransf.Text = Convert.ToString(total2);
            txtTarjeta.Text = Convert.ToString(total3);
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
                if (cboTipo.Text == "INGRESO")
                {
                    importe = Convert.ToDecimal(txtImporte.Text);
                    pref = "INGR";
                    nombre = "-";
                }
                if (cboTipo.Text == "EGRESO")
                {
                    importe = Convert.ToDecimal(txtImporte.Text) * -1;
                    pref = "EGRE";
                    nombre = "-";
                }
                if (cboTipo.Text == "DEPOSITO")
                {
                    importe = Convert.ToDecimal(txtImporte.Text) * -1;
                    pref = "DEPO";
                    nombre = "BANCO";
                    txtDetalle.Text = txtDeposito.Text;
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
                    Prefijo = pref,
                    Subfijo = "MANUAL",
                    Item = 1,
                    Numero = 1,
                    Nombre = nombre,
                    Detalle = txtDetalle.Text,
                    Periodo = "-",
                    Efectivo = importe1,
                    Transferencia = importe2,
                    Tarjeta = importe3,
                    Estado = "ABIERTA",
                    FechaCierre = Convert.ToDateTime("01-01-1900"),
                    Obs = txtObs.Text,
                    UserRegistro = txtUserRegistro.Text
                };

                //***** SI EL ID DE LA CAJA = 0 REGISTRA, SINO EDITA *****
                int idCaja = new CN_Cajas().Registrar(cE_Cajas, out mensaje);

                if (idCaja != 0)
                {
                    dgvCaja.Rows.Add(new object[] {id_Caja,DateTime.Now.Date,cboTipo.Text,pref,"MANUAL",1,1,nombre,txtDetalle.Text,"-",importe1,importe2,importe3,
                                                  "ABIERTA",Convert.ToDateTime("01-01-1900"),txtObs.Text,txtUserRegistro.Text});
                }

                Colorear();
                Limpiar();
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

        //***** VALIDO EL IMPORTE PARA PASARLO A IMPORTE *****
        private void txtImporte_Leave(object sender, EventArgs e)
        {

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
                cboForma.Text = "EFECTIVO";
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

        //***** PROCEDIMIENTO PARA CERRAR LA CAJA DEL DÍA *****
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            bool valor = new Backup().RealizarCopia();

            if (valor)
            {
                mensaje += "COPIA DE SEGURIDAD REALIZADA CON ÉXITO...!!!";
                frmMsgBox msgb = new frmMsgBox(mensaje, "ok", 1);
                DialogResult drb = msgb.ShowDialog();
            }
            else
            {
                mensaje += "NO SE PUEDO REALIZAR LA COPIA DE SEGURIDAD...VERIFIQUE...!!!";
                frmMsgBox msgb = new frmMsgBox(mensaje, "info", 1);
                DialogResult drb = msgb.ShowDialog();
            }

            if (valor)
            {
                frmPrintCaja Caja = new frmPrintCaja();
                Caja.ShowDialog();
            }
        }

    }
}
