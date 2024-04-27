
namespace CapaPresentacion.Formularios
{
    partial class frmMovimCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimCaja));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.txtDeposito = new System.Windows.Forms.TextBox();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.cboForma = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pjo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subfijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.It = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pdo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
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
            this.pnlTitulo.Size = new System.Drawing.Size(1099, 40);
            this.pnlTitulo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movimientos de Caja";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.lblFecha);
            this.pnlDeck.Controls.Add(this.lblDeposito);
            this.pnlDeck.Controls.Add(this.txtDeposito);
            this.pnlDeck.Controls.Add(this.btnSalir);
            this.pnlDeck.Controls.Add(this.btnCerrar);
            this.pnlDeck.Controls.Add(this.btnLimpiar);
            this.pnlDeck.Controls.Add(this.btnAgregar);
            this.pnlDeck.Controls.Add(this.label12);
            this.pnlDeck.Controls.Add(this.txtObs);
            this.pnlDeck.Controls.Add(this.cboForma);
            this.pnlDeck.Controls.Add(this.label11);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.txtIndice);
            this.pnlDeck.Controls.Add(this.txtUserRegistro);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.dgvCaja);
            this.pnlDeck.Controls.Add(this.cboTipo);
            this.pnlDeck.Controls.Add(this.label6);
            this.pnlDeck.Controls.Add(this.label5);
            this.pnlDeck.Controls.Add(this.lblDetalle);
            this.pnlDeck.Controls.Add(this.txtImporte);
            this.pnlDeck.Controls.Add(this.txtDetalle);
            this.pnlDeck.Controls.Add(this.txtId);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(1099, 548);
            this.pnlDeck.TabIndex = 24;
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Location = new System.Drawing.Point(243, 45);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(97, 17);
            this.lblDeposito.TabIndex = 34;
            this.lblDeposito.Text = "Nro.Depósito:";
            // 
            // txtDeposito
            // 
            this.txtDeposito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDeposito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeposito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeposito.ForeColor = System.Drawing.Color.White;
            this.txtDeposito.Location = new System.Drawing.Point(346, 43);
            this.txtDeposito.Name = "txtDeposito";
            this.txtDeposito.Size = new System.Drawing.Size(142, 23);
            this.txtDeposito.TabIndex = 0;
            this.txtDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDeposito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeposito_KeyPress);
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
            this.btnSalir.Location = new System.Drawing.Point(989, 468);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.btnCerrar.IconColor = System.Drawing.Color.Red;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 30;
            this.btnCerrar.Location = new System.Drawing.Point(32, 468);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(70, 53);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            this.btnLimpiar.IconColor = System.Drawing.Color.Aqua;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 30;
            this.btnLimpiar.Location = new System.Drawing.Point(899, 74);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 34);
            this.btnLimpiar.TabIndex = 149;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnAgregar.IconColor = System.Drawing.Color.Aqua;
            this.btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregar.IconSize = 30;
            this.btnAgregar.Location = new System.Drawing.Point(733, 74);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(99, 34);
            this.btnAgregar.TabIndex = 148;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 17);
            this.label12.TabIndex = 57;
            this.label12.Text = "Observación:";
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.ForeColor = System.Drawing.Color.White;
            this.txtObs.Location = new System.Drawing.Point(123, 76);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(581, 23);
            this.txtObs.TabIndex = 9;
            // 
            // cboForma
            // 
            this.cboForma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboForma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboForma.ForeColor = System.Drawing.Color.White;
            this.cboForma.FormattingEnabled = true;
            this.cboForma.Items.AddRange(new object[] {
            "EFECTIVO",
            "TARJETA",
            "TRANSFERENCIA"});
            this.cboForma.Location = new System.Drawing.Point(941, 42);
            this.cboForma.Name = "cboForma";
            this.cboForma.Size = new System.Drawing.Size(131, 25);
            this.cboForma.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(882, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 55;
            this.label11.Text = "Forma:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(564, 461);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 64);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOTALES DE CAJA";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(256, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(91, 23);
            this.textBox3.TabIndex = 152;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(147, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(91, 23);
            this.textBox2.TabIndex = 151;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(33, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 23);
            this.textBox1.TabIndex = 150;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIndice
            // 
            this.txtIndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIndice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndice.Enabled = false;
            this.txtIndice.ForeColor = System.Drawing.Color.White;
            this.txtIndice.Location = new System.Drawing.Point(638, 16);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(65, 16);
            this.txtIndice.TabIndex = 50;
            this.txtIndice.Visible = false;
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(564, 16);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(68, 16);
            this.txtUserRegistro.TabIndex = 49;
            this.txtUserRegistro.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(22, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 22);
            this.label9.TabIndex = 47;
            this.label9.Text = "Detalle del Movimiento";
            // 
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AllowUserToDeleteRows = false;
            this.dgvCaja.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCaja.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaja.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvCaja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaja.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaja.ColumnHeadersHeight = 30;
            this.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.id_Caja,
            this.Pjo,
            this.Subfijo,
            this.It,
            this.Numero,
            this.Nombre,
            this.Pdo,
            this.Detalle,
            this.Efectivo,
            this.Transf,
            this.Tarjeta,
            this.FecCierre,
            this.Obs,
            this.UserRegistro});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaja.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCaja.EnableHeadersVisualStyles = false;
            this.dgvCaja.GridColor = System.Drawing.Color.Gray;
            this.dgvCaja.Location = new System.Drawing.Point(26, 114);
            this.dgvCaja.MultiSelect = false;
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.ReadOnly = true;
            this.dgvCaja.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaja.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvCaja.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCaja.Size = new System.Drawing.Size(1046, 341);
            this.dgvCaja.TabIndex = 46;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 25;
            // 
            // id_Caja
            // 
            this.id_Caja.HeaderText = "id";
            this.id_Caja.Name = "id_Caja";
            this.id_Caja.ReadOnly = true;
            this.id_Caja.Visible = false;
            // 
            // Pjo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Pjo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Pjo.HeaderText = "PJO";
            this.Pjo.Name = "Pjo";
            this.Pjo.ReadOnly = true;
            this.Pjo.Width = 50;
            // 
            // Subfijo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Subfijo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Subfijo.HeaderText = "SUBFIJO";
            this.Subfijo.Name = "Subfijo";
            this.Subfijo.ReadOnly = true;
            // 
            // It
            // 
            this.It.HeaderText = "IT";
            this.It.Name = "It";
            this.It.ReadOnly = true;
            this.It.Width = 20;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "NUMERO";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Visible = false;
            this.Numero.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "NOMBRE";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Pdo
            // 
            this.Pdo.HeaderText = "PDO";
            this.Pdo.Name = "Pdo";
            this.Pdo.ReadOnly = true;
            this.Pdo.Width = 50;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "DETALLE";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Width = 250;
            // 
            // Efectivo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Efectivo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Efectivo.HeaderText = "EFECTIVO";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.ReadOnly = true;
            this.Efectivo.Width = 80;
            // 
            // Transf
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Transf.DefaultCellStyle = dataGridViewCellStyle6;
            this.Transf.HeaderText = "TRANSF";
            this.Transf.Name = "Transf";
            this.Transf.ReadOnly = true;
            this.Transf.Width = 80;
            // 
            // Tarjeta
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.Tarjeta.DefaultCellStyle = dataGridViewCellStyle7;
            this.Tarjeta.HeaderText = "TARJETA";
            this.Tarjeta.Name = "Tarjeta";
            this.Tarjeta.ReadOnly = true;
            this.Tarjeta.Width = 80;
            // 
            // FecCierre
            // 
            this.FecCierre.HeaderText = "FecCierre";
            this.FecCierre.Name = "FecCierre";
            this.FecCierre.ReadOnly = true;
            this.FecCierre.Visible = false;
            // 
            // Obs
            // 
            this.Obs.HeaderText = "OBS";
            this.Obs.Name = "Obs";
            this.Obs.ReadOnly = true;
            this.Obs.Width = 150;
            // 
            // UserRegistro
            // 
            this.UserRegistro.HeaderText = "UserRegistro";
            this.UserRegistro.Name = "UserRegistro";
            this.UserRegistro.ReadOnly = true;
            this.UserRegistro.Visible = false;
            // 
            // cboTipo
            // 
            this.cboTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipo.ForeColor = System.Drawing.Color.White;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "DEPOSITO",
            "EGRESO",
            "INGRESO"});
            this.cboTipo.Location = new System.Drawing.Point(67, 42);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(107, 25);
            this.cboTipo.TabIndex = 4;
            this.cboTipo.TextChanged += new System.EventHandler(this.cboTipo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(710, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Importe:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tipo:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(183, 45);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(58, 17);
            this.lblDetalle.TabIndex = 36;
            this.lblDetalle.Text = "Detalle:";
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImporte.ForeColor = System.Drawing.Color.White;
            this.txtImporte.Location = new System.Drawing.Point(779, 43);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(91, 23);
            this.txtImporte.TabIndex = 2;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // txtDetalle
            // 
            this.txtDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalle.ForeColor = System.Drawing.Color.White;
            this.txtDetalle.Location = new System.Drawing.Point(247, 43);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(457, 23);
            this.txtDetalle.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(509, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 16);
            this.txtId.TabIndex = 30;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Yellow;
            this.lblFecha.Location = new System.Drawing.Point(937, 11);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(16, 19);
            this.lblFecha.TabIndex = 82;
            this.lblFecha.Text = "-";
            // 
            // frmMovimCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1099, 588);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMovimCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOVIMIENTOS DE CAJA";
            this.Load += new System.EventHandler(this.frmMovimCaja_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.ComboBox cboForma;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.TextBox txtDeposito;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cboTipo;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pjo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subfijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn It;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pdo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRegistro;
        public System.Windows.Forms.Label lblFecha;
    }
}