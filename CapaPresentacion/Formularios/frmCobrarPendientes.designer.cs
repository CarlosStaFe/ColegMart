namespace CapaPresentacion.Formularios
{
    partial class frmCobrarPendientes
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrarPendientes));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtFk_idDebito = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.txtFk_idColeg = new System.Windows.Forms.TextBox();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImporteNCR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApagar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldoDeudor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransferencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dgvCtasCtes = new System.Windows.Forms.DataGridView();
            this.C_id_CtaCte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_fk_idColeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Prefijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Subfijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_fk_idDebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Pagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_UserRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbNCR = new System.Windows.Forms.CheckBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.reportCobroBoletas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetPrincipal = new CapaPresentacion.DataSetPrincipal();
            this.spCobroBoletasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spCobroBoletasTableAdapter = new CapaPresentacion.DataSetPrincipalTableAdapters.spCobroBoletasTableAdapter();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtasCtes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCobroBoletasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Controls.Add(this.txtIndice);
            this.pnlTitulo.Controls.Add(this.txtCodigo);
            this.pnlTitulo.Controls.Add(this.txtId);
            this.pnlTitulo.Controls.Add(this.txtFk_idDebito);
            this.pnlTitulo.Controls.Add(this.txtUserRegistro);
            this.pnlTitulo.Controls.Add(this.txtFk_idColeg);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1168, 40);
            this.pnlTitulo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cobrar Movimientos Pendientes";
            // 
            // txtIndice
            // 
            this.txtIndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtIndice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndice.Enabled = false;
            this.txtIndice.ForeColor = System.Drawing.Color.White;
            this.txtIndice.Location = new System.Drawing.Point(805, 11);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(65, 16);
            this.txtIndice.TabIndex = 50;
            this.txtIndice.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.ForeColor = System.Drawing.Color.White;
            this.txtCodigo.Location = new System.Drawing.Point(1018, 11);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(65, 16);
            this.txtCodigo.TabIndex = 55;
            this.txtCodigo.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(676, 11);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 16);
            this.txtId.TabIndex = 30;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // txtFk_idDebito
            // 
            this.txtFk_idDebito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtFk_idDebito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFk_idDebito.Enabled = false;
            this.txtFk_idDebito.ForeColor = System.Drawing.Color.White;
            this.txtFk_idDebito.Location = new System.Drawing.Point(947, 11);
            this.txtFk_idDebito.Name = "txtFk_idDebito";
            this.txtFk_idDebito.Size = new System.Drawing.Size(65, 16);
            this.txtFk_idDebito.TabIndex = 54;
            this.txtFk_idDebito.Visible = false;
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(731, 11);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(68, 16);
            this.txtUserRegistro.TabIndex = 49;
            this.txtUserRegistro.Visible = false;
            // 
            // txtFk_idColeg
            // 
            this.txtFk_idColeg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtFk_idColeg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFk_idColeg.Enabled = false;
            this.txtFk_idColeg.ForeColor = System.Drawing.Color.White;
            this.txtFk_idColeg.Location = new System.Drawing.Point(876, 11);
            this.txtFk_idColeg.Name = "txtFk_idColeg";
            this.txtFk_idColeg.Size = new System.Drawing.Size(65, 16);
            this.txtFk_idColeg.TabIndex = 53;
            this.txtFk_idColeg.Visible = false;
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.reportCobroBoletas);
            this.pnlDeck.Controls.Add(this.label10);
            this.pnlDeck.Controls.Add(this.txtImporteNCR);
            this.pnlDeck.Controls.Add(this.label8);
            this.pnlDeck.Controls.Add(this.txtDiferencia);
            this.pnlDeck.Controls.Add(this.label5);
            this.pnlDeck.Controls.Add(this.txtApagar);
            this.pnlDeck.Controls.Add(this.label4);
            this.pnlDeck.Controls.Add(this.txtSaldoDeudor);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.txtTarjeta);
            this.pnlDeck.Controls.Add(this.label7);
            this.pnlDeck.Controls.Add(this.txtTransferencia);
            this.pnlDeck.Controls.Add(this.label3);
            this.pnlDeck.Controls.Add(this.txtEfectivo);
            this.pnlDeck.Controls.Add(this.lblFecha);
            this.pnlDeck.Controls.Add(this.dgvCtasCtes);
            this.pnlDeck.Controls.Add(this.lblNombre);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.label6);
            this.pnlDeck.Controls.Add(this.label2);
            this.pnlDeck.Controls.Add(this.chbNCR);
            this.pnlDeck.Controls.Add(this.txtObs);
            this.pnlDeck.Controls.Add(this.txtMatricula);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(1168, 578);
            this.pnlDeck.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(972, 497);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 17);
            this.label10.TabIndex = 95;
            this.label10.Text = "NCR:";
            // 
            // txtImporteNCR
            // 
            this.txtImporteNCR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtImporteNCR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImporteNCR.Enabled = false;
            this.txtImporteNCR.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteNCR.ForeColor = System.Drawing.Color.White;
            this.txtImporteNCR.Location = new System.Drawing.Point(1019, 492);
            this.txtImporteNCR.Name = "txtImporteNCR";
            this.txtImporteNCR.Size = new System.Drawing.Size(104, 26);
            this.txtImporteNCR.TabIndex = 6;
            this.txtImporteNCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteNCR.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(746, 497);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 93;
            this.label8.Text = "DIFERENCIA:";
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDiferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDiferencia.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferencia.ForeColor = System.Drawing.Color.Lime;
            this.txtDiferencia.Location = new System.Drawing.Point(838, 492);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.Size = new System.Drawing.Size(105, 26);
            this.txtDiferencia.TabIndex = 9;
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(705, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 91;
            this.label5.Text = "IMPORTE A PAGAR:";
            // 
            // txtApagar
            // 
            this.txtApagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtApagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApagar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApagar.ForeColor = System.Drawing.Color.Yellow;
            this.txtApagar.Location = new System.Drawing.Point(838, 463);
            this.txtApagar.Name = "txtApagar";
            this.txtApagar.Size = new System.Drawing.Size(105, 26);
            this.txtApagar.TabIndex = 8;
            this.txtApagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(720, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 89;
            this.label4.Text = "SALDO DEUDOR:";
            // 
            // txtSaldoDeudor
            // 
            this.txtSaldoDeudor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSaldoDeudor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaldoDeudor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoDeudor.ForeColor = System.Drawing.Color.Red;
            this.txtSaldoDeudor.Location = new System.Drawing.Point(838, 433);
            this.txtSaldoDeudor.Name = "txtSaldoDeudor";
            this.txtSaldoDeudor.Size = new System.Drawing.Size(105, 26);
            this.txtSaldoDeudor.TabIndex = 7;
            this.txtSaldoDeudor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(525, 439);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 87;
            this.label9.Text = "TARJETA:";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTarjeta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.ForeColor = System.Drawing.Color.Yellow;
            this.txtTarjeta.Location = new System.Drawing.Point(592, 434);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(92, 26);
            this.txtTarjeta.TabIndex = 3;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarjeta.Leave += new System.EventHandler(this.txtTarjeta_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(248, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 85;
            this.label7.Text = "TRANSFERENCIA:";
            // 
            // txtTransferencia
            // 
            this.txtTransferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTransferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransferencia.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferencia.ForeColor = System.Drawing.Color.Yellow;
            this.txtTransferencia.Location = new System.Drawing.Point(365, 434);
            this.txtTransferencia.Name = "txtTransferencia";
            this.txtTransferencia.Size = new System.Drawing.Size(92, 26);
            this.txtTransferencia.TabIndex = 2;
            this.txtTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransferencia.Leave += new System.EventHandler(this.txtTransferencia_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(35, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 83;
            this.label3.Text = "EFECTIVO:";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtEfectivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEfectivo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.Color.Yellow;
            this.txtEfectivo.Location = new System.Drawing.Point(112, 434);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(92, 26);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Yellow;
            this.lblFecha.Location = new System.Drawing.Point(847, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(16, 19);
            this.lblFecha.TabIndex = 81;
            this.lblFecha.Text = "-";
            // 
            // dgvCtasCtes
            // 
            this.dgvCtasCtes.AllowUserToAddRows = false;
            this.dgvCtasCtes.AllowUserToDeleteRows = false;
            this.dgvCtasCtes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCtasCtes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtasCtes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvCtasCtes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtasCtes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCtasCtes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCtasCtes.ColumnHeadersHeight = 30;
            this.dgvCtasCtes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCtasCtes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_id_CtaCte,
            this.C_fk_idColeg,
            this.C_Matricula,
            this.C_Fecha,
            this.C_Tipo,
            this.C_Prefijo,
            this.C_Subfijo,
            this.C_Item,
            this.C_fk_idDebito,
            this.C_Detalle,
            this.C_Periodo,
            this.C_Debe,
            this.C_Pagado,
            this.C_FechaPago,
            this.C_Saldo,
            this.C_Estado,
            this.C_Obs,
            this.C_UserRegistro,
            this.C_FechaRegistro,
            this.Seleccionar});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCtasCtes.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCtasCtes.EnableHeadersVisualStyles = false;
            this.dgvCtasCtes.GridColor = System.Drawing.Color.White;
            this.dgvCtasCtes.Location = new System.Drawing.Point(17, 44);
            this.dgvCtasCtes.MultiSelect = false;
            this.dgvCtasCtes.Name = "dgvCtasCtes";
            this.dgvCtasCtes.ReadOnly = true;
            this.dgvCtasCtes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCtasCtes.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvCtasCtes.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCtasCtes.Size = new System.Drawing.Size(1021, 381);
            this.dgvCtasCtes.TabIndex = 80;
            this.dgvCtasCtes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtasCtes_CellDoubleClick);
            // 
            // C_id_CtaCte
            // 
            this.C_id_CtaCte.HeaderText = "id_CtaCte";
            this.C_id_CtaCte.Name = "C_id_CtaCte";
            this.C_id_CtaCte.ReadOnly = true;
            this.C_id_CtaCte.Visible = false;
            // 
            // C_fk_idColeg
            // 
            this.C_fk_idColeg.HeaderText = "fk_idColeg";
            this.C_fk_idColeg.Name = "C_fk_idColeg";
            this.C_fk_idColeg.ReadOnly = true;
            this.C_fk_idColeg.Visible = false;
            // 
            // C_Matricula
            // 
            this.C_Matricula.HeaderText = "Matricula";
            this.C_Matricula.Name = "C_Matricula";
            this.C_Matricula.ReadOnly = true;
            this.C_Matricula.Visible = false;
            // 
            // C_Fecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.C_Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.C_Fecha.HeaderText = "FECHA";
            this.C_Fecha.Name = "C_Fecha";
            this.C_Fecha.ReadOnly = true;
            this.C_Fecha.Width = 80;
            // 
            // C_Tipo
            // 
            this.C_Tipo.HeaderText = "TIPO";
            this.C_Tipo.Name = "C_Tipo";
            this.C_Tipo.ReadOnly = true;
            this.C_Tipo.Width = 40;
            // 
            // C_Prefijo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.C_Prefijo.DefaultCellStyle = dataGridViewCellStyle4;
            this.C_Prefijo.HeaderText = "PREF.";
            this.C_Prefijo.Name = "C_Prefijo";
            this.C_Prefijo.ReadOnly = true;
            this.C_Prefijo.Width = 40;
            // 
            // C_Subfijo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.C_Subfijo.DefaultCellStyle = dataGridViewCellStyle5;
            this.C_Subfijo.HeaderText = "SUBFIJO";
            this.C_Subfijo.Name = "C_Subfijo";
            this.C_Subfijo.ReadOnly = true;
            this.C_Subfijo.Width = 65;
            // 
            // C_Item
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.C_Item.DefaultCellStyle = dataGridViewCellStyle6;
            this.C_Item.HeaderText = "IT";
            this.C_Item.Name = "C_Item";
            this.C_Item.ReadOnly = true;
            this.C_Item.Width = 25;
            // 
            // C_fk_idDebito
            // 
            this.C_fk_idDebito.HeaderText = "fk_idDebito";
            this.C_fk_idDebito.Name = "C_fk_idDebito";
            this.C_fk_idDebito.ReadOnly = true;
            this.C_fk_idDebito.Visible = false;
            // 
            // C_Detalle
            // 
            this.C_Detalle.HeaderText = "DETALLE";
            this.C_Detalle.Name = "C_Detalle";
            this.C_Detalle.ReadOnly = true;
            this.C_Detalle.Width = 225;
            // 
            // C_Periodo
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.C_Periodo.DefaultCellStyle = dataGridViewCellStyle7;
            this.C_Periodo.HeaderText = "PDO.";
            this.C_Periodo.Name = "C_Periodo";
            this.C_Periodo.ReadOnly = true;
            this.C_Periodo.Width = 60;
            // 
            // C_Debe
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.C_Debe.DefaultCellStyle = dataGridViewCellStyle8;
            this.C_Debe.HeaderText = "DEBE";
            this.C_Debe.Name = "C_Debe";
            this.C_Debe.ReadOnly = true;
            this.C_Debe.Width = 80;
            // 
            // C_Pagado
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.C_Pagado.DefaultCellStyle = dataGridViewCellStyle9;
            this.C_Pagado.HeaderText = "PAGADO";
            this.C_Pagado.Name = "C_Pagado";
            this.C_Pagado.ReadOnly = true;
            this.C_Pagado.Width = 80;
            // 
            // C_FechaPago
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = "-";
            this.C_FechaPago.DefaultCellStyle = dataGridViewCellStyle10;
            this.C_FechaPago.HeaderText = "FEC.PAGO";
            this.C_FechaPago.Name = "C_FechaPago";
            this.C_FechaPago.ReadOnly = true;
            this.C_FechaPago.Width = 80;
            // 
            // C_Saldo
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.C_Saldo.DefaultCellStyle = dataGridViewCellStyle11;
            this.C_Saldo.HeaderText = "SALDO";
            this.C_Saldo.Name = "C_Saldo";
            this.C_Saldo.ReadOnly = true;
            this.C_Saldo.Width = 80;
            // 
            // C_Estado
            // 
            this.C_Estado.DividerWidth = 3;
            this.C_Estado.HeaderText = "ESTADO";
            this.C_Estado.Name = "C_Estado";
            this.C_Estado.ReadOnly = true;
            this.C_Estado.Width = 90;
            // 
            // C_Obs
            // 
            this.C_Obs.HeaderText = "OBSERVACIONES";
            this.C_Obs.Name = "C_Obs";
            this.C_Obs.ReadOnly = true;
            this.C_Obs.Visible = false;
            this.C_Obs.Width = 200;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Red;
            this.Seleccionar.DefaultCellStyle = dataGridViewCellStyle12;
            this.Seleccionar.DividerWidth = 3;
            this.Seleccionar.HeaderText = "X";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 25;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(219, 14);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(14, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1044, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 381);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
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
            this.btnSalir.Location = new System.Drawing.Point(17, 314);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Aqua;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 30;
            this.btnImprimir.Location = new System.Drawing.Point(17, 29);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(70, 53);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnClear.Location = new System.Drawing.Point(17, 162);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 53);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Limpiar";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Observación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Matrícula/Sociedad:";
            // 
            // chbNCR
            // 
            this.chbNCR.AutoSize = true;
            this.chbNCR.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbNCR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chbNCR.Location = new System.Drawing.Point(976, 461);
            this.chbNCR.Name = "chbNCR";
            this.chbNCR.Size = new System.Drawing.Size(147, 24);
            this.chbNCR.TabIndex = 5;
            this.chbNCR.Text = "Nota de Crédito";
            this.chbNCR.UseVisualStyleBackColor = true;
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.ForeColor = System.Drawing.Color.White;
            this.txtObs.Location = new System.Drawing.Point(112, 466);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(572, 52);
            this.txtObs.TabIndex = 4;
            this.txtObs.Leave += new System.EventHandler(this.txtObs_Leave);
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.ForeColor = System.Drawing.Color.White;
            this.txtMatricula.Location = new System.Drawing.Point(159, 15);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(54, 23);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // reportCobroBoletas
            // 
            this.reportCobroBoletas.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rpt_Cic_Boletas.rdlc";
            this.reportCobroBoletas.Location = new System.Drawing.Point(17, 524);
            this.reportCobroBoletas.Name = "reportCobroBoletas";
            this.reportCobroBoletas.ServerReport.BearerToken = null;
            this.reportCobroBoletas.Size = new System.Drawing.Size(667, 30);
            this.reportCobroBoletas.TabIndex = 96;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spCobroBoletasBindingSource
            // 
            this.spCobroBoletasBindingSource.DataMember = "spCobroBoletas";
            this.spCobroBoletasBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // spCobroBoletasTableAdapter
            // 
            this.spCobroBoletasTableAdapter.ClearBeforeFill = true;
            // 
            // frmCobrarPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1168, 618);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCobrarPendientes";
            this.Text = "COBRAR MOVIMIENTOS PENDIENTES";
            this.Load += new System.EventHandler(this.frmCobrarPendientes_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtasCtes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCobroBoletasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtFk_idDebito;
        private System.Windows.Forms.TextBox txtUserRegistro;
        public System.Windows.Forms.TextBox txtFk_idColeg;
        private System.Windows.Forms.Panel pnlDeck;
        public System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbNCR;
        private System.Windows.Forms.TextBox txtObs;
        public System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTransferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEfectivo;
        public System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridView dgvCtasCtes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtImporteNCR;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.TextBox txtApagar;
        private System.Windows.Forms.TextBox txtSaldoDeudor;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_id_CtaCte;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_fk_idColeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Prefijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Subfijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_fk_idDebito;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Pagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Obs;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_UserRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seleccionar;
        private Microsoft.Reporting.WinForms.ReportViewer reportCobroBoletas;
        private System.Windows.Forms.BindingSource spCobroBoletasBindingSource;
        private DataSetPrincipal dataSetPrincipal;
        private DataSetPrincipalTableAdapters.spCobroBoletasTableAdapter spCobroBoletasTableAdapter;
    }
}