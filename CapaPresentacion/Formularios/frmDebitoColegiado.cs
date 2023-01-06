using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class frmDebitoColegiado : Form
    {
        CN_Adebitar cN_Adebitar = new CN_Adebitar();
        private string respuesta;

        public frmDebitoColegiado()
        {
            InitializeComponent();
        }

        private void frmDebitoColegiado_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargoCboDebitos();
            //Limpiar();

            List<CE_Adebitar> ListaAdebitar = new CN_Adebitar().ListaAdebitar();

            //*****CARGO EL DGV *****
            foreach (CE_Adebitar item in ListaAdebitar)
            {
                dgvAdebitar.Rows.Add(new object[] { "", item.id_Debitar, item.fk_idColeg, item.Matricula, item.Nombres, item.fk_idDebito, item.Codigo, item.Detalle, item.Activo, item.Obs });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvAdebitar.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtMatricula.Select();
        }

        //***** CARGO EL COMBO DE DÉBITOS *****
        private void CargoCboDebitos()
        {
            List<CE_Debitos> ListaDebitos = new CN_Debitos().ListaDebito();

            cboDebitos.Items.Clear();
            cboDebitos.DataSource = ListaDebitos;
            cboDebitos.DisplayMember = "Detalle";
            cboDebitos.ValueMember = "id_Debito";
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
    }
}
