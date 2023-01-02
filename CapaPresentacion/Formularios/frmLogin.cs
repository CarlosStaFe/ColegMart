using CapaNegocio;
using CapaPresentacion.Formularios;
using System;
using System.Windows.Forms;

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
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    CN_Usuarios usuario = new CN_Usuarios();
                    var validarLogin = usuario.LoginUser(txtUsuario.Text, txtPassword.Text);

                    if (validarLogin == true)
                    {
                        frmMenuPpal form = new frmMenuPpal();
                        form.Show();
                        Hide();
                        form.FormClosing += CerrarForm;
                    }
                    else
                    {
                        frmMsgBox msg = new frmMsgBox("USUARIO Y CONTRASEÑA ERRÓNEO...!!! VERIFIQUE", "info", 1);
                        msg.ShowDialog();
                        txtUsuario.Clear();
                        txtPassword.Clear();
                        Show();
                        txtUsuario.Select();
                    }
                }
                else
                {
                    frmMsgBox msg = new frmMsgBox("DEBE INGRESAR UNA CONTRASEÑA...!!! VERIFIQUE", "info", 1);
                    msg.ShowDialog();
                }
            }
            else
            {
                frmMsgBox msg = new frmMsgBox("DEBE INGRESAR UN USUARIO EXISTENTE...!!! VERIFIQUE", "info", 1);
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
            txtUsuario.Select();
            Show();
        }
    }
}
