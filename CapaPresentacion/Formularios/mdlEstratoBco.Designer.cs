
namespace CapaPresentacion.Formularios
{
    partial class mdlEstratoBco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdlEstratoBco));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.dgvEstrato = new System.Windows.Forms.DataGridView();
            this.txtFkLocal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBancos = new System.Windows.Forms.ComboBox();
            this.txtFkProv = new System.Windows.Forms.TextBox();
            this.txtFkDepto = new System.Windows.Forms.TextBox();
            this.txtIdCodPos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Causal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fec_Conc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_UserRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstrato)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1152, 40);
            this.pnlTitulo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultar Movimientos de Bancos";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.dgvEstrato);
            this.pnlDeck.Controls.Add(this.txtFkLocal);
            this.pnlDeck.Controls.Add(this.label6);
            this.pnlDeck.Controls.Add(this.cboBancos);
            this.pnlDeck.Controls.Add(this.txtFkProv);
            this.pnlDeck.Controls.Add(this.txtFkDepto);
            this.pnlDeck.Controls.Add(this.txtIdCodPos);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.txtIndice);
            this.pnlDeck.Controls.Add(this.txtUserRegistro);
            this.pnlDeck.Controls.Add(this.txtId);
            this.pnlDeck.Controls.Add(this.btnLimpiar);
            this.pnlDeck.Controls.Add(this.btnBuscar);
            this.pnlDeck.Controls.Add(this.txtFiltro);
            this.pnlDeck.Controls.Add(this.cboBusqueda);
            this.pnlDeck.Controls.Add(this.label10);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.label8);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(1152, 527);
            this.pnlDeck.TabIndex = 14;
            // 
            // dgvEstrato
            // 
            this.dgvEstrato.AllowUserToAddRows = false;
            this.dgvEstrato.AllowUserToDeleteRows = false;
            this.dgvEstrato.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEstrato.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEstrato.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvEstrato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEstrato.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstrato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEstrato.ColumnHeadersHeight = 30;
            this.dgvEstrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEstrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Numero,
            this.Fecha,
            this.Referencia,
            this.Causal,
            this.Concepto,
            this.Debito,
            this.Credito,
            this.Saldo,
            this.Fec_Conc,
            this.Titular,
            this.Cic,
            this.C_UserRegistro,
            this.C_FechaRegistro,
            this.Seleccionar});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEstrato.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvEstrato.EnableHeadersVisualStyles = false;
            this.dgvEstrato.GridColor = System.Drawing.Color.Gray;
            this.dgvEstrato.Location = new System.Drawing.Point(17, 124);
            this.dgvEstrato.MultiSelect = false;
            this.dgvEstrato.Name = "dgvEstrato";
            this.dgvEstrato.ReadOnly = true;
            this.dgvEstrato.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstrato.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvEstrato.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvEstrato.Size = new System.Drawing.Size(997, 381);
            this.dgvEstrato.TabIndex = 87;
            // 
            // txtFkLocal
            // 
            this.txtFkLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFkLocal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFkLocal.Enabled = false;
            this.txtFkLocal.ForeColor = System.Drawing.Color.White;
            this.txtFkLocal.Location = new System.Drawing.Point(584, 6);
            this.txtFkLocal.Name = "txtFkLocal";
            this.txtFkLocal.Size = new System.Drawing.Size(35, 16);
            this.txtFkLocal.TabIndex = 86;
            this.txtFkLocal.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 85;
            this.label6.Text = "Banco:";
            // 
            // cboBancos
            // 
            this.cboBancos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboBancos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBancos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBancos.ForeColor = System.Drawing.Color.White;
            this.cboBancos.FormattingEnabled = true;
            this.cboBancos.Location = new System.Drawing.Point(101, 53);
            this.cboBancos.Name = "cboBancos";
            this.cboBancos.Size = new System.Drawing.Size(194, 25);
            this.cboBancos.TabIndex = 2;
            this.cboBancos.SelectedIndexChanged += new System.EventHandler(this.cboBancos_SelectedIndexChanged);
            // 
            // txtFkProv
            // 
            this.txtFkProv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFkProv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFkProv.Enabled = false;
            this.txtFkProv.ForeColor = System.Drawing.Color.White;
            this.txtFkProv.Location = new System.Drawing.Point(667, 6);
            this.txtFkProv.Name = "txtFkProv";
            this.txtFkProv.Size = new System.Drawing.Size(35, 16);
            this.txtFkProv.TabIndex = 83;
            this.txtFkProv.Visible = false;
            // 
            // txtFkDepto
            // 
            this.txtFkDepto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFkDepto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFkDepto.Enabled = false;
            this.txtFkDepto.ForeColor = System.Drawing.Color.White;
            this.txtFkDepto.Location = new System.Drawing.Point(626, 6);
            this.txtFkDepto.Name = "txtFkDepto";
            this.txtFkDepto.Size = new System.Drawing.Size(35, 16);
            this.txtFkDepto.TabIndex = 82;
            this.txtFkDepto.Visible = false;
            // 
            // txtIdCodPos
            // 
            this.txtIdCodPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIdCodPos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdCodPos.Enabled = false;
            this.txtIdCodPos.ForeColor = System.Drawing.Color.White;
            this.txtIdCodPos.Location = new System.Drawing.Point(543, 6);
            this.txtIdCodPos.Name = "txtIdCodPos";
            this.txtIdCodPos.Size = new System.Drawing.Size(35, 16);
            this.txtIdCodPos.TabIndex = 81;
            this.txtIdCodPos.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1028, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 358);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.Aqua;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 30;
            this.btnGuardar.Location = new System.Drawing.Point(10, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(70, 53);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            this.btnClear.IconColor = System.Drawing.Color.Aqua;
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.IconSize = 30;
            this.btnClear.Location = new System.Drawing.Point(10, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 53);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Limpiar";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.MailForward;
            this.btnSalir.IconColor = System.Drawing.Color.Aqua;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 30;
            this.btnSalir.Location = new System.Drawing.Point(10, 288);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtIndice
            // 
            this.txtIndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIndice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndice.Enabled = false;
            this.txtIndice.ForeColor = System.Drawing.Color.White;
            this.txtIndice.Location = new System.Drawing.Point(473, 6);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(65, 16);
            this.txtIndice.TabIndex = 75;
            this.txtIndice.Visible = false;
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(402, 6);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(65, 16);
            this.txtUserRegistro.TabIndex = 74;
            this.txtUserRegistro.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(347, 6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 16);
            this.txtId.TabIndex = 60;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Aqua;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 25;
            this.btnLimpiar.Location = new System.Drawing.Point(789, 90);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(28, 28);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Aqua;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 25;
            this.btnBuscar.Location = new System.Drawing.Point(742, 90);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 28);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltro.ForeColor = System.Drawing.Color.White;
            this.txtFiltro.Location = new System.Drawing.Point(533, 93);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(199, 23);
            this.txtFiltro.TabIndex = 6;
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBusqueda.ForeColor = System.Drawing.Color.White;
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(387, 92);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(140, 25);
            this.cboBusqueda.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 73;
            this.label10.Text = "Buscar por:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(13, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 22);
            this.label9.TabIndex = 72;
            this.label9.Text = "Seleccionar Banco";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(17, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 22);
            this.label8.TabIndex = 54;
            this.label8.Text = "Lista de Movimientos";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Visible = false;
            // 
            // Fecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "FECHA";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 80;
            // 
            // Referencia
            // 
            this.Referencia.HeaderText = "REFERENCIA";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            // 
            // Causal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Causal.DefaultCellStyle = dataGridViewCellStyle4;
            this.Causal.HeaderText = "CAUSAL";
            this.Causal.Name = "Causal";
            this.Causal.ReadOnly = true;
            this.Causal.Width = 80;
            // 
            // Concepto
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Concepto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Concepto.HeaderText = "CONCEPTO";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Width = 300;
            // 
            // Debito
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Debito.DefaultCellStyle = dataGridViewCellStyle6;
            this.Debito.HeaderText = "DEBITO";
            this.Debito.Name = "Debito";
            this.Debito.ReadOnly = true;
            // 
            // Credito
            // 
            this.Credito.HeaderText = "CREDITO";
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            // 
            // Saldo
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle7;
            this.Saldo.HeaderText = "SALDO";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // Fec_Conc
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Fec_Conc.DefaultCellStyle = dataGridViewCellStyle8;
            this.Fec_Conc.HeaderText = "FEC_CONC";
            this.Fec_Conc.Name = "Fec_Conc";
            this.Fec_Conc.ReadOnly = true;
            this.Fec_Conc.Width = 80;
            // 
            // Titular
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Titular.DefaultCellStyle = dataGridViewCellStyle9;
            this.Titular.HeaderText = "TITULAR";
            this.Titular.Name = "Titular";
            this.Titular.ReadOnly = true;
            // 
            // Cic
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = "-";
            this.Cic.DefaultCellStyle = dataGridViewCellStyle10;
            this.Cic.HeaderText = "CIC";
            this.Cic.Name = "Cic";
            this.Cic.ReadOnly = true;
            this.Cic.Width = 50;
            // 
            // C_UserRegistro
            // 
            this.C_UserRegistro.HeaderText = "UserRegistro";
            this.C_UserRegistro.Name = "C_UserRegistro";
            this.C_UserRegistro.ReadOnly = true;
            this.C_UserRegistro.Visible = false;
            // 
            // C_FechaRegistro
            // 
            this.C_FechaRegistro.HeaderText = "FechaRegistro";
            this.C_FechaRegistro.Name = "C_FechaRegistro";
            this.C_FechaRegistro.ReadOnly = true;
            this.C_FechaRegistro.Visible = false;
            // 
            // Seleccionar
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Red;
            this.Seleccionar.DefaultCellStyle = dataGridViewCellStyle11;
            this.Seleccionar.DividerWidth = 3;
            this.Seleccionar.HeaderText = "X";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 25;
            // 
            // mdlEstratoBco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1152, 567);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mdlEstratoBco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA DE ESTRATO DE BANCOS";
            this.Load += new System.EventHandler(this.mdlEstratoBco_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstrato)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.TextBox txtFkLocal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBancos;
        private System.Windows.Forms.TextBox txtFkProv;
        private System.Windows.Forms.TextBox txtFkDepto;
        private System.Windows.Forms.TextBox txtIdCodPos;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.TextBox txtId;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvEstrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Causal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fec_Conc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cic;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_UserRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seleccionar;
    }
}