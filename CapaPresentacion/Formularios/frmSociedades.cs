using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmSociedades : Form
    {
        SoloNumeros validar = new SoloNumeros();

        private string respuesta, localidad, nrosoc, fecha;
        private int idcodpos, numero;

        public frmSociedades()
        {
            InitializeComponent();
        }

        private void frmSociedades_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Sociedades> ListaSoc = new CN_Sociedades().ListaSoc();

            //***** CARGO EL DGV *****
            foreach (CE_Sociedades item in ListaSoc)
            {
                dgvSociedades.Rows.Add(new object[] { "", item.id_Soc, item.Numero, item.Nombre, item.Cuit, item.Domicilio, item.idCodPostal, item.idLocal, item.idDepto, item.idProv,
                                                item.Telefono, item.Email, item.Tipo, item.Estado, item.FechaEstado, item.Inscripcion, item.Semestral, item.Martillero1, item.Martillero2,
                                                item.Martillero3, item.Martillero4, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            //Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvSociedades.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtNombre.Select();
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvSociedades.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvSociedades.Rows[i].Cells["Fianza"].Value);

                if (dateFecha.Date <= DateTime.Now.Date)
                {
                    dgvSociedades.Rows[i].Cells["Fianza"].Style.ForeColor = Color.Black;
                    dgvSociedades.Rows[i].Cells["Fianza"].Style.BackColor = Color.DarkOrange;
                }
                else
                {
                    dgvSociedades.Rows[i].Cells["Fianza"].Style.ForeColor = Color.Lime;
                    dgvSociedades.Rows[i].Cells["Fianza"].Style.BackColor = Color.Black;
                }
            }
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTA SOCIEDAD...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                nrosoc = numero.ToString();
                string respuesta = new CN_Sociedades().AsignarNumero(nrosoc, out mensaje);
                txtNumero.Text = respuesta;
                lblNumero.Text = txtNumero.Text;

                CE_Sociedades cE_Sociedades = new CE_Sociedades()
                {
                    id_Soc = Convert.ToInt32(txtId.Text),
                    Numero = Convert.ToInt32(txtNumero.Text),
                    Nombre = txtNombre.Text,
                    Cuit = Convert.ToInt32(txtCuit.Text),
                    Domicilio = txtDomicilio.Text,
                    idCodPostal = Convert.ToInt32(txtCodPostal.Text),
                    idLocal = Convert.ToInt32(txtLocal.Text),
                    idDepto = Convert.ToInt32(txtDepto.Text),
                    idProv = Convert.ToInt32(txtProv.Text),
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Tipo = cboTipo.Text,
                    Estado = cboEstado.Text,
                    FechaEstado = dtpFecEstado.Value,
                    Inscripcion = Convert.ToInt32(cboInscripcion.Text),
                    Semestral = Convert.ToInt32(cboSemestral.Text),
                    Martillero1 = Convert.ToInt32(txtMarti1.Text),
                    Martillero2 = Convert.ToInt32(txtMarti2.Text),
                    Martillero3 = Convert.ToInt32(txtMarti3.Text),
                    Martillero4 = Convert.ToInt32(txtMarti4.Text),
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //***** SI EL ID DE LA SOCIEDAD = 0 REGISTRA, SINO EDITA *****
                if (cE_Sociedades.id_Soc == 0)
                {
                    int idSociedad = new CN_Sociedades().Registrar(cE_Sociedades, out mensaje);

                    if (idSociedad != 0)
                    {
                        dgvSociedades.Rows.Add(new object[] {"",idSociedad,txtNumero.Text,txtNombre.Text,txtCuit.Text,txtDomicilio.Text,txtCodPostal.Text,txtLocal.Text,txtDepto.Text,txtProv.Text,
                                                  txtTelefono.Text,txtEmail.Text,cboTipo.Text,cboEstado.Text,dtpFecEstado.Text,cboInscripcion.Text,cboSemestral.Text,txtMarti1.Text,
                                                  txtMarti2.Text,txtMarti3.Text,txtMarti4.Text,txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text});
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
                    bool resultado = new CN_Sociedades().Editar(cE_Sociedades, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvSociedades.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Soc"].Value = txtId.Text;
                        row.Cells["Num"].Value = txtNumero.Text;
                        row.Cells["Nombre"].Value = txtNombre.Text;
                        row.Cells["Cuit"].Value = txtCuit.Text;
                        row.Cells["Domicilio"].Value = txtDomicilio.Text;
                        row.Cells["idCodPostal"].Value = txtCodPostal.Text;
                        row.Cells["idLocal"].Value = txtLocal.Text;
                        row.Cells["idDepto"].Value = txtDepto.Text;
                        row.Cells["idProv"].Value = txtProv.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["Email"].Value = txtEmail.Text;
                        row.Cells["Tipo"].Value = cboTipo.Text;
                        row.Cells["Estado"].Value = cboEstado.Text; 
                        row.Cells["FecEstado"].Value = dtpFecEstado.Text;
                        row.Cells["Inscr"].Value = cboInscripcion.Text;
                        row.Cells["Semest"].Value = cboSemestral.Text;
                        row.Cells["Marti1"].Value = txtMarti1.Text;
                        row.Cells["Marti2"].Value = txtMarti2.Text;
                        row.Cells["Marti3"].Value = txtMarti3.Text;
                        row.Cells["Marti4"].Value = txtMarti4.Text;
                        row.Cells["Obs"].Value = txtObs.Text;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;
                        row.Cells["FechaRegistro"].Value = txtFechaRegistro.Text;

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
            //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            txtId.Text = "0";
            txtNumero.Text = string.Empty;
            lblNumero.Text = "-";
            txtNombre.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            txtLocal.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtProv.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboTipo.Text = string.Empty;
            cboEstado.Text = string.Empty;
            dtpFecEstado.Value = DateTime.Now;
            cboInscripcion.Text = string.Empty;
            cboSemestral.Text = string.Empty;
            txtMarti1.Text = string.Empty;
            lblMartillero1.Text = "-";
            txtMarti2.Text = string.Empty;
            lblMartillero2.Text = "-";
            txtMarti3.Text = string.Empty;
            lblMartillero3.Text = "-";
            txtMarti4.Text = string.Empty;
            lblMartillero4.Text = "-";
            txtObs.Text = string.Empty;

            txtNombre.Select();
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

        //***** PROCEDIMIENTO PARA COLOCAR EL ÍCONO EN CADA RENGLÓN *****
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

        //***** PROCEDIMIENTO PARA MOSTRAR EL RENGLÓN SELECCIONADO *****
        private void dgvSociedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSociedades.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvSociedades.Rows[indice].Cells["id_Soc"].Value.ToString();
                    txtNumero.Text = dgvSociedades.Rows[indice].Cells["Num"].Value.ToString();
                    lblNumero.Text = txtNumero.Text;
                    txtNombre.Text = dgvSociedades.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtCuit.Text = dgvSociedades.Rows[indice].Cells["Cuit"].Value.ToString();
                    txtDomicilio.Text = dgvSociedades.Rows[indice].Cells["Domicilio"].Value.ToString();
                    txtCodPostal.Text = dgvSociedades.Rows[indice].Cells["idCodPostal"].Value.ToString();
                    txtLocal.Text = dgvSociedades.Rows[indice].Cells["idLocal"].Value.ToString();
                    txtDepto.Text = dgvSociedades.Rows[indice].Cells["idDepto"].Value.ToString();
                    txtProv.Text = dgvSociedades.Rows[indice].Cells["idProv"].Value.ToString();
                    txtTelefono.Text = dgvSociedades.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtEmail.Text = dgvSociedades.Rows[indice].Cells["Email"].Value.ToString();
                    cboTipo.Text = dgvSociedades.Rows[indice].Cells["Tipo"].Value.ToString();
                    cboEstado.Text = dgvSociedades.Rows[indice].Cells["Estado"].Value.ToString();
                    dtpFecEstado.Value = Convert.ToDateTime(dgvSociedades.Rows[indice].Cells["FecEstado"].Value.ToString());
                    cboInscripcion.Text = dgvSociedades.Rows[indice].Cells["Inscr"].Value.ToString();
                    cboSemestral.Text = dgvSociedades.Rows[indice].Cells["Semest"].Value.ToString();
                    txtMarti1.Text = dgvSociedades.Rows[indice].Cells["Marti1"].Value.ToString();
                    txtMarti2.Text = dgvSociedades.Rows[indice].Cells["Marti2"].Value.ToString();
                    txtMarti3.Text = dgvSociedades.Rows[indice].Cells["Marti3"].Value.ToString();
                    txtMarti4.Text = dgvSociedades.Rows[indice].Cells["Marti4"].Value.ToString();
                    txtObs.Text = dgvSociedades.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvSociedades.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvSociedades.Rows[indice].Cells["FechaRegistro"].Value.ToString();

                    lblMartillero1.Text = txtMarti1.Text;
                    lblMartillero2.Text = txtMarti2.Text;
                    lblMartillero3.Text = txtMarti3.Text;
                    lblMartillero4.Text = txtMarti4.Text;

                    //***** BUSCO LA LOCALIDAD DE LA SOCIEDAD *****
                    idcodpos = Convert.ToInt32(txtLocal.Text);
                    localidad = new CN_CodigosPostales().BuscaCodPos(idcodpos);
                    lblLocalidad.Text = localidad.ToString();
                }
            }
        }

        //***** BUSCO LA LOCALIDAD DE LA SOCIEDAD *****
        private void btnLocalidad_Click(object sender, EventArgs e)
        {
                mdlCodPostal LocalSoc = new mdlCodPostal("btnLocalSoc");
                AddOwnedForm(LocalSoc);
                LocalSoc.ShowDialog();
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

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvSociedades.Rows)
            {
                row.Visible = true;
            }
        }

        //***** VALIDO QUE SE INGRESE UN NUMERO EN EL CUIT *****
        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** BUSCO LOS COLEGIADOS DE CADA SOCIEDAD *****
        private void btnMarti1_Click(object sender, EventArgs e)
        {
            mdlColegiado Marti1 = new mdlColegiado("btnMarti1");
            AddOwnedForm(Marti1);
            Marti1.ShowDialog();
            txtMatricula.Text = txtMatricula.Text.Replace(" ", string.Empty);
            txtApelNomb.Text = txtApelNomb.Text.TrimEnd(' ');
            txtEstadoMat.Text = txtEstadoMat.Text.Replace(" ", string.Empty);
            fecha = new ProcesarFecha().Proceso(txtFianza.Text);
            lblMartillero1.Text = txtMatricula.Text + " - " + txtApelNomb.Text + " - " + txtEstadoMat.Text + " - VTO. " + fecha;
            txtMarti1.Text = txtMatricula.Text;
        }

        private void btnMarti2_Click(object sender, EventArgs e)
        {
            mdlColegiado Marti2 = new mdlColegiado("btnMarti2");
            AddOwnedForm(Marti2);
            Marti2.ShowDialog();
            txtMatricula.Text = txtMatricula.Text.Replace(" ", string.Empty);
            txtApelNomb.Text = txtApelNomb.Text.TrimEnd(' ');
            txtEstadoMat.Text = txtEstadoMat.Text.Replace(" ", string.Empty);
            fecha = new ProcesarFecha().Proceso(txtFianza.Text);
            lblMartillero2.Text = txtMatricula.Text + " - " + txtApelNomb.Text + " - " + txtEstadoMat.Text + " - VTO. " + fecha;
            txtMarti2.Text = txtMatricula.Text;
        }

        private void btnMarti3_Click(object sender, EventArgs e)
        {
            mdlColegiado Marti3 = new mdlColegiado("btnMarti3");
            AddOwnedForm(Marti3);
            Marti3.ShowDialog();
            txtMatricula.Text = txtMatricula.Text.Replace(" ", string.Empty);
            txtApelNomb.Text = txtApelNomb.Text.TrimEnd(' ');
            txtEstadoMat.Text = txtEstadoMat.Text.Replace(" ", string.Empty);
            fecha = new ProcesarFecha().Proceso(txtFianza.Text);
            lblMartillero3.Text = txtMatricula.Text + " - " + txtApelNomb.Text + " - " + txtEstadoMat.Text + " - VTO. " + fecha;
            txtMarti3.Text = txtMatricula.Text;
        }

        private void btnMarti4_Click(object sender, EventArgs e)
        {
            mdlColegiado Marti4 = new mdlColegiado("btnMarti4");
            AddOwnedForm(Marti4);
            Marti4.ShowDialog();
            txtMatricula.Text = txtMatricula.Text.Replace(" ", string.Empty);
            txtApelNomb.Text = txtApelNomb.Text.TrimEnd(' ');
            txtEstadoMat.Text = txtEstadoMat.Text.Replace(" ", string.Empty);
            fecha = new ProcesarFecha().Proceso(txtFianza.Text);
            lblMartillero4.Text = txtMatricula.Text + " - " + txtApelNomb.Text + " - " + txtEstadoMat.Text + " - VTO. " + fecha;
            txtMarti4.Text = txtMatricula.Text;
        }



    }
}
