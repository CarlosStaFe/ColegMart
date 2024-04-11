using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlEstratoBco : Form
    {
        CN_Debitos cN_Debitos = new CN_Debitos();

        string NameBoton;

        public mdlEstratoBco(string NombreBoton)
        {
            InitializeComponent();
            NameBoton = NombreBoton;
        }

        private void mdlEstratoBco_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            Limpiar();

            CargoCboBancos();

            cboBancos.Select();

        }

        //***** CARGO EL COMBO DE BANCOS *****
        private void CargoCboBancos()
        {
            List<CE_Bancos> ListaBancos = new CN_Bancos().ListaBancos();

            cboBancos.Items.Clear();
            cboBancos.DataSource = ListaBancos;
            cboBancos.DisplayMember = "Nombre";
            cboBancos.ValueMember = "id_Bco";
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            cboBancos.Text = "";

            CargoCboBancos();

            txtId.Text = "0";
            cboBancos.Select();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvEstrato.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvEstrato.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR EL DVG *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvEstrato.Rows)
            {
                row.Visible = true;
            }
        }

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR LA PANTALLA *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR LA PANTALLA *****
        private void cboBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();

            List<CE_Estratos> ListaEstratos = new CN_Estratos().ListaEstrato();

            //*****CARGO EL DGV *****
            foreach (CE_Estratos item in ListaEstratos)
            {
                dgvEstrato.Rows.Add(new object[] { item.id_Estra, item.NroBanco, item.Fecha, item.Referencia, item.Causal, item.Concepto, item.Debito, item.Credito, item.Saldo, item.FechaConci, item.Titular, item.NroCic });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvEstrato.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            cboBancos.Select();

        }
    }
}
