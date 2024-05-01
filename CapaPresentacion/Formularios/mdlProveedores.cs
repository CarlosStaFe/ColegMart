using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlProveedores : Form
    {
        string NameBoton;

        public mdlProveedores(string NombreBoton)
        {
            InitializeComponent();
        }

        private void mdlProveedores_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Sociedades> ListaSoc = new CN_Sociedades().ListaSoc();

            //*****CARGO EL DGV *****
            foreach (CE_Sociedades item in ListaSoc)
            {
                dgvProveedores.Rows.Add(new object[] { "", item.id_Soc, item.Numero, item.Nombre, item.Estado });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvProveedores.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            cboBusqueda.Select();

        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();

                    if (NameBoton == "btnCtasCtes")
                    {
                        frmCtasCtesProv CtasCtesProv = Owner as frmCtasCtesProv;
                        CtasCtesProv.lblProveedor.Text = dgvProveedores.Rows[indice].Cells["RazonSocial"].Value.ToString() + " - " +
                                                          dgvProveedores.Rows[indice].Cells["Domicilio"].Value.ToString();
                        CtasCtesProv.txtNumero.Text = dgvProveedores.Rows[indice].Cells["RazonSocial"].Value.ToString();
                        CtasCtesProv.txtId.Text = dgvProveedores.Rows[indice].Cells["id_Prov"].Value.ToString();
                        Close();
                        Dispose();
                    }
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvProveedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
