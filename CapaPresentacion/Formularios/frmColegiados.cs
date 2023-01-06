using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmColegiados : Form
    {
        CN_Colegiados cN_Colegiados = new CN_Colegiados();
        CN_Localidades cN_Localidades = new CN_Localidades();

        public string localidad;
        private string respuesta;
        bool obtenido = true;
        private byte[] imagenByte;
        public int id;
        int local = 0;
        public string nromatri;

        //MemoryStream ms = new MemoryStream();

        public frmColegiados()
        {
            InitializeComponent();
        }

        private void frmColegiados_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Colegiados> ListaColeg = new CN_Colegiados().ListaColeg();

            //*****CARGO EL DGV *****
            foreach (CE_Colegiados item in ListaColeg)
            {
                dgvColegiados.Rows.Add(new object[] { "", item.id_Coleg, item.Matricula, item.ApelNombres, item.ApelMaterno, item.FechaNacim, item.LugarNacim, item.Nacionalidad,
                                                item.TipoDoc, item.NumeroDoc, item.Cuit, item.Sexo, item.EstadoCivil, item.Juramento, item.Tomo, item.Folio, item.Categoria,
                                                item.Email, item.Estado, item.FecEstado, item.DomParti, item.idLocalParti, item.idDeptoParti, item.idProvParti, item.FijoParti,
                                                item.CeluParti, item.DomLabor, item.idLocalLabor, item.idDeptoLabor, item.idProvLabor, item.FijoLabor, item.CeluLabor,
                                                item.FecVenceFianza, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvColegiados.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtMatricula.Select();
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text == "")
            {
                BuscoMatricula();
            }

            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE COLEGIADO...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Colegiados cE_Colegiados = new CE_Colegiados()
                {
                    id_Coleg = Convert.ToInt32(txtId.Text),
                    Matricula = Convert.ToInt32(txtMatricula.Text),
                    ApelNombres = txtApelNombres.Text,
                    ApelMaterno = txtApelMaterno.Text,
                    FechaNacim = dtpFechaNacim.Value,
                    LugarNacim = txtLugarNacim.Text,
                    Nacionalidad = txtNacionalidad.Text,
                    TipoDoc = cboTipoDoc.Text,
                    NumeroDoc = Convert.ToInt32(txtNumeroDoc.Text),
                    Cuit = txtCuit.Text,
                    Sexo = cboSexo.Text,
                    EstadoCivil = cboEstadoCivil.Text,
                    Juramento = dtpJuramento.Value,
                    Tomo = txtTomo.Text,
                    Folio = txtFolio.Text,
                    Categoria = cboCategoria.Text,
                    Email = txtEmail.Text,
                    Estado = cboEstado.Text,
                    FecEstado = dtpFecEstado.Value,
                    DomParti = txtDomParti.Text,
                    idLocalParti = Convert.ToInt32(txtLocalParti.Text),
                    idDeptoParti = Convert.ToInt32(txtDeptoParti.Text),
                    idProvParti = Convert.ToInt32(txtProvParti.Text),
                    FijoParti = txtFijoParti.Text,
                    CeluParti = txtCeluParti.Text,
                    DomLabor = txtDomLabor.Text,
                    idLocalLabor = Convert.ToInt32(txtLocalLabor.Text),
                    idDeptoLabor = Convert.ToInt32(txtDeptoLabor.Text),
                    idProvLabor = Convert.ToInt32(txtProvLabor.Text),
                    FijoLabor = txtFijoLabor.Text,
                    CeluLabor = txtCeluLabor.Text,
                    FecVenceFianza = dtpFecVenceFianza.Value,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //*****SI EL ID DEL COLEGIADO = 0 REGISTRA, SINO EDITA *****
                if (cE_Colegiados.id_Coleg == 0)
                {
                    int idColegiado = new CN_Colegiados().Registrar(cE_Colegiados, out mensaje);

                    if (idColegiado != 0)
                    {
                        dgvColegiados.Rows.Add(new object[] {"",idColegiado,txtMatricula.Text,txtApelNombres.Text,txtApelMaterno.Text,dtpFechaNacim.Value,txtLugarNacim.Text,
                                                  txtNacionalidad.Text,cboTipoDoc.Text,txtNumeroDoc.Text,txtCuit.Text,cboSexo.Text,cboEstadoCivil.Text,dtpJuramento.Value,
                                                  txtTomo.Text,txtFolio.Text,cboCategoria.Text,txtEmail.Text,cboEstado.Text,dtpFecEstado.Value,txtDomParti.Text,
                                                  txtLocalParti.Text,txtDeptoParti.Text,txtProvParti.Text,txtFijoParti.Text,txtCeluParti.Text,txtDomLabor.Text,
                                                  txtLocalLabor.Text,txtDeptoLabor.Text,txtProvLabor.Text,txtFijoLabor.Text,txtCeluLabor.Text,dtpFecVenceFianza.Value,
                                                  txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text});
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
                    bool resultado = new CN_Colegiados().Editar(cE_Colegiados, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvColegiados.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Coleg"].Value = txtIndice.Text;
                        row.Cells["Matri"].Value = txtMatricula.Text;
                        row.Cells["ApellidoyNombres"].Value = txtApelNombres.Text;
                        row.Cells["ApelMaterno"].Value = txtApelMaterno.Text;
                        row.Cells["FechaNacim"].Value = dtpFechaNacim.Value;
                        row.Cells["LugarNacim"].Value = txtLugarNacim.Text;
                        row.Cells["Nacionalidad"].Value = txtNacionalidad.Text;
                        row.Cells["TipoDoc"].Value = cboTipoDoc.Text;
                        row.Cells["NumeroDoc"].Value = txtNumeroDoc.Text;
                        row.Cells["Cuit"].Value = txtCuit.Text;
                        row.Cells["Sexo"].Value = cboSexo.Text;
                        row.Cells["EstadoCivil"].Value = cboEstadoCivil.Text;
                        row.Cells["Juramento"].Value = dtpJuramento.Value;
                        row.Cells["Tomo"].Value = txtTomo.Text;
                        row.Cells["Folio"].Value = txtFolio.Text;
                        row.Cells["Categ"].Value = cboCategoria.Text;
                        row.Cells["Email"].Value = txtEmail.Text;
                        row.Cells["Estado"].Value = cboEstado.Text;
                        row.Cells["FechaEstado"].Value = dtpFecEstado.Value;
                        row.Cells["DomParti"].Value = txtDomParti.Text;
                        row.Cells["idLocalParti"].Value = txtLocalParti.Text;
                        row.Cells["idDeptoParti"].Value = txtDeptoParti.Text;
                        row.Cells["idProvParti"].Value = txtProvParti.Text;
                        row.Cells["FijoParti"].Value = txtFijoParti.Text;
                        row.Cells["CeluParti"].Value = txtCeluParti.Text;
                        row.Cells["DomLabor"].Value = txtDomLabor.Text;
                        row.Cells["idLocalLabor"].Value = txtLocalLabor.Text;
                        row.Cells["idDeptoLabor"].Value = txtDeptoLabor.Text;
                        row.Cells["idProvLabor"].Value = txtProvLabor.Text;
                        row.Cells["FijoLabor"].Value = txtFijoLabor.Text;
                        row.Cells["CeluLabor"].Value = txtCeluLabor.Text;
                        row.Cells["Fianza"].Value = dtpFecVenceFianza.Value;
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
            txtMatricula.Text = String.Empty;
            lblMatricula.Text = "-";
            txtApelNombres.Text = String.Empty;
            txtApelMaterno.Text = String.Empty;
            txtLugarNacim.Text = String.Empty;
            txtNacionalidad.Text = String.Empty;
            cboTipoDoc.Text = String.Empty;
            txtNumeroDoc.Text = String.Empty;
            txtCuit.Text = String.Empty;
            cboSexo.Text = String.Empty;
            cboEstadoCivil.Text = String.Empty;
            txtTomo.Text = String.Empty;
            txtFolio.Text = String.Empty;
            cboCategoria.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboEstado.Text = String.Empty;
            txtDomParti.Text = String.Empty;
            lblDetLocalParti.Text = String.Empty;
            txtLocalParti.Text = String.Empty;
            txtDeptoParti.Text = String.Empty;
            txtProvParti.Text = String.Empty;
            txtFijoParti.Text = String.Empty;
            txtCeluParti.Text = String.Empty;
            txtDomLabor.Text = String.Empty;
            lblDetLocalLabor.Text = String.Empty;
            txtLocalLabor.Text = String.Empty;
            txtDeptoLabor.Text = String.Empty;
            txtProvLabor.Text = String.Empty;
            txtFijoLabor.Text = String.Empty;
            txtCeluLabor.Text = String.Empty;
            txtObs.Text = String.Empty;
            picFoto.Image= Image.FromFile("E:\\DBColegMart/Fotos/FotoVacia.png");
            dtpFecEstado.Value = DateTime.Now;
            dtpFechaNacim.Value = DateTime.Now;
            dtpFecVenceFianza.Value = DateTime.Now;
            dtpJuramento.Value = DateTime.Now;
            lblFechaVence.Text = "-";
            lblFechaVence.ForeColor = Color.Lime;
            lblVenceFianza.ForeColor = Color.Lime;
            btnMatricula.Enabled = false;

            txtApelNombres.Select();
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
                    txtId.Text = dgvColegiados.Rows[indice].Cells["id_Coleg"].Value.ToString();
                    txtMatricula.Text = dgvColegiados.Rows[indice].Cells["Matri"].Value.ToString();
                    lblMatricula.Text = txtMatricula.Text;

                    int numero = int.Parse(txtMatricula.Text);

                    if (numero > 79000)
                    {
                        btnMatricula.Enabled = true;
                    }
                    else
                    {
                        btnMatricula.Enabled = false;
                    }

                    txtApelNombres.Text = dgvColegiados.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                    txtApelMaterno.Text = dgvColegiados.Rows[indice].Cells["ApelMaterno"].Value.ToString();
                    dtpFechaNacim.Value = Convert.ToDateTime(dgvColegiados.Rows[indice].Cells["FechaNacim"].Value.ToString());
                    txtLugarNacim.Text = dgvColegiados.Rows[indice].Cells["LugarNacim"].Value.ToString();
                    txtNacionalidad.Text = dgvColegiados.Rows[indice].Cells["Nacionalidad"].Value.ToString();
                    cboTipoDoc.Text = dgvColegiados.Rows[indice].Cells["TipoDoc"].Value.ToString();
                    txtNumeroDoc.Text = dgvColegiados.Rows[indice].Cells["NumeroDoc"].Value.ToString();
                    txtCuit.Text = dgvColegiados.Rows[indice].Cells["Cuit"].Value.ToString();
                    cboSexo.Text = dgvColegiados.Rows[indice].Cells["Sexo"].Value.ToString();
                    cboEstadoCivil.Text = dgvColegiados.Rows[indice].Cells["EstadoCivil"].Value.ToString();
                    dtpJuramento.Value = Convert.ToDateTime(dgvColegiados.Rows[indice].Cells["Juramento"].Value.ToString());
                    txtTomo.Text = dgvColegiados.Rows[indice].Cells["Tomo"].Value.ToString();
                    txtFolio.Text = dgvColegiados.Rows[indice].Cells["Folio"].Value.ToString();
                    cboCategoria.Text = dgvColegiados.Rows[indice].Cells["Categ"].Value.ToString();
                    txtEmail.Text = dgvColegiados.Rows[indice].Cells["Email"].Value.ToString();
                    cboEstado.Text = dgvColegiados.Rows[indice].Cells["Estado"].Value.ToString();
                    dtpFecEstado.Value = Convert.ToDateTime(dgvColegiados.Rows[indice].Cells["FechaEstado"].Value.ToString());
                    txtDomParti.Text = dgvColegiados.Rows[indice].Cells["DomParti"].Value.ToString();
                    txtLocalParti.Text = dgvColegiados.Rows[indice].Cells["idLocalParti"].Value.ToString();
                    txtDeptoParti.Text = dgvColegiados.Rows[indice].Cells["idDeptoParti"].Value.ToString();
                    txtProvParti.Text = dgvColegiados.Rows[indice].Cells["idProvParti"].Value.ToString();

                    //***** BUSCO LA LOCALIDAD PARTICULAR *****
                    local = Convert.ToInt32(txtLocalParti.Text);
                    localidad = new CN_Localidades().BuscaCodPos(local);
                    lblDetLocalParti.Text = localidad.ToString();

                    txtFijoParti.Text = dgvColegiados.Rows[indice].Cells["FijoParti"].Value.ToString();
                    txtCeluParti.Text = dgvColegiados.Rows[indice].Cells["CeluParti"].Value.ToString();
                    txtDomLabor.Text = dgvColegiados.Rows[indice].Cells["DomLabor"].Value.ToString();
                    txtLocalLabor.Text = dgvColegiados.Rows[indice].Cells["idLocalLabor"].Value.ToString();
                    txtDeptoLabor.Text = dgvColegiados.Rows[indice].Cells["idDeptoLabor"].Value.ToString();
                    txtProvLabor.Text = dgvColegiados.Rows[indice].Cells["idProvLabor"].Value.ToString();

                    //***** BUSCO LA LOCALIDAD LABORAL *****
                    local = Convert.ToInt32(txtLocalLabor.Text);
                    localidad = new CN_Localidades().BuscaCodPos(local);
                    lblDetLocalLabor.Text = localidad.ToString();

                    txtFijoLabor.Text = dgvColegiados.Rows[indice].Cells["FijoLabor"].Value.ToString();
                    txtCeluLabor.Text = dgvColegiados.Rows[indice].Cells["CeluLabor"].Value.ToString();
                    dtpFecVenceFianza.Value = Convert.ToDateTime(dgvColegiados.Rows[indice].Cells["Fianza"].Value.ToString());

                    //***** COLOREO LA FIANZA SEGÚN LA FECHA *****
                    lblFechaVence.Text = dtpFecVenceFianza.Value.ToString("dd/MM/yyyy");

                    if (dtpFecVenceFianza.Value <= DateTime.Now)
                    {
                        lblFechaVence.ForeColor = Color.Red;
                        lblVenceFianza.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblFechaVence.ForeColor = Color.Lime;
                        lblVenceFianza.ForeColor = Color.Lime;
                    }

                    txtObs.Text = dgvColegiados.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvColegiados.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvColegiados.Rows[indice].Cells["FechaRegistro"].Value.ToString();

                    //***** BUSCO LA IMAGEN DE CADA COLEGIADO *****
                    id = int.Parse(txtId.Text);
                    byte[] imagenByte = new CN_Colegiados().ObtenerFoto(id, out obtenido);
                    if (obtenido)
                    {
                        picFoto.Image = ByteToImage(imagenByte);
                    }
                    else
                    {
                        picFoto.Image = Image.FromFile("E:\\DBColegMart/Fotos/FotoVacia.png");
                    };
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim()," ",String.Empty);

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

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                row.Visible = true;
            }
        }

        //***** BUSCO Y CARGO LA FOTO DEL MATRICULADO *****
        private void btnFoto_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            id = Convert.ToInt32(txtId.Text);

            OpenFileDialog SelectorImagen = new OpenFileDialog();
            SelectorImagen.InitialDirectory = "E:\\DBColegMart/Fotos";
            SelectorImagen.DefaultExt = "Archivos jpg (*.jpg)|*.jpg|Archivos jpeg (*.jpeg)|*.jpeg|Archivos png (*.png)|*.png|Archivos bmp (*.bmp)|*.bmp";
            SelectorImagen.FilterIndex= 1;
            SelectorImagen.RestoreDirectory = true;
            SelectorImagen.Title = "SELECCIONAR UNA IMAGEN PARA EL COLEGIADO";

            if (SelectorImagen.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(SelectorImagen.FileName);
                picFoto.Image = Image.FromFile(SelectorImagen.FileName);
                bool respuesta = new CN_Colegiados().ActualizarFoto(id, byteimage, out mensaje);

                //if (respuesta) picFoto.Image = ByteToImage(imagenByte);
                if (respuesta) picFoto.Image = ByteToImage(byteimage);
            }
        }

        //***** BUSCO Y CARGO LA FOTO DEL MATRICULADO *****
        public Image ByteToImage(byte[] imagenByte)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenByte, 0, imagenByte.Length);
            Image imagen = new Bitmap(ms);
            return imagen;
        }

        //***** BUSCO LA LOCALIDAD DONDE VIVE EL MATRICULADO *****
        private void btnLocal1_Click(object sender, EventArgs e)
        {
            frmQueryCodPostal CodigoParti = new frmQueryCodPostal("btnLocalParti");
            AddOwnedForm(CodigoParti);
            CodigoParti.ShowDialog();
        }

        //***** BUSCO LA LOCALIDAD DONDE TRABAJA EL MATRICULADO *****
        private void btnLocal2_Click(object sender, EventArgs e)
        {
            frmQueryCodPostal CodigoLabor = new frmQueryCodPostal("btnLocalLabor");
            AddOwnedForm(CodigoLabor);
            CodigoLabor.ShowDialog();
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvColegiados.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvColegiados.Rows[i].Cells["Fianza"].Value);

                if (dateFecha.Date <= DateTime.Now.Date)
                {
                    dgvColegiados.Rows[i].Cells["Fianza"].Style.ForeColor = Color.Black;
                    dgvColegiados.Rows[i].Cells["Fianza"].Style.BackColor = Color.DarkOrange;
                }
            }
        }

        //***** BUSCO NUEVO NÚMERO DE MATRÍCULA DE UN COLEGIADO NUEVO MAYOR A 79000 *****
        private void BuscoMatricula()
        {
            string mensaje = string.Empty;
            string respuesta = new CN_Colegiados().SinMatricula(nromatri, out mensaje);
            txtMatricula.Text = respuesta;
            lblMatricula.Text = txtMatricula.Text;
        }

        //***** COLOCO UNA MATRÍCULA DESPUÉS DEL JURAMENTO A PARTIR DEL ÚLTIMO EXISTENTE *****
        private void btnMatricula_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            string respuesta = new CN_Colegiados().AsignarMatricula(nromatri, out mensaje);
            txtMatricula.Text = respuesta;
            lblMatricula.Text = txtMatricula.Text;
        }
    }
}
