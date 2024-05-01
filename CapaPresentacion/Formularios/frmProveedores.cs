using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Formularios;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProveedores : Form
    {
        SoloNumeros validar = new SoloNumeros();

        private string respuesta, localidad, nrosoc, fecha, estadosoc, fechafianza;
        private int idcodpos, nuevoNro;

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Proveedores> ListaProv = new CN_Proveedores().ListaProv();

            //***** CARGO EL DGV *****
            foreach (CE_Proveedores item in ListaProv)
            {
                dgvProveedores.Rows.Add(new object[] { "", item.id_Prov, item.Numero, item.RazonSocial, item.Titular, item.Domicilio, item.idCodPos, item.idLocal, item.idDepto, item.idProv,
                                                item.TipoIva, item.Cuit, item.Telefono, item.IngBrutos, item.Email, item.Saldo, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvProveedores.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtRazonSocial.Select();
        }

        //***** PROCEDIMIENTO PARA COLOCAR EL ÍCONO EN CADA RENGLÓN *****
        private void dgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvProveedores.Rows[indice].Cells["id_Prov"].Value.ToString();
                    txtNumero.Text = dgvProveedores.Rows[indice].Cells["Num"].Value.ToString();
                    lblNumero.Text = txtNumero.Text;
                    txtRazonSocial.Text = dgvProveedores.Rows[indice].Cells["Razon"].Value.ToString();
                    txtTitular.Text = dgvProveedores.Rows[indice].Cells["Titular"].Value.ToString();
                    txtDomicilio.Text = dgvProveedores.Rows[indice].Cells["Domicilio"].Value.ToString();
                    txtCodPos.Text = dgvProveedores.Rows[indice].Cells["idCodPostal"].Value.ToString();
                    txtLocal.Text = dgvProveedores.Rows[indice].Cells["idLocal"].Value.ToString();
                    txtDepto.Text = dgvProveedores.Rows[indice].Cells["idDepto"].Value.ToString();
                    txtProv.Text = dgvProveedores.Rows[indice].Cells["idProv"].Value.ToString();
                    cboTipo.Text = dgvProveedores.Rows[indice].Cells["Tipo"].Value.ToString();
                    txtCuit.Text = dgvProveedores.Rows[indice].Cells["Cuit"].Value.ToString();
                    txtTelefono.Text = dgvProveedores.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtIngBrutos.Text = dgvProveedores.Rows[indice].Cells["Ib"].Value.ToString();
                    txtEmail.Text = dgvProveedores.Rows[indice].Cells["Email"].Value.ToString();
                    txtObs.Text = dgvProveedores.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvProveedores.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvProveedores.Rows[indice].Cells["FechaRegistro"].Value.ToString();

                    //***** BUSCO LA LOCALIDAD DEL PROVEEDOR *****
                    idcodpos = Convert.ToInt32(txtCodPos.Text);
                    localidad = new CN_CodigosPostales().BuscaCodPos(idcodpos);
                    lblLocalidad.Text = localidad.ToString();
                }
            }
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvProveedores.Rows.Count; i++)
            {
            }
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE PROVEEDOR...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                if (txtId.Text == "0")
                {
                    string nuevoNro = new CN_Proveedores().AsignarNumero(nrosoc, out mensaje);
                    txtNumero.Text = nuevoNro;
                    lblNumero.Text = txtNumero.Text;
                }

                CE_Proveedores cE_Proveedores = new CE_Proveedores()
                {
                    id_Prov = Convert.ToInt32(txtId.Text),
                    Numero = Convert.ToInt32(txtNumero.Text),
                    RazonSocial = txtRazonSocial.Text,
                    Titular = txtTitular.Text,
                    Domicilio = txtDomicilio.Text,
                    idCodPos = Convert.ToInt32(txtCodPos.Text),
                    idLocal = Convert.ToInt32(txtLocal.Text),
                    idDepto = Convert.ToInt32(txtDepto.Text),
                    idProv = Convert.ToInt32(txtProv.Text),
                    TipoIva = cboTipo.Text,
                    Cuit = txtCuit.Text,
                    Telefono = txtTelefono.Text,
                    IngBrutos = txtIngBrutos.Text,
                    Email = txtEmail.Text,
                    Saldo = 0,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //***** SI EL ID DEL PROVEEDOR = 0 REGISTRA, SINO EDITA *****
                if (cE_Proveedores.id_Prov == 0)
                {
                    int idProv = new CN_Proveedores().Registrar(cE_Proveedores, out mensaje);

                    if (idProv != 0)
                    {
                        dgvProveedores.Rows.Add(new object[] {"",idProv,txtNumero.Text,txtRazonSocial.Text,txtTitular.Text,txtDomicilio.Text,txtCodPos.Text,txtLocal.Text,txtDepto.Text,
                                                  txtProv.Text,cboTipo.Text,txtTelefono.Text,txtIngBrutos.Text,txtEmail.Text,0,txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text});
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
                    bool resultado = new CN_Proveedores().Editar(cE_Proveedores, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvProveedores.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Prov"].Value = txtId.Text;
                        row.Cells["Num"].Value = txtNumero.Text;
                        row.Cells["Razon"].Value = txtRazonSocial.Text;
                        row.Cells["Titular"].Value = txtTitular.Text;
                        row.Cells["Domicilio"].Value = txtDomicilio.Text;
                        row.Cells["idCodPostal"].Value = txtCodPos.Text;
                        row.Cells["idLocal"].Value = txtLocal.Text;
                        row.Cells["idDepto"].Value = txtDepto.Text;
                        row.Cells["idProv"].Value = txtProv.Text;
                        row.Cells["Tipo"].Value = cboTipo.Text;
                        row.Cells["Cuit"].Value = txtCuit.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["Ib"].Value = txtIngBrutos.Text;
                        row.Cells["Email"].Value = txtEmail.Text;
                        row.Cells["Saldo"].Value = 0;
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
            txtNumero.Text = string.Empty;
            lblNumero.Text = "-";
            txtRazonSocial.Text = string.Empty;
            txtTitular.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtCodPos.Text = string.Empty;
            txtLocal.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtProv.Text = string.Empty;
            cboTipo.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtIngBrutos.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtObs.Text = string.Empty;

            txtRazonSocial.Select();
        }

        //***** BUSCO LA LOCALIDAD DEL PROVEEDOR *****
        private void btnLocalSoc_Click(object sender, EventArgs e)
        {
            mdlCodPostal LocalProv = new mdlCodPostal("btnLocalProv");
            AddOwnedForm(LocalProv);
            LocalProv.ShowDialog();
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvProveedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProveedores.Rows)
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
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                row.Visible = true;
            }
        }

        //***** VALIDO QUE SE INGRESE UN NUMERO EN EL CUIT *****
        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** VALIDO QUE SE INGRESE UN NUMERO EN EL ING BRUTOS *****
        private void txtIngBrutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

    }
}
