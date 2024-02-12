namespace CapaPresentacion.Formularios
{
    partial class frmPadronColeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPadronColeg));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.rdbElecciones = new System.Windows.Forms.RadioButton();
            this.chbProvincia = new System.Windows.Forms.CheckBox();
            this.chbDepartamento = new System.Windows.Forms.CheckBox();
            this.chbLocalidad = new System.Windows.Forms.CheckBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.chbFianza = new System.Windows.Forms.CheckBox();
            this.rdbSubasta = new System.Windows.Forms.RadioButton();
            this.rdbComun = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.cboOrden = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSexo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpControl = new Controles.Controles.DatePicker();
            this.dtpAntiguedad = new Controles.Controles.DatePicker();
            this.dtpFianza = new Controles.Controles.DatePicker();
            this.nudMeses = new System.Windows.Forms.NumericUpDown();
            this.nudAnios = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnios)).BeginInit();
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
            this.pnlTitulo.Size = new System.Drawing.Size(998, 40);
            this.pnlTitulo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Padrón de Colegiados";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.rdbElecciones);
            this.pnlDeck.Controls.Add(this.chbProvincia);
            this.pnlDeck.Controls.Add(this.chbDepartamento);
            this.pnlDeck.Controls.Add(this.chbLocalidad);
            this.pnlDeck.Controls.Add(this.txtUserRegistro);
            this.pnlDeck.Controls.Add(this.cboProvincia);
            this.pnlDeck.Controls.Add(this.cboDepartamento);
            this.pnlDeck.Controls.Add(this.cboLocalidad);
            this.pnlDeck.Controls.Add(this.label19);
            this.pnlDeck.Controls.Add(this.chbFianza);
            this.pnlDeck.Controls.Add(this.rdbSubasta);
            this.pnlDeck.Controls.Add(this.rdbComun);
            this.pnlDeck.Controls.Add(this.label16);
            this.pnlDeck.Controls.Add(this.cboOrden);
            this.pnlDeck.Controls.Add(this.label15);
            this.pnlDeck.Controls.Add(this.cboCategoria);
            this.pnlDeck.Controls.Add(this.label14);
            this.pnlDeck.Controls.Add(this.cboSexo);
            this.pnlDeck.Controls.Add(this.label10);
            this.pnlDeck.Controls.Add(this.cboEstado);
            this.pnlDeck.Controls.Add(this.label8);
            this.pnlDeck.Controls.Add(this.label13);
            this.pnlDeck.Controls.Add(this.label7);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.groupBox2);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(998, 558);
            this.pnlDeck.TabIndex = 24;
            // 
            // rdbElecciones
            // 
            this.rdbElecciones.AutoSize = true;
            this.rdbElecciones.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbElecciones.ForeColor = System.Drawing.Color.Yellow;
            this.rdbElecciones.Location = new System.Drawing.Point(410, 73);
            this.rdbElecciones.Name = "rdbElecciones";
            this.rdbElecciones.Size = new System.Drawing.Size(106, 24);
            this.rdbElecciones.TabIndex = 85;
            this.rdbElecciones.Text = "Elecciones";
            this.rdbElecciones.UseVisualStyleBackColor = true;
            // 
            // chbProvincia
            // 
            this.chbProvincia.AutoSize = true;
            this.chbProvincia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbProvincia.Location = new System.Drawing.Point(704, 267);
            this.chbProvincia.Name = "chbProvincia";
            this.chbProvincia.Size = new System.Drawing.Size(87, 21);
            this.chbProvincia.TabIndex = 84;
            this.chbProvincia.Text = "Provincia";
            this.chbProvincia.UseVisualStyleBackColor = true;
            this.chbProvincia.CheckedChanged += new System.EventHandler(this.chbProvincia_CheckedChanged);
            // 
            // chbDepartamento
            // 
            this.chbDepartamento.AutoSize = true;
            this.chbDepartamento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbDepartamento.Location = new System.Drawing.Point(370, 267);
            this.chbDepartamento.Name = "chbDepartamento";
            this.chbDepartamento.Size = new System.Drawing.Size(124, 21);
            this.chbDepartamento.TabIndex = 83;
            this.chbDepartamento.Text = "Departamento";
            this.chbDepartamento.UseVisualStyleBackColor = true;
            this.chbDepartamento.CheckedChanged += new System.EventHandler(this.chbDepartamento_CheckedChanged);
            // 
            // chbLocalidad
            // 
            this.chbLocalidad.AutoSize = true;
            this.chbLocalidad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbLocalidad.Location = new System.Drawing.Point(68, 266);
            this.chbLocalidad.Name = "chbLocalidad";
            this.chbLocalidad.Size = new System.Drawing.Size(92, 21);
            this.chbLocalidad.TabIndex = 12;
            this.chbLocalidad.Text = "Localidad";
            this.chbLocalidad.UseVisualStyleBackColor = true;
            this.chbLocalidad.CheckedChanged += new System.EventHandler(this.chbLocalidad_CheckedChanged);
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(232, 18);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(68, 16);
            this.txtUserRegistro.TabIndex = 78;
            this.txtUserRegistro.Visible = false;
            // 
            // cboProvincia
            // 
            this.cboProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboProvincia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboProvincia.Enabled = false;
            this.cboProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProvincia.ForeColor = System.Drawing.Color.White;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(797, 265);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(147, 25);
            this.cboProvincia.TabIndex = 15;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboDepartamento.Enabled = false;
            this.cboDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDepartamento.ForeColor = System.Drawing.Color.White;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(500, 265);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(193, 25);
            this.cboDepartamento.TabIndex = 14;
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboLocalidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLocalidad.Enabled = false;
            this.cboLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidad.ForeColor = System.Drawing.Color.White;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(166, 265);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(198, 25);
            this.cboLocalidad.Sorted = true;
            this.cboLocalidad.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(600, 220);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 17);
            this.label19.TabIndex = 82;
            this.label19.Text = "Fecha Control:";
            // 
            // chbFianza
            // 
            this.chbFianza.AutoSize = true;
            this.chbFianza.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbFianza.Location = new System.Drawing.Point(68, 170);
            this.chbFianza.Name = "chbFianza";
            this.chbFianza.Size = new System.Drawing.Size(126, 21);
            this.chbFianza.TabIndex = 6;
            this.chbFianza.Text = "Fianza Vencida";
            this.chbFianza.UseVisualStyleBackColor = true;
            this.chbFianza.CheckedChanged += new System.EventHandler(this.chbFianza_CheckedChanged);
            // 
            // rdbSubasta
            // 
            this.rdbSubasta.AutoSize = true;
            this.rdbSubasta.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSubasta.ForeColor = System.Drawing.Color.Yellow;
            this.rdbSubasta.Location = new System.Drawing.Point(295, 73);
            this.rdbSubasta.Name = "rdbSubasta";
            this.rdbSubasta.Size = new System.Drawing.Size(84, 24);
            this.rdbSubasta.TabIndex = 1;
            this.rdbSubasta.Text = "Subasta";
            this.rdbSubasta.UseVisualStyleBackColor = true;
            // 
            // rdbComun
            // 
            this.rdbComun.AutoSize = true;
            this.rdbComun.Checked = true;
            this.rdbComun.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbComun.ForeColor = System.Drawing.Color.Yellow;
            this.rdbComun.Location = new System.Drawing.Point(177, 73);
            this.rdbComun.Name = "rdbComun";
            this.rdbComun.Size = new System.Drawing.Size(80, 24);
            this.rdbComun.TabIndex = 0;
            this.rdbComun.TabStop = true;
            this.rdbComun.Text = "Común";
            this.rdbComun.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 17);
            this.label16.TabIndex = 76;
            this.label16.Text = "Tipo Listado:";
            // 
            // cboOrden
            // 
            this.cboOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOrden.ForeColor = System.Drawing.Color.White;
            this.cboOrden.FormattingEnabled = true;
            this.cboOrden.Items.AddRange(new object[] {
            "MATRICULA",
            "APELLIDO"});
            this.cboOrden.Location = new System.Drawing.Point(798, 121);
            this.cboOrden.Name = "cboOrden";
            this.cboOrden.Size = new System.Drawing.Size(147, 25);
            this.cboOrden.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(740, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 73;
            this.label15.Text = "Orden:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategoria.ForeColor = System.Drawing.Color.White;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Items.AddRange(new object[] {
            "TODOS",
            "A",
            "B",
            "I"});
            this.cboCategoria.Location = new System.Drawing.Point(596, 121);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(88, 25);
            this.cboCategoria.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(511, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 17);
            this.label14.TabIndex = 71;
            this.label14.Text = "Categoría:";
            // 
            // cboSexo
            // 
            this.cboSexo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboSexo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSexo.ForeColor = System.Drawing.Color.White;
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Items.AddRange(new object[] {
            "TODOS",
            "M",
            "F"});
            this.cboSexo.Location = new System.Drawing.Point(379, 121);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Size = new System.Drawing.Size(85, 25);
            this.cboSexo.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(332, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 17);
            this.label10.TabIndex = 69;
            this.label10.Text = "Sexo:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.ForeColor = System.Drawing.Color.White;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "TODOS",
            "ACTIVO",
            "BAJA",
            "CANCELADO",
            "SUSPENDIDO",
            "SUSP. MOROSO"});
            this.cboEstado.Location = new System.Drawing.Point(135, 121);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(147, 25);
            this.cboEstado.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 67;
            this.label8.Text = "Estados:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(68, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 17);
            this.label13.TabIndex = 63;
            this.label13.Text = "Antiguedad a Fecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 61;
            this.label7.Text = "Antes del:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(56, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 88);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnFiltrar.IconColor = System.Drawing.Color.Aqua;
            this.btnFiltrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFiltrar.IconSize = 30;
            this.btnFiltrar.Location = new System.Drawing.Point(31, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 53);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
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
            this.btnClear.Location = new System.Drawing.Point(420, 22);
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
            this.btnSalir.Location = new System.Drawing.Point(809, 22);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(26, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 22);
            this.label9.TabIndex = 47;
            this.label9.Text = "Opciones del Listado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpControl);
            this.groupBox2.Controls.Add(this.dtpAntiguedad);
            this.groupBox2.Controls.Add(this.dtpFianza);
            this.groupBox2.Controls.Add(this.nudMeses);
            this.groupBox2.Controls.Add(this.nudAnios);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(56, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(914, 253);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // dtpControl
            // 
            this.dtpControl.BorderColor = System.Drawing.Color.Gray;
            this.dtpControl.BorderSize = 1;
            this.dtpControl.CalendarMonthBackground = System.Drawing.Color.Silver;
            this.dtpControl.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.dtpControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpControl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpControl.Location = new System.Drawing.Point(654, 162);
            this.dtpControl.MinimumSize = new System.Drawing.Size(4, 23);
            this.dtpControl.Name = "dtpControl";
            this.dtpControl.Size = new System.Drawing.Size(108, 23);
            this.dtpControl.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpControl.TabIndex = 146;
            this.dtpControl.TextColor = System.Drawing.Color.White;
            // 
            // dtpAntiguedad
            // 
            this.dtpAntiguedad.BorderColor = System.Drawing.Color.Gray;
            this.dtpAntiguedad.BorderSize = 1;
            this.dtpAntiguedad.CalendarMonthBackground = System.Drawing.Color.Silver;
            this.dtpAntiguedad.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.dtpAntiguedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpAntiguedad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAntiguedad.Location = new System.Drawing.Point(163, 162);
            this.dtpAntiguedad.MinimumSize = new System.Drawing.Size(4, 23);
            this.dtpAntiguedad.Name = "dtpAntiguedad";
            this.dtpAntiguedad.Size = new System.Drawing.Size(108, 23);
            this.dtpAntiguedad.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpAntiguedad.TabIndex = 145;
            this.dtpAntiguedad.TextColor = System.Drawing.Color.White;
            // 
            // dtpFianza
            // 
            this.dtpFianza.BorderColor = System.Drawing.Color.Gray;
            this.dtpFianza.BorderSize = 1;
            this.dtpFianza.CalendarMonthBackground = System.Drawing.Color.Silver;
            this.dtpFianza.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.dtpFianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpFianza.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFianza.Location = new System.Drawing.Point(239, 113);
            this.dtpFianza.MinimumSize = new System.Drawing.Size(4, 23);
            this.dtpFianza.Name = "dtpFianza";
            this.dtpFianza.Size = new System.Drawing.Size(108, 23);
            this.dtpFianza.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFianza.TabIndex = 144;
            this.dtpFianza.TextColor = System.Drawing.Color.White;
            this.dtpFianza.Visible = false;
            // 
            // nudMeses
            // 
            this.nudMeses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudMeses.ForeColor = System.Drawing.Color.White;
            this.nudMeses.Location = new System.Drawing.Point(411, 165);
            this.nudMeses.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudMeses.Name = "nudMeses";
            this.nudMeses.Size = new System.Drawing.Size(49, 23);
            this.nudMeses.TabIndex = 10;
            this.nudMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMeses.Click += new System.EventHandler(this.nudMeses_Click);
            // 
            // nudAnios
            // 
            this.nudAnios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudAnios.ForeColor = System.Drawing.Color.White;
            this.nudAnios.Location = new System.Drawing.Point(306, 165);
            this.nudAnios.Name = "nudAnios";
            this.nudAnios.Size = new System.Drawing.Size(49, 23);
            this.nudAnios.TabIndex = 9;
            this.nudAnios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAnios.Click += new System.EventHandler(this.nudAnios_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(361, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 17);
            this.label17.TabIndex = 80;
            this.label17.Text = "Años";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(466, 167);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 81;
            this.label18.Text = "Meses";
            // 
            // frmPadronColeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(998, 598);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPadronColeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTADO DE PADRÓN DE COLEGIADOS";
            this.Load += new System.EventHandler(this.frmPadronColeg_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnFiltrar;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOrden;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboSexo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdbSubasta;
        private System.Windows.Forms.RadioButton rdbComun;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudMeses;
        private System.Windows.Forms.NumericUpDown nudAnios;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.CheckBox chbLocalidad;
        private System.Windows.Forms.CheckBox chbFianza;
        private System.Windows.Forms.CheckBox chbProvincia;
        private System.Windows.Forms.CheckBox chbDepartamento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbElecciones;
        private Controles.Controles.DatePicker dtpControl;
        private Controles.Controles.DatePicker dtpAntiguedad;
        private Controles.Controles.DatePicker dtpFianza;
    }
}