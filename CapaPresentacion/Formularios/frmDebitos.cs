using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace CapaPresentacion.Formularios
{
    public partial class frmDebitos : Form
    {
        CN_Debitos cN_Debitos = new CN_Debitos();
        private string respuesta;

        public frmDebitos()
        {
            InitializeComponent();
        }

        private void frmDebitos_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Debitos> ListaDebito = new CN_Debitos().ListaDebito();

            //*****CARGO EL DGV *****
            foreach (CE_Debitos item in ListaDebito)
            {
                dgvDebitos.Rows.Add(new object[] { "", item.id_Debito, item.Codigo, item.Detalle, item.Importe, item.Kilos, item.Categoria, item.TipoDebito,
                                                     item.Desde, item.Hasta, item.Activo, item.Obs, item.UserRegistro });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvDebitos.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            Limpiar();
            txtCodigo.Select();
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE DÉBITO...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Debitos cE_Debitos = new CE_Debitos()
                {
                    id_Debito = Convert.ToInt32(txtId.Text),
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Detalle = txtDetalle.Text,
                    Importe = Convert.ToDecimal(txtImporte.Text),
                    Kilos = Convert.ToInt32(txtKilos.Text),
                    Categoria = cboCategoria.Text,
                    TipoDebito = cboTipo.Text,
                    Desde = dtpDesde.Value,
                    Hasta = dtpHasta.Value,
                    Activo = chbActivo.Checked,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario
                };

                //*****SI EL ID DEL DEBITO = 0 REGISTRA, SINO EDITA *****
                if (cE_Debitos.id_Debito == 0)
                {
                    int idDebito = new CN_Debitos().Registrar(cE_Debitos, out mensaje);

                    if (idDebito != 0)
                    {
                        dgvDebitos.Rows.Add(new object[] {"",id_Debito,txtCodigo.Text,txtDetalle.Text,txtImporte.Text,cboCategoria.Text,
                                                  cboTipo.Text,dtpDesde.Value,dtpHasta.Value,chbActivo.Checked,txtObs.Text,txtUserRegistro.Text});
                        Limpiar();
                    }
                    else
                    {
                        mensaje += ". VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
                else
                {
                    bool resultado = new CN_Debitos().Editar(cE_Debitos, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvDebitos.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Debito"].Value = txtIndice.Text;
                        row.Cells["Cod"].Value = txtCodigo.Text;
                        row.Cells["Detalle"].Value = txtDetalle.Text;
                        row.Cells["Importe"].Value = txtImporte.Text;
                        row.Cells["Kilos"].Value = txtKilos.Text;
                        row.Cells["Categoria"].Value = cboCategoria.Text;
                        row.Cells["Tipo"].Value = cboTipo.Text;
                        row.Cells["Desde"].Value = dtpDesde.Value;
                        row.Cells["Hasta"].Value = dtpHasta.Value;
                        row.Cells["Activo"].Value = chbActivo.Checked;
                        row.Cells["Obs"].Value = txtObs.Text;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;

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

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            txtId.Text = "0";
            txtCodigo.Text = "0";
            txtDetalle.Text = string.Empty;
            txtImporte.Text = "0";
            txtKilos.Text = "0";
            cboCategoria.Text = string.Empty;
            cboTipo.Text = string.Empty;
            dtpDesde.Text = string.Empty;
            dtpHasta.Text = string.Empty;
            chbActivo.Checked = true;
            txtObs.Text = string.Empty;
            txtUserRegistro.Text = string.Empty;
            txtCodigo.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvDebitos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvDebitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDebitos.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvDebitos.Rows[indice].Cells["id_Debito"].Value.ToString();
                    txtCodigo.Text = dgvDebitos.Rows[indice].Cells["Cod"].Value.ToString();
                    txtDetalle.Text = dgvDebitos.Rows[indice].Cells["Detalle"].Value.ToString();
                    txtImporte.Text = dgvDebitos.Rows[indice].Cells["Importe"].Value.ToString();
                    txtKilos.Text = dgvDebitos.Rows[indice].Cells["Kilos"].Value.ToString();
                    cboCategoria.Text = dgvDebitos.Rows[indice].Cells["Categoria"].Value.ToString();
                    cboTipo.Text = dgvDebitos.Rows[indice].Cells["Tipo"].Value.ToString();

                    if (dgvDebitos.Rows[indice].Cells["Desde"].Value == null)
                    {
                        dtpDesde.Format = DateTimePickerFormat.Custom;
                        dtpDesde.CustomFormat = "''";
                    }
                    else
                    {
                        dtpDesde.Value = Convert.ToDateTime(dgvDebitos.Rows[indice].Cells["Desde"].Value.ToString());
                    }

                    if (dgvDebitos.Rows[indice].Cells["Hasta"].Value == null)
                    {
                        dtpHasta.Format = DateTimePickerFormat.Custom;
                        dtpHasta.CustomFormat = "''";
                    }
                    else
                    {
                        dtpHasta.Value = Convert.ToDateTime(dgvDebitos.Rows[indice].Cells["Hasta"].Value.ToString());
                    }

                    dtpDesde.Format = DateTimePickerFormat.Custom;
                    dtpDesde.CustomFormat = "dd/MM/yyyy";

                    dtpHasta.Format = DateTimePickerFormat.Custom;
                    dtpHasta.CustomFormat = "dd/MM/yyyy";

                    //dtpDesde.Value = Convert.ToDateTime(dgvDebitos.Rows[indice].Cells["Desde"].Value.ToString());
                    //dtpHasta.Value = Convert.ToDateTime(dgvDebitos.Rows[indice].Cells["Hasta"].Value.ToString());
                    chbActivo.Checked = Convert.ToBoolean(dgvDebitos.Rows[indice].Cells["Activo"].Value);
                    txtObs.Text = dgvDebitos.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvDebitos.Rows[indice].Cells["UserRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cboBusqueda.SelectedItem.ToString();

            if (dgvDebitos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDebitos.Rows)
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
            foreach (DataGridViewRow row in dgvDebitos.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
