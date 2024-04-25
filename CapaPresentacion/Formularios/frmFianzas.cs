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
    public partial class frmFianzas : Form
    {
        SoloNumeros validar = new SoloNumeros();

        string estado, respuesta, fecha, usuario;
        int senial;
        DateTime fechavto;

        public frmFianzas()
        {
            InitializeComponent();
        }

        private void frmFianzas_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Fianzas> Lista = new CN_Fianzas().ListaFianza();

            //***** CARGO EL DGV *****
            foreach (CE_Fianzas item in Lista)
            {
                dgvFianzas.Rows.Add(new object[] { "", item.id_Fza, item.Matricula, item.ApelNomMatri, item.TelMatri, item.FecPagoFza, item.UserFecPagoFza,
                                                item.FecFirmaMat, item.UserFirmaMat, item.FecFirmaFiador, item.UserFirmaFiador, item.FecVtoFianza, item.EstadoFza,
                                                item.NroDocFiador, item.ApelNomFiador, item.CalleFiador, item.TelFiador });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvFianzas.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            Limpiar();

            cboBusqueda.Select();
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvFianzas.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvFianzas.Rows[i].Cells["FecVtoFianza"].Value);
                if (dateFecha.Date <= DateTime.Now.Date)
                {
                    dgvFianzas.Rows[i].Cells["FecVtoFianza"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvFianzas.Rows[i].Cells["FecVtoFianza"].Style.ForeColor = Color.Lime;
                }

                estado = dgvFianzas.Rows[i].Cells["EstadoFza"].Value.ToString().Trim();
                if (estado == "INCOMPLETA")
                {
                    dgvFianzas.Rows[i].Cells["EstadoFza"].Style.ForeColor = Color.Yellow;
                }
                else
                {
                    dgvFianzas.Rows[i].Cells["EstadoFza"].Style.ForeColor = Color.Lime;
                }

                if (dgvFianzas.Rows[i].Cells["FecFirmaMat"].Value.ToString() == "1/1/1900 00:00:00")
                {
                    dgvFianzas.Rows[i].Cells["FecFirmaMat"].Value = "";
                }

                if (dgvFianzas.Rows[i].Cells["FecFirmaFiador"].Value.ToString() == "1/1/1900 00:00:00")
                {
                    dgvFianzas.Rows[i].Cells["FecFirmaFiador"].Value = "";
                }

                if (dgvFianzas.Rows[i].Cells["FecVtoFianza"].Value.ToString() == "1/1/1900 00:00:00")
                {
                    dgvFianzas.Rows[i].Cells["FecVtoFianza"].Value = "";
                }

            }
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            txtId.Text = "0";
            txtMatricula.Text = "";
            lblNombre.Text = "-";
            lblEstadoFianza.Text = "-";
            txtDocFiador.Text = string.Empty;
            txtNombreFiador.Text = string.Empty;
            txtCalleFiador.Text = string.Empty;
            txtTelFiador.Text = string.Empty;
            dtpFecFirmaMat.Format = DateTimePickerFormat.Custom;
            dtpFecFirmaMat.CustomFormat = " ";
            dtpFecFirmaMat.Enabled = false;
            dtpFecFirmaFiador.Format = DateTimePickerFormat.Custom;
            dtpFecFirmaFiador.CustomFormat = " ";
            dtpFecFirmaFiador.Enabled = false;
            lblEstadoFianza.ForeColor = Color.Lime;
            lblEstado.ForeColor = Color.Lime;

            cboBusqueda.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvFianzas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //***** MUEVO LO SELECCIONADO DEL DGV A LOS CAMPOS PARA MODIFICAR *****
        private void dgvFianzas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFianzas.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvFianzas.Rows[indice].Cells["id_Fza"].Value.ToString();
                    txtMatricula.Text = dgvFianzas.Rows[indice].Cells["Mat"].Value.ToString();
                    lblNombre.Text = dgvFianzas.Rows[indice].Cells["Mat"].Value.ToString();
                    txtVencimiento.Text = dgvFianzas.Rows[indice].Cells["FecVtoFianza"].Value.ToString();
                    lblNombre.Text = lblNombre.Text + " - " + dgvFianzas.Rows[indice].Cells["Apellido"].Value.ToString().Trim();
                    lblNombre.Text = lblNombre.Text + " - Tel.: " + dgvFianzas.Rows[indice].Cells["Telefono"].Value.ToString();

                    fecha = dgvFianzas.Rows[indice].Cells["FecFirmaMat"].Value.ToString();
                    if (fecha == "")
                    {
                        dtpFecFirmaMat.Format = DateTimePickerFormat.Custom;
                        dtpFecFirmaMat.CustomFormat = " ";
                        dtpFecFirmaMat.Enabled = true;
                    }
                    else
                    {
                        dtpFecFirmaMat.CustomFormat = "dd/MM/yyyy";
                        dtpFecFirmaMat.Value = Convert.ToDateTime(dgvFianzas.Rows[indice].Cells["FecFirmaMat"].Value.ToString());
                        dtpFecFirmaMat.Enabled = false;
                    }

                    txtUserFirmaMat.Text = dgvFianzas.Rows[indice].Cells["UserFirmaMat"].Value.ToString();

                    fecha = dgvFianzas.Rows[indice].Cells["FecFirmaFiador"].Value.ToString();
                    if (fecha == "")
                    {
                        dtpFecFirmaFiador.Format = DateTimePickerFormat.Custom;
                        dtpFecFirmaFiador.CustomFormat = " ";
                        dtpFecFirmaFiador.Enabled = true;
                    }
                    else
                    {
                        dtpFecFirmaFiador.CustomFormat = "dd/MM/yyyy";
                        dtpFecFirmaFiador.Value = Convert.ToDateTime(dgvFianzas.Rows[indice].Cells["FecFirmaFiador"].Value.ToString());
                        dtpFecFirmaFiador.Enabled = false;
                    }

                    txtUserFirmaFiador.Text = dgvFianzas.Rows[indice].Cells["UserFirmaFiador"].Value.ToString();

                    txtDocFiador.Text = dgvFianzas.Rows[indice].Cells["NroDocFiador"].Value.ToString();
                    txtNombreFiador.Text = dgvFianzas.Rows[indice].Cells["ApelFiador"].Value.ToString();
                    txtCalleFiador.Text = dgvFianzas.Rows[indice].Cells["CalleFiador"].Value.ToString();
                    txtTelFiador.Text = dgvFianzas.Rows[indice].Cells["TelFiador"].Value.ToString();
                    lblEstadoFianza.Text = dgvFianzas.Rows[indice].Cells["EstadoFza"].Value.ToString();

                    //***** COLOREO LA FIANZA SEGÚN LA FECHA *****
                    if (lblEstadoFianza.Text == "INCOMPLETA")
                    {
                        lblEstado.ForeColor = Color.Red;
                        lblEstadoFianza.ForeColor = Color.Red;
                        dtpFecFirmaMat.Enabled = true;
                        dtpFecFirmaFiador.Enabled = true;
                    }
                    else
                    {
                        lblEstado.ForeColor = Color.Lime;
                        lblEstadoFianza.ForeColor = Color.Lime;
                    }
                }
            }
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTOS DATOS DE LA FIANZA...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CalcularVto();

                CE_Fianzas cE_Fianzas = new CE_Fianzas()
                {
                    id_Fza = Convert.ToInt32(txtId.Text),
                    FecFirmaMat = dtpFecFirmaMat.Value,
                    UserFirmaMat = txtUserFirmaMat.Text,
                    FecFirmaFiador = dtpFecFirmaFiador.Value,
                    UserFirmaFiador = txtUserFirmaFiador.Text,
                    FecVtoFianza = fechavto,
                    NroDocFiador = txtDocFiador.Text,
                    ApelNomFiador = txtNombreFiador.Text,
                    CalleFiador = txtCalleFiador.Text,
                    TelFiador = txtTelFiador.Text,
                    EstadoFza = estado,
                    Obs = "",
                };

                //***** SI EL ID DE LA FIANZA = 0 REGISTRA, SINO EDITA *****
                bool resultado = new CN_Fianzas().Editar(cE_Fianzas, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvFianzas.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id_Fza"].Value = txtId.Text;
                    row.Cells["FecFirmaMat"].Value = dtpFecFirmaMat.Text;
                    row.Cells["UserFirmaMat"].Value = txtUserFirmaMat.Text;
                    row.Cells["FecFirmaFiador"].Value = dtpFecFirmaFiador.Value;
                    row.Cells["UserFirmaFiador"].Value = txtUserFirmaFiador.Text;
                    row.Cells["FecVtoFianza"].Value = fechavto;
                    row.Cells["NroDocFiador"].Value = txtDocFiador.Text;
                    row.Cells["ApelFiador"].Value = txtNombreFiador.Text;
                    row.Cells["CalleFiador"].Value = txtCalleFiador.Text;
                    row.Cells["TelFiador"].Value = txtTelFiador.Text;
                    row.Cells["EstadoFza"].Value = estado;

                    if (estado == "COMPLETA")
                    {
                        row.Cells["FecVtoFianza"].Style.ForeColor = Color.Lime;
                        row.Cells["EstadoFza"].Style.ForeColor = Color.Lime;
                    }

                    if (txtUserFirmaMat.Text == "")
                    {
                        row.Cells["FecFirmaMat"].Value = "";
                    }

                    if (txtUserFirmaFiador.Text == "")
                    {
                        row.Cells["FecFirmaFiador"].Value = "";
                    }

                    if (estado != "COMPLETA")
                    {
                        row.Cells["FecVtoFianza"].Value = "";
                    }

                    if (row.Cells["FecFirmaMat"].Value.ToString() == "1/1/1900 00:00:00")
                    {
                        row.Cells["FecFirmaMat"].Value = "";
                    }

                    if (row.Cells["FecFirmaFiador"].Value.ToString() == "1/1/1900 00:00:00")
                    {
                        row.Cells["FecFirmaFiador"].Value = "";
                    }

                    if (row.Cells["FecVtoFianza"].Value.ToString() == "1/1/1900 00:00:00")
                    {
                        row.Cells["FecVtoFianza"].Value = "";
                    }

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

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvFianzas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFianzas.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvFianzas.Rows)
            {
                row.Visible = true;
            }
        }

        //***** PROCEDIMIENTO DEL BOTON ELIMINAR LOS DATOS *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA ELIMINAR ESTOS DATOS DE LA FIANZA...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Fianzas cEFianzas = new CE_Fianzas()
                {
                    id_Fza = Convert.ToInt32(txtId.Text),
                };

                bool resultado = new CN_Fianzas().Eliminar(cEFianzas, out mensaje);

                if (resultado)
                {
                    dgvFianzas.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** VALIDO QUE SE INGRESE UN NUMERO EN EL DOCUMENTO *****
        private void txtDocFiador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** PROCEDIMIENTO DEL INGRESO DE LA FIRMA DEL MATRICULADO *****
        private void dtpFecFirmaMat_ValueChanged(object sender, EventArgs e)
        {
            dtpFecFirmaMat.Format = DateTimePickerFormat.Custom;
            dtpFecFirmaMat.CustomFormat = "dd/MM/yyyy";

            DateTime dateFecha = Convert.ToDateTime(dtpFecFirmaMat.Value);

            if (dateFecha.Date > DateTime.Now.Date)
            {
                string mensaje = string.Empty;

                mensaje += "LA FECHA ES MAYOR A LA ACTUAL, VERIFIQUE...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();
                dtpFecFirmaMat.Format = DateTimePickerFormat.Custom;
                dtpFecFirmaMat.CustomFormat = " ";
                dtpFecFirmaMat.Select();
            }
        }

        //***** PROCEDIMIENTO DEL INGRESO DE LA FIRMA DEL FIADOR *****
        private void dtpFecFirmaFiador_ValueChanged(object sender, EventArgs e)
        {
            dtpFecFirmaFiador.Format = DateTimePickerFormat.Custom;
            dtpFecFirmaFiador.CustomFormat = "dd/MM/yyyy";

            DateTime dateFecha = Convert.ToDateTime(dtpFecFirmaFiador.Value);

            if (dateFecha.Date > DateTime.Now.Date)
            {
                string mensaje = string.Empty;

                mensaje += "LA FECHA ES MAYOR A LA ACTUAL, VERIFIQUE...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();
                dtpFecFirmaFiador.Format = DateTimePickerFormat.Custom;
                dtpFecFirmaFiador.CustomFormat = " ";
                dtpFecFirmaFiador.Select();
            }
        }

        //***** PROCEDIMIENTO PARA CALCULAR EL VENCIMIENTO DE LA FIANZA *****
        private void CalcularVto()
        {
            senial = 0;
            fechavto = Convert.ToDateTime("1/1/1900 00:00:00");

            if (dtpFecFirmaMat.Text != " ")
            {
                senial = senial + 1;
                if (txtUserFirmaMat.Text == string.Empty)
                {
                    txtUserFirmaMat.Text = txtUserRegistro.Text;
                }
            }
            else
            {
                dtpFecFirmaMat.Value = Convert.ToDateTime("1/1/1900 00:00:00");
            }

            if (dtpFecFirmaFiador.Text != " ")
            {
                senial = senial + 1;
                if (txtUserFirmaFiador.Text == string.Empty)
                {
                    txtUserFirmaFiador.Text = txtUserRegistro.Text;
                }
            }
            else
            {
                dtpFecFirmaFiador.Value = Convert.ToDateTime("1/1/1900 00:00:00");
            }

            if (senial == 2)
            {
                DateTime fecha1 = Convert.ToDateTime(dtpFecFirmaMat.Value);
                DateTime fecha2 = Convert.ToDateTime(dtpFecFirmaFiador.Value);

                if (fecha1 >= fecha2)
                {
                    fechavto = fecha1.AddYears(2);
                    usuario = txtUserRegistro.Text;
                    estado = "COMPLETA";
                }
                else
                {
                    fechavto = fecha2.AddYears(2);
                    usuario = txtUserRegistro.Text;
                    estado = "COMPLETA";
                }

                fecha = Convert.ToString(fechavto);
                bool resultado = new CN_Colegiados().ActualizarFianza(txtMatricula.Text, "ACTIVO", fecha);
            }
            else
            {
                fechavto = Convert.ToDateTime("1/1/1900 00:00:00");
                estado = "INCOMPLETA";
            }
        }

        //***** PROCEDIMIENTO PARA IMPRIMIR LA CREDENCIAL *****
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            senial = 0;

            if (estado == "INCOMPLETA")
            {
                string mensaje = string.Empty;

                mensaje += "LA CREDENCIAL NO ESTÁ COMPLETA, VERIFIQUE...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();
                senial = senial + 1;
            }

            if (Convert.ToDateTime(txtVencimiento.Text) < DateTime.Now.Date)
            {
                string mensaje = string.Empty;

                mensaje += "LA CREDENCIAL ESTÁ VENCIDA, VERIFIQUE...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();
                senial = senial + 1;
            }

            if (senial == 0)
            {
                mdlCredencial Credencial = new mdlCredencial(txtMatricula.Text);
                Credencial.ShowDialog();
                txtMatricula.Text = string.Empty;
                Limpiar();
            }

            senial = 0;
        }
    }
}
