using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Formularios;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Interop;

namespace ColegMart.Formularios
{
    public partial class frmLogin : Form
    {
        public bool opcion = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        //***** PROCEDIMIENTO PARA EL BOTON INGRESAR *****
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //List<CE_Usuarios> Test = new CN_Usuarios().Listar();
            CE_Usuarios cEUsuarios = new CN_Usuarios().Listar().Where(u => u.Usuario == txtUsuario.Text && u.Clave == txtPassword.Text).FirstOrDefault();

            if (cEUsuarios != null)
            {
                frmMenuPpal form = new frmMenuPpal(cEUsuarios);
                form.Show();
                Hide();
                form.FormClosing += CerrarForm;
            }
            else
            {
                frmMsgBox msg = new frmMsgBox("USUARIO Y/O CLAVE NO EXISTENTE...!!! VERIFIQUE", "info", 1);
                msg.ShowDialog();
            }
        }

        //***** PROCEDIMIENTO PARA EL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO PARA EL BOTON DE CERRAR FORMULARIO *****
        private void CerrarForm(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            Show();
        }
    }
}
