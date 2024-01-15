using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlDebitos : Form
    {
        CN_Debitos cN_Debitos = new CN_Debitos();

        string NameBoton;

        public mdlDebitos(string NombreBoton)
        {
            InitializeComponent();
            NameBoton = NombreBoton;
        }

        private void mdlDebitos_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Debitos> ListaDebitos = new CN_Debitos().ListaDebitoRec();

            //*****CARGO EL DGV *****
            foreach (CE_Debitos item in ListaDebitos)
            {
                dgvDebitos.Rows.Add(new object[] { "", item.id_Debito, item.Codigo, item.Detalle, item.Importe, item.Desde, item.Hasta });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvDebitos.Columns)
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

                    if (NameBoton == "btnCobrarVarios")
                    {
                        frmCobrarVarios CobrarVarios = Owner as frmCobrarVarios;
                        CobrarVarios.txtCodigo.Text = dgvDebitos.Rows[indice].Cells["Codigo"].Value.ToString();
                        CobrarVarios.lblDetalle.Text = dgvDebitos.Rows[indice].Cells["Detalle"].Value.ToString();
                        CobrarVarios.txtImporte.Text = dgvDebitos.Rows[indice].Cells["Importe"].Value.ToString();
                        CobrarVarios.txtDesde.Text = dgvDebitos.Rows[indice].Cells["Desde"].Value.ToString();
                        CobrarVarios.txtHasta.Text = dgvDebitos.Rows[indice].Cells["Hasta"].Value.ToString();
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

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR *****
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
