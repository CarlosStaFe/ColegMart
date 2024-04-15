using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmBancos : Form
    {
        CN_Bancos cN_Bancos = new CN_Bancos();
        private string respuesta;

        public frmBancos()
        {
            InitializeComponent();
        }

        private void frmBancos_Load(object sender, EventArgs e)
        {
            List<CE_Bancos> ListaBanco = new CN_Bancos().ListaBancos();

            //***** CARGO EL DGV *****
            foreach (CE_Bancos item in ListaBanco)
            {
                dgvBancos.Rows.Add(new object[] { "", item.id_Bco, item.Cuit, item.Nombre, item.Activo, item.UserRegistro });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvBancos.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtCuit.Select();
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE BANCO...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Bancos cEBancos = new CE_Bancos()
                {
                    id_Bco = Convert.ToInt32(txtId.Text),
                    Cuit = txtCuit.Text,
                    Nombre = txtNombre.Text,
                    Activo = chbActivo.Checked,
                    UserRegistro = VarGlobales.NombreUsuario
                };

                //***** SI EL ID DEL BOTÓN = 0 REGISTRA, SINO EDITA *****
                if (cEBancos.id_Bco == 0)
                {
                    int idBanco = new CN_Bancos().Registrar(cEBancos, out mensaje);

                    if (idBanco != 0)
                    {
                        dgvBancos.Rows.Add(new object[] { "", idBanco, txtCuit.Text, txtNombre.Text, chbActivo.Checked, txtUserRegistro.Text });
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
                    bool resultado = new CN_Bancos().Editar(cEBancos, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvBancos.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Bco"].Value = txtIndice.Text;
                        row.Cells["Cuit"].Value = txtCuit.Text;
                        row.Cells["Nombre"].Value = txtNombre.Text;
                        row.Cells["Activo"].Value = chbActivo.Checked;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;

                        Limpiar();
                    }
                    else
                    {
                        mensaje += "VERIFIQUE...!!!";
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
            txtCuit.Text = string.Empty;
            txtNombre.Text = string.Empty;
            chbActivo.Checked = true;
            txtUserRegistro.Text = string.Empty;
            txtCuit.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvBancos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvBancos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBancos.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvBancos.Rows[indice].Cells["id_Bco"].Value.ToString();
                    txtCuit.Text = dgvBancos.Rows[indice].Cells["Cuit"].Value.ToString();
                    txtNombre.Text = dgvBancos.Rows[indice].Cells["Nombre"].Value.ToString();
                    chbActivo.Checked = Convert.ToBoolean(dgvBancos.Rows[indice].Cells["Activo"].Value);
                    txtUserRegistro.Text = dgvBancos.Rows[indice].Cells["UserRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cboBusqueda.SelectedItem.ToString();

            if (dgvBancos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvBancos.Rows)
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
            foreach (DataGridViewRow row in dgvBancos.Rows)
            {
                row.Visible = true;
            }
        }

    }
}
