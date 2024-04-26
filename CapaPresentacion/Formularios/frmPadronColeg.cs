using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPadronColeg : Form
    {
        string detalle;
        string comando;
        int flag, meses, contador;
        DateTime fecha;

        public frmPadronColeg()
        {
            InitializeComponent();
        }

        private void frmPadronColeg_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargoCboLocalidad();
            CargoCboDeptos();
            CargoCboProvincia();
            Limpiar();
        }

        //***** CARGO EL COMBO DE LOCALIDADES *****
        private void CargoCboLocalidad()
        {
            cboLocalidad.Items.Clear();

            List<CE_Localidades> ListaLocal = new CN_Localidades().ListaLocal();

            cboLocalidad.DataSource = ListaLocal;
            cboLocalidad.DisplayMember = "Localidad";
            cboLocalidad.ValueMember = "id_Local";
        }

        //***** CARGO EL COMBO DE DEPARTAMENTOS *****
        private void CargoCboDeptos()
        {
            cboDepartamento.Items.Clear();

            List<CE_Departamentos> ListaDeptos = new CN_Departamentos().ListaDepto();

            cboDepartamento.DataSource = ListaDeptos;
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "id_Depto";
        }

        //***** CARGO EL COMBO DE PROVINCIAS *****
        private void CargoCboProvincia()
        {
            cboProvincia.Items.Clear();

            List<CE_Provincias> ListaProvincia = new CN_Provincias().ListaProvincia();

            cboProvincia.DataSource = ListaProvincia;
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.ValueMember = "id_Prov";
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            Limpiar();
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            contador = 0;
            rdbComun.Checked = true;
            cboEstado.Text = "TODOS";
            cboSexo.Text = "TODOS";
            cboCategoria.Text = "TODOS";
            cboOrden.Text = "MATRICULA";
            chbFianza.Checked = false;
            dtpFianza.Text = DateTime.Now.ToString("dd/MM/yyyy");
            nudAnios.Value = 0;
            nudMeses.Value = 0;
            dtpControl.Text = "1/1/1900";
            chbLocalidad.Checked = false;
            cboLocalidad.Text = "TODOS";
            cboLocalidad.Enabled = false;
            chbDepartamento.Checked = false;
            cboDepartamento.Text = "TODOS";
            cboDepartamento.Enabled = false;
            chbProvincia.Checked = false;
            cboProvincia.Text = "TODOS";
            cboProvincia.Enabled = false;
            meses = 0;

            int idPadron = new CN_PadronColeg().Blanquear();

            rdbComun.Select();
        }

        //***** PROCESO PARA CONTROLAR LAS OPCIONES DE LOCALIDAD, DEPARTAMENTO Y PROVINCIA *****
        private void chbLocalidad_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLocalidad.Checked)
            {
                chbDepartamento.Checked = false;
                chbProvincia.Checked = false;
                cboLocalidad.Enabled = true;
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDepartamento.Text = "TODOS";
                cboProvincia.Text = "TODOS";
            }
        }

        private void chbDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDepartamento.Checked)
            {
                chbLocalidad.Checked = false;
                chbProvincia.Checked = false;
                cboLocalidad.Enabled = false;
                cboDepartamento.Enabled = true;
                cboProvincia.Enabled = false;
                cboLocalidad.Text = "TODOS";
                cboProvincia.Text = "TODOS";
            }
        }

        private void chbProvincia_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProvincia.Checked)
            {
                chbDepartamento.Checked = false;
                chbLocalidad.Checked = false;
                cboLocalidad.Enabled = false;
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = true;
                cboDepartamento.Text = "TODOS";
                cboLocalidad.Text = "TODOS";
            }
        }

        //***** PROCESO PARA FILTRAR LOS ELEMENTOS A IMPRIMIR *****
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            flag = 0;
            detalle = "Lista de colegiados - ";
            comando = "SELECT * FROM Colegiados ";

            //***** ESTADOS *****
            if (cboEstado.Text == "TODOS")
            {
                detalle = detalle + "Estado: TODOS * ";
            }
            else
            {
                detalle = detalle + "Estado : " + cboEstado.Text + " * ";
                comando = comando + "WHERE Estado = '" + cboEstado.Text + "' ";
                flag = 1;
            }

            //***** SEXO *****
            if (cboSexo.Text == "TODOS")
            {
                detalle = detalle + "Sexo: TODOS * ";
            }
            else
            {
                detalle = detalle + "Sexo : " + cboSexo.Text + " * ";
                if (flag == 0)
                {
                    comando = comando + "WHERE Sexo = '" + cboSexo.Text + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND Sexo = '" + cboSexo.Text + "' ";
                }
            }

            //***** CATEGORÍA *****
            if (cboCategoria.Text == "TODOS")
            {
                detalle = detalle + "Categoría: TODOS * ";
            }
            else
            {
                detalle = detalle + "Categoría: " + cboCategoria.Text + " * ";
                if (flag == 0)
                {
                    comando = comando + "WHERE Categoria = '" + cboCategoria.Text + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND Categoria = '" + cboCategoria.Text + "' ";
                }
            }

            //***** FIANZA VENCIDA *****
            if (chbFianza.Checked)
            {
                detalle = detalle + "FIANZA VENCIDA AL: " + dtpFianza.Text + " * ";

                if (flag == 0)
                {
                    comando = comando + "WHERE FecVenceFianza <= '" + dtpFianza.Text + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND FecVenceFianza <= '" + dtpFianza.Text + "' ";
                }
            }

            //***** ANTIGUEDAD *****
            if (nudAnios.Value != 0 || nudMeses.Value != 0)
            {
                detalle = detalle + "Antiguedad al: " + dtpControl.Text + " * ";

                if (flag == 0)
                {
                    comando = comando + "WHERE Juramento <= '" + dtpControl.Text + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND Juramento <= '" + dtpControl.Text + "' ";
                }
            }

            //***** FILTRO POR LOCALIDAD *****
            if (cboLocalidad.Text != "TODOS")
            {
                detalle = detalle + "Localidad: " + cboLocalidad.Text + " * ";

                if (flag == 0)
                {
                    comando = comando + "WHERE idLocalParti = '" + cboLocalidad.ValueMember + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND idLocalParti = '" + cboLocalidad.ValueMember + "' ";
                }
            }

            //***** FILTRO POR DEPARTAMENTO *****
            if (cboDepartamento.Text != "TODOS")
            {
                detalle = detalle + "Departamento: " + cboDepartamento.Text + " * ";

                if (flag == 0)
                {
                    comando = comando + "WHERE idDeptoParti = '" + cboDepartamento.ValueMember + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND idDeptoParti = '" + cboDepartamento.ValueMember + "' ";
                }
            }

            //***** FILTRO POR PROVINCIA *****
            if (cboProvincia.Text != "TODOS")
            {
                detalle = detalle + "Provincia: " + cboProvincia.Text + " * ";

                if (flag == 0)
                {
                    comando = comando + "WHERE idProvParti = '" + cboProvincia.ValueMember + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND idProvParti = '" + cboProvincia.ValueMember + "' ";
                }
            }

            //***** FILTRO LAS MATRÍCULAS MAYORES A 80000 *****
            if (flag == 0)
            {
                comando = comando + "WHERE Matricula < 80000 ";
                flag = 1;
            }
            else
            {
                comando = comando + "AND Matricula < 80000 ";
            }

            //***** ORDENADOS POR *****
            if (cboOrden.Text == "APELLIDO")
            {
                detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                comando = comando + "ORDER BY ApelNombres ";
            }
            else
            {
                detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                comando = comando + "ORDER BY Matricula ";
            }

            //***** GENERO EL ARCHIVO PARA EL PADRÒN *****

            ArmarPadron();

            //***** IMPRIMO SEGÚN EL TIPO DE LISTADO QUE SE ELIGIÓ *****

            if (rdbComun.Checked)
            {
                mdlPadColegComun Comun = new mdlPadColegComun();
                Comun.detalle = detalle;
                Comun.user = txtUserRegistro.Text;
                Comun.ShowDialog();
            }

            if (rdbSubasta.Checked)
            {
                mdlPadColegSubasta Subasta = new mdlPadColegSubasta();
                Subasta.detalle = detalle;
                Subasta.user = txtUserRegistro.Text;
                Subasta.ShowDialog();
            }

            if (rdbElecciones.Checked)
            {
                mdlPadColegElecc Elecciones = new mdlPadColegElecc();
                Elecciones.detalle = detalle;
                Elecciones.user = txtUserRegistro.Text;
                Elecciones.ShowDialog();
            }

            Limpiar();
        }

        private void chbFianza_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFianza.Checked)
            {
                dtpFianza.Visible = true;
            }
            else
            {
                dtpFianza.Visible = false;
            }
        }

        //***** CALCULO LA ANTIGUEDAD *****
        private void nudAnios_Click(object sender, EventArgs e)
        {
            CalcularAntiguedad();
        }

        private void nudMeses_Click(object sender, EventArgs e)
        {
            CalcularAntiguedad();
        }

        private void CalcularAntiguedad()
        {
            meses = 0;
            meses = ((Convert.ToInt32(nudAnios.Text) * 12) + Convert.ToInt32(nudMeses.Text)) * -1;
            fecha = Convert.ToDateTime(dtpAntiguedad.Text);
            fecha = fecha.AddMonths(meses);
            dtpControl.Value = fecha;
        }

        //***** PROCEDIMIENTO PARA CREAR LA LISTA DE COLEGIADOS PARA EL PADRÓN *****
        private void ArmarPadron()
        {
            string mensaje = string.Empty;
            contador = 0;

            List<CE_Colegiados> ListaPadron = new CN_Colegiados().ListaPadron(comando);

            foreach (CE_Colegiados item in ListaPadron)
            {
                contador = contador + 1;
                if (item.FecVenceFianza > DateTime.Now)
                {
                    item.FecVenceFianza = Convert.ToDateTime("1/1/1900 00:00:00");
                }

                CE_PadronColeg cEPadronColeg = new CE_PadronColeg()
                {
                    Contador = contador,
                    Matricula = item.Matricula,
                    ApelNombres = item.ApelNombres,
                    ApelMaterno = item.ApelMaterno,
                    FechaNacim = item.FechaNacim,
                    LugarNacim = item.LugarNacim,
                    Nacionalidad = item.Nacionalidad,
                    TipoDoc = item.TipoDoc,
                    NumeroDoc = item.NumeroDoc,
                    Cuit = item.Cuit,
                    Sexo = item.Sexo,
                    EstadoCivil = item.EstadoCivil,
                    Juramento = item.Juramento,
                    Tomo = item.Tomo,
                    Folio = item.Categoria,
                    Categoria = item.Categoria,
                    CodigoIapos = item.CodigoIapos,
                    Email = item.Email,
                    Estado = item.Estado,
                    FecEstado = item.FecEstado,
                    DomParti = item.DomParti,
                    LocalidadParti = new CN_CodigosPostales().BuscaCodPos(item.idCodPosParti),
                    idCodPosParti = item.idCodPosParti,
                    idLocalParti = item.idLocalParti,
                    idDeptoParti = item.idDeptoParti,
                    idProvParti = item.idProvParti,
                    FijoParti = item.FijoParti,
                    CeluParti = item.CeluParti,
                    DomLabor = item.DomLabor,
                    LocalidadLabor = new CN_CodigosPostales().BuscaCodPos(item.idCodPosLabor),
                    idCodPosLabor = item.idCodPosLabor,
                    idLocalLabor = item.idLocalLabor,
                    idDeptoLabor = item.idDeptoLabor,
                    idProvLabor = item.idProvLabor,
                    FijoLabor = item.FijoLabor,
                    CeluLabor = item.CeluLabor,
                    FecVenceFianza = item.FecVenceFianza,
                    Obs = item.Obs,
                    UserRegistro = item.UserRegistro,
                    FechaRegistro = item.FechaRegistro
                };

                int idPadron = new CN_PadronColeg().Registrar(cEPadronColeg, out mensaje);
            }
        }
    }
}
