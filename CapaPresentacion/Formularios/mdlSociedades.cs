using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlSociedades : Form
    {
        string NameBoton;

        public mdlSociedades(string NombreBoton)
        {
            InitializeComponent();
            NameBoton = NombreBoton;
        }

        private void mdlSociedades_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Sociedades> ListaSoc = new CN_Sociedades().ListaSoc();

            //*****CARGO EL DGV *****
            foreach (CE_Sociedades item in ListaSoc)
            {
                dgvSociedades.Rows.Add(new object[] { "", item.id_Soc, item.Numero, item.Nombre, item.Estado });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvSociedades.Columns)
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
        private void dgvSociedades_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvSociedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSociedades.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();

                    if (NameBoton == "btnCtasCtes")
                    {
                        frmCtasCtesSoc CtasCtesSoc = Owner as frmCtasCtesSoc;
                        CtasCtesSoc.lblSociedad.Text = dgvSociedades.Rows[indice].Cells["Nombre"].Value.ToString() + " - " +
                                                          dgvSociedades.Rows[indice].Cells["Estado"].Value.ToString();
                        CtasCtesSoc.txtNumero.Text = dgvSociedades.Rows[indice].Cells["Numero"].Value.ToString();
                        CtasCtesSoc.txtId.Text = dgvSociedades.Rows[indice].Cells["id_Soc"].Value.ToString();
                        Close();
                        Dispose();
                    }

                    if (NameBoton == "btnCobrarPendientes")
                    {
                        frmCobrarPendientes CobroPen = Owner as frmCobrarPendientes;
                        CobroPen.lblNombre.Text = dgvSociedades.Rows[indice].Cells["Nombre"].Value.ToString() + " - " +
                                                     dgvSociedades.Rows[indice].Cells["Estado"].Value.ToString();
                        CobroPen.txtMatricula.Text = dgvSociedades.Rows[indice].Cells["Numero"].Value.ToString();
                        CobroPen.txtId.Text = dgvSociedades.Rows[indice].Cells["id_Soc"].Value.ToString();
                        Close();
                        Dispose();
                    }

                    if (NameBoton == "btnCobrarVarios")
                    {
                        frmCobrarVarios CobroVar = Owner as frmCobrarVarios;
                        CobroVar.lblNombre.Text = dgvSociedades.Rows[indice].Cells["Nombre"].Value.ToString() + " - " +
                                                     dgvSociedades.Rows[indice].Cells["Estado"].Value.ToString();
                        CobroVar.txtMatricula.Text = dgvSociedades.Rows[indice].Cells["Numero"].Value.ToString();
                        CobroVar.txtId.Text = dgvSociedades.Rows[indice].Cells["id_Soc"].Value.ToString();
                        Close();
                        Dispose();
                    }

                    if (NameBoton == "btnSaldoPago")
                    {
                        frmSaldoPagoSoc SaldoPago = Owner as frmSaldoPagoSoc;
                        SaldoPago.lblNombre.Text = dgvSociedades.Rows[indice].Cells["Nombre"].Value.ToString() + " - " +
                                                     dgvSociedades.Rows[indice].Cells["Estado"].Value.ToString();
                        SaldoPago.txtNumero.Text = dgvSociedades.Rows[indice].Cells["Numero"].Value.ToString();
                        SaldoPago.txtId.Text = dgvSociedades.Rows[indice].Cells["id_Soc"].Value.ToString();
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

            if (dgvSociedades.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSociedades.Rows)
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
            foreach (DataGridViewRow row in dgvSociedades.Rows)
            {
                row.Visible = true;
            }

        }
    }
}
