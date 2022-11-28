using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPermisos : Form
    {
        CN_Permisos cNPermisos = new CN_Permisos();
        CN_Usuarios cNUsuarios = new CN_Usuarios();
        CN_Botones cNBotones = new CN_Botones();
        private string respuesta;

        public frmPermisos()
        {
            InitializeComponent();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = VarGlobales.NombreUsuario;

            ListarBotones();
            ListarUsuarios();

        }

        //***** CARGO EL COMBO DE BOTONES *****
        private void ListarBotones()
        {
            List<CE_Botones> ListaBoton = new CN_Botones().Listar();

            cboBotones.Items.Clear();
            cboBotones.DataSource = ListaBoton;
            cboBotones.DisplayMember = "Detalle";
            cboBotones.ValueMember = "id_Boton";
        }

        //***** CARGO EL COMBO DE USUARIOS *****
        private void ListarUsuarios()
        {
            List<CE_Usuarios> ListaUser = new CN_Usuarios().Listar();

            cboUsuarios.Items.Clear();
            cboUsuarios.DataSource = ListaUser;
            cboUsuarios.DisplayMember = "Usuario";
            cboUsuarios.ValueMember = "id_Usuario";
        }

        //***** METODO PARA REGISTRAR LOS PERMISOS *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Mensaje += "DESEA REGISTRAR ESTE PERMISO...???";
            frmMsgBox msg = new frmMsgBox(Mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Permisos cEPermisos = new CE_Permisos()
                {
                    id_Permiso = Convert.ToInt32(txtId.Text),
                    OUsuario = cboUsuarios.ValueMember,
                    OBoton = cboBotones.ValueMember,
                    UserRegistro = VarGlobales.NombreUsuario
                };

                //***** SI EL ID DEL PERMISO = 0 REGISTRA, SINO EDITA *****
                if (cEPermisos.id_Permiso == 0)
                {
                    int idPermiso = new CN_Permisos().Registrar(cEPermisos, out Mensaje);

                    if (idPermiso != 0)
                    {
                        dgvPermisos.Rows.Add(new object[] { "", idPermiso, cboUsuarios.ValueMember, cboBotones.ValueMember, txtUserRegistro.Text });
                        Limpiar();
                    }
                    else
                    {
                        Mensaje += "VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(Mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
                else
                {
                    bool resultado = new CN_Permisos().Editar(cEPermisos, out Mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvPermisos.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Boton"].Value = txtIndice.Text;
                        row.Cells["Nombre"].Value = cboUsuarios.ValueMember;
                        row.Cells["Detalle"].Value = cboBotones.ValueMember;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;

                        Limpiar();
                    }
                    else
                    {
                        Mensaje += "VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(Mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
            }
        }
    }
}
