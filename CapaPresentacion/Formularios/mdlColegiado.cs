using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlColegiado : Form
    {
        CN_Colegiados cN_Colegiados = new CN_Colegiados();

        string NameBoton;

        public mdlColegiado(string NombreBoton)
        {
            InitializeComponent();
            NameBoton = NombreBoton;
        }

        private void mdlColegiado_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Colegiados> ListaColeg = new CN_Colegiados().ListaColeg();

            //*****CARGO EL DGV *****
            foreach (CE_Colegiados item in ListaColeg)
            {
                dgvColegiados.Rows.Add(new object[] { "", item.id_Coleg, item.Matricula, item.ApelNombres, item.Estado, item.FecVenceFianza });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvColegiados.Columns)
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
        private void dgvColegiados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvColegiados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvColegiados.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();

                    if (NameBoton == "btnCtasCtes")
                    {
                        frmCtasCtesColeg CtasCtesColeg = Owner as frmCtasCtesColeg;
                        CtasCtesColeg.lblColegiado.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString() + " - " +
                                                          dgvColegiados.Rows[indice].Cells["Estado"].Value.ToString();
                        CtasCtesColeg.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        CtasCtesColeg.txtId.Text = dgvColegiados.Rows[indice].Cells["id_Coleg"].Value.ToString();
                        CtasCtesColeg.txtFechaVence.Text = dgvColegiados.Rows[indice].Cells["FecVenceFianza"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnCobrarPendientes")
                    {
                        frmCobrarPendientes CobrarPendientes = Owner as frmCobrarPendientes;
                        CobrarPendientes.lblNombre.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        CobrarPendientes.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        CobrarPendientes.txtFk_idColeg.Text = dgvColegiados.Rows[indice].Cells["id_Coleg"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnCobrarVarios")
                    {
                        frmCobrarVarios CobrarVarios = Owner as frmCobrarVarios;
                        CobrarVarios.lblNombre.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        CobrarVarios.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        CobrarVarios.txtIdColeg.Text = dgvColegiados.Rows[indice].Cells["id_Coleg"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnSaldoPago")
                    {
                        frmSaldoPagoColeg SaldoPagoColeg = Owner as frmSaldoPagoColeg;
                        SaldoPagoColeg.lblApelNombres.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        SaldoPagoColeg.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        SaldoPagoColeg.txtId.Text = dgvColegiados.Rows[indice].Cells["id_Coleg"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnMarti1")
                    {
                        frmSociedades Marti1 = Owner as frmSociedades;
                        Marti1.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        Marti1.txtApelNomb.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        Marti1.txtEstadoMat.Text = dgvColegiados.Rows[indice].Cells["Estado"].Value.ToString();
                        Marti1.txtFianza.Text = dgvColegiados.Rows[indice].Cells["FecVenceFianza"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnMarti2")
                    {
                        frmSociedades Marti2 = Owner as frmSociedades;
                        Marti2.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        Marti2.txtApelNomb.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        Marti2.txtEstadoMat.Text = dgvColegiados.Rows[indice].Cells["Estado"].Value.ToString();
                        Marti2.txtFianza.Text = dgvColegiados.Rows[indice].Cells["FecVenceFianza"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnMarti3")
                    {
                        frmSociedades Marti3 = Owner as frmSociedades;
                        Marti3.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        Marti3.txtApelNomb.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        Marti3.txtEstadoMat.Text = dgvColegiados.Rows[indice].Cells["Estado"].Value.ToString();
                        Marti3.txtFianza.Text = dgvColegiados.Rows[indice].Cells["FecVenceFianza"].Value.ToString();
                        Close();
                        Dispose();
                    }
                    if (NameBoton == "btnMarti4")
                    {
                        frmSociedades Marti4 = Owner as frmSociedades;
                        Marti4.txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Mat"].Value.ToString();
                        Marti4.txtApelNomb.Text = dgvColegiados.Rows[indice].Cells["Nombres"].Value.ToString();
                        Marti4.txtEstadoMat.Text = dgvColegiados.Rows[indice].Cells["Estado"].Value.ToString();
                        Marti4.txtFianza.Text = dgvColegiados.Rows[indice].Cells["FecVenceFianza"].Value.ToString();
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

            if (dgvColegiados.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvColegiados.Rows)
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
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                row.Visible = true;
            }
        }

    }
}
