﻿
namespace CapaPresentacion.Formularios
{
    partial class frmBancos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBancos));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbActivo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.dgvBancos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_Bco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancos)).BeginInit();
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
            this.pnlTitulo.Size = new System.Drawing.Size(737, 40);
            this.pnlTitulo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualización de Bancos";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.txtNombre);
            this.pnlDeck.Controls.Add(this.label3);
            this.pnlDeck.Controls.Add(this.chbActivo);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.dgvBancos);
            this.pnlDeck.Controls.Add(this.txtIndice);
            this.pnlDeck.Controls.Add(this.txtUserRegistro);
            this.pnlDeck.Controls.Add(this.txtId);
            this.pnlDeck.Controls.Add(this.btnLimpiar);
            this.pnlDeck.Controls.Add(this.txtCuit);
            this.pnlDeck.Controls.Add(this.btnBuscar);
            this.pnlDeck.Controls.Add(this.txtFiltro);
            this.pnlDeck.Controls.Add(this.cboBusqueda);
            this.pnlDeck.Controls.Add(this.label10);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.label2);
            this.pnlDeck.Controls.Add(this.label8);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(737, 468);
            this.pnlDeck.TabIndex = 12;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(287, 56);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(296, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 79;
            this.label3.Text = "Nombre:";
            // 
            // chbActivo
            // 
            this.chbActivo.AutoSize = true;
            this.chbActivo.Checked = true;
            this.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbActivo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbActivo.Location = new System.Drawing.Point(611, 57);
            this.chbActivo.Name = "chbActivo";
            this.chbActivo.Size = new System.Drawing.Size(77, 21);
            this.chbActivo.TabIndex = 2;
            this.chbActivo.Text = "Activo?";
            this.chbActivo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(25, 364);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 86);
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
            this.btnGuardar.Location = new System.Drawing.Point(14, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(70, 53);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btnClear.Location = new System.Drawing.Point(303, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 53);
            this.btnClear.TabIndex = 2;
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
            this.btnSalir.Location = new System.Drawing.Point(592, 22);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvBancos
            // 
            this.dgvBancos.AllowUserToAddRows = false;
            this.dgvBancos.AllowUserToDeleteRows = false;
            this.dgvBancos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBancos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBancos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvBancos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBancos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBancos.ColumnHeadersHeight = 30;
            this.dgvBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBancos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.id_Bco,
            this.Cuit,
            this.Nombre,
            this.Activo,
            this.UserRegistro});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBancos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBancos.EnableHeadersVisualStyles = false;
            this.dgvBancos.GridColor = System.Drawing.Color.Gray;
            this.dgvBancos.Location = new System.Drawing.Point(25, 134);
            this.dgvBancos.MultiSelect = false;
            this.dgvBancos.Name = "dgvBancos";
            this.dgvBancos.ReadOnly = true;
            this.dgvBancos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBancos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvBancos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBancos.Size = new System.Drawing.Size(678, 219);
            this.dgvBancos.TabIndex = 71;
            this.dgvBancos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBancos_CellContentClick);
            this.dgvBancos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBancos_CellPainting);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 25;
            // 
            // id_Bco
            // 
            this.id_Bco.HeaderText = "id_Bco";
            this.id_Bco.Name = "id_Bco";
            this.id_Bco.ReadOnly = true;
            this.id_Bco.Visible = false;
            // 
            // Cuit
            // 
            this.Cuit.HeaderText = "CUIT";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "NOMBRE";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 440;
            // 
            // Activo
            // 
            this.Activo.HeaderText = "ACTIVO";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Activo.Width = 55;
            // 
            // UserRegistro
            // 
            this.UserRegistro.HeaderText = "UserRegistro";
            this.UserRegistro.Name = "UserRegistro";
            this.UserRegistro.ReadOnly = true;
            this.UserRegistro.Visible = false;
            // 
            // txtIndice
            // 
            this.txtIndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIndice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndice.Enabled = false;
            this.txtIndice.ForeColor = System.Drawing.Color.White;
            this.txtIndice.Location = new System.Drawing.Point(430, 21);
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
            this.txtUserRegistro.Location = new System.Drawing.Point(356, 21);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(68, 16);
            this.txtUserRegistro.TabIndex = 74;
            this.txtUserRegistro.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(301, 21);
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
            this.btnLimpiar.Location = new System.Drawing.Point(675, 97);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(28, 28);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtCuit
            // 
            this.txtCuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuit.ForeColor = System.Drawing.Color.White;
            this.txtCuit.Location = new System.Drawing.Point(93, 55);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(104, 23);
            this.txtCuit.TabIndex = 0;
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
            this.btnBuscar.Location = new System.Drawing.Point(628, 97);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 28);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.ForeColor = System.Drawing.Color.White;
            this.txtFiltro.Location = new System.Drawing.Point(419, 100);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(199, 23);
            this.txtFiltro.TabIndex = 4;
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBusqueda.ForeColor = System.Drawing.Color.White;
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(273, 99);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(140, 25);
            this.cboBusqueda.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 102);
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
            this.label9.Location = new System.Drawing.Point(89, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 22);
            this.label9.TabIndex = 72;
            this.label9.Text = "Detalle del Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "C.U.I.T.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(21, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 22);
            this.label8.TabIndex = 54;
            this.label8.Text = "Lista de Bancos";
            // 
            // frmBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(737, 508);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACTUALIZACIÓN DE BANCOS";
            this.Load += new System.EventHandler(this.frmBancos_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.DataGridView dgvBancos;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.TextBox txtId;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.TextBox txtCuit;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbActivo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Bco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRegistro;
    }
}