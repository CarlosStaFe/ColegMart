using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPadronSocie : Form
    {
        string detalle, localidad;
        string comando;
        int flag, contador;

        DateTime fecha;

        public frmPadronSocie()
        {
            InitializeComponent();
        }

        private void frmPadronSocie_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            contador = 0;
            cboEstado.Text = "TODAS";
            cboTipo.Text = "TODAS";
            cboOrden.Text = "NUMERO";

            int idPadron = new CN_PadronSoc().Blanquear();

            cboEstado.Select();
        }

        //***** PROCESO PARA FILTRAR LOS ELEMENTOS A IMPRIMIR *****
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            flag = 0;
            detalle = "Lista de sociedades - ";
            comando = "SELECT * FROM Sociedades ";

            //***** ESTADOS *****
            if (cboEstado.Text == "TODAS")
            {
                detalle = detalle + "Estado: TODAS * ";
            }
            else
            {
                detalle = detalle + "Estado : " + cboEstado.Text + " * ";
                comando = comando + "WHERE Estado = '" + cboEstado.Text + "' ";
                flag = 1;
            }

            //***** CATEGORÍA *****
            if (cboTipo.Text == "TODAS")
            {
                detalle = detalle + "Categoría: TODAS * ";
            }
            else
            {
                detalle = detalle + "Categoría: " + cboTipo.Text + " * ";
                if (flag == 0)
                {
                    comando = comando + "WHERE Tipo = '" + cboTipo.Text + "' ";
                    flag = 1;
                }
                else
                {
                    comando = comando + "AND Tipo = '" + cboTipo.Text + "' ";
                }
            }

            //***** ORDENADOS POR *****
            if (cboOrden.Text == "NUMERO")
            {
                detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                comando = comando + "ORDER BY Numero ";
            }
            else
            {
                detalle = detalle + "Ordenado por " + cboOrden.Text + " * ";
                comando = comando + "ORDER BY Nombre ";
            }

            //***** GENERO EL ARCHIVO PARA EL PADRÒN *****

            ArmarPadron();

            //***** IMPRIMO SEGÚN EL TIPO DE LISTADO QUE SE ELIGIÓ *****
            mdlPadronSocie Padron = new mdlPadronSocie();
            Padron.detalle = detalle;
            Padron.user = txtUserRegistro.Text;
            Padron.ShowDialog();

            Limpiar();
        }

        //***** PROCEDIMIENTO PARA CREAR LA LISTA DE SOCIEDADES PARA EL PADRÓN *****
        private void ArmarPadron()
        {
            string mensaje = string.Empty;
            contador = 0;

            List<CE_Sociedades> ListaPadron = new CN_Sociedades().ListaPadron(comando);

            foreach (CE_Sociedades item in ListaPadron)
            {
                contador = contador + 1;

                localidad = new CN_CodigosPostales().BuscaCodPos(item.idCodPostal);

                CE_PadronSoc cEPadronSoc = new CE_PadronSoc()
                {
                    Contador = contador,
                    Numero = item.Numero,
                    Nombre = item.Nombre,
                    TipoDoc = item.TipoDoc,
                    Cuit = Convert.ToDouble(item.Cuit),
                    Domicilio = item.Domicilio + " - " + localidad,
                    idCodPostal = item.idCodPostal,
                    idLocal = item.idLocal,
                    idDepto = item.idDepto,
                    idProv = item.idProv,
                    Telefono = item.Telefono,
                    Email = item.Email,
                    Tipo = item.Tipo,
                    Estado = item.Estado,
                    FechaEstado = item.FechaEstado,
                    Inscripcion = item.Inscripcion,
                    Semestral = item.Semestral,
                    Martillero1 = item.Martillero1,
                    Nombre1 = "-",
                    Fianza1 = Convert.ToDateTime("01/01/1900"),
                    Martillero2 = item.Martillero2,
                    Nombre2 = "-",
                    Fianza2 = Convert.ToDateTime("01/01/1900"),
                    Martillero3 = item.Martillero3,
                    Nombre3 = "-",
                    Fianza3 = Convert.ToDateTime("01/01/1900"),
                    Martillero4 = item.Martillero4,
                    Nombre4 = "-",
                    Fianza4 = Convert.ToDateTime("01/01/1900"),
                    Obs = item.Obs,
                    UserRegistro = txtUserRegistro.Text,
                    FechaRegistro = item.FechaRegistro
                };

                int idPadron = new CN_PadronSoc().Registrar(cEPadronSoc, out mensaje);
            }
        }


    }
}
