
namespace CapaPresentacion.Formularios
{
    partial class frmLiquidarSociedades
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiquidarSociedades));
            this.spLiquidacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPrincipal = new CapaPresentacion.DataSetPrincipal();
            this.spDetalleLiquiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spDeudaLiquiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbInscripcion = new System.Windows.Forms.RadioButton();
            this.rdbSemestral = new System.Windows.Forms.RadioButton();
            this.grpSemestre = new System.Windows.Forms.GroupBox();
            this.rdbSegundo = new System.Windows.Forms.RadioButton();
            this.rdbPrimero = new System.Windows.Forms.RadioButton();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.reportReclamo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportLiquidacion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCuotas = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaLiq = new Controles.Controles.DatePicker();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTesorero = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.spLiquidacionTableAdapter = new CapaPresentacion.DataSetPrincipalTableAdapters.spLiquidacionTableAdapter();
            this.spDetalleLiquiTableAdapter = new CapaPresentacion.DataSetPrincipalTableAdapters.spDetalleLiquiTableAdapter();
            this.spDeudaLiquiTableAdapter = new CapaPresentacion.DataSetPrincipalTableAdapters.spDeudaLiquiTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorKilo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spLiquidacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDetalleLiquiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDeudaLiquiBindingSource)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpSemestre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spLiquidacionBindingSource
            // 
            this.spLiquidacionBindingSource.DataMember = "spLiquidacion";
            this.spLiquidacionBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spDetalleLiquiBindingSource
            // 
            this.spDetalleLiquiBindingSource.DataMember = "spDetalleLiqui";
            this.spDetalleLiquiBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // spDeudaLiquiBindingSource
            // 
            this.spDeudaLiquiBindingSource.DataMember = "spDeudaLiqui";
            this.spDeudaLiquiBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1067, 40);
            this.pnlTitulo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liquidación a Sociedades";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.txtValorKilo);
            this.pnlDeck.Controls.Add(this.label4);
            this.pnlDeck.Controls.Add(this.groupBox2);
            this.pnlDeck.Controls.Add(this.grpSemestre);
            this.pnlDeck.Controls.Add(this.reportReclamo);
            this.pnlDeck.Controls.Add(this.reportLiquidacion);
            this.pnlDeck.Controls.Add(this.label6);
            this.pnlDeck.Controls.Add(this.nudCuotas);
            this.pnlDeck.Controls.Add(this.dtpFechaLiq);
            this.pnlDeck.Controls.Add(this.lblProcesando);
            this.pnlDeck.Controls.Add(this.label14);
            this.pnlDeck.Controls.Add(this.txtTesorero);
            this.pnlDeck.Controls.Add(this.label13);
            this.pnlDeck.Controls.Add(this.txtMensaje);
            this.pnlDeck.Controls.Add(this.label11);
            this.pnlDeck.Controls.Add(this.txtAsunto);
            this.pnlDeck.Controls.Add(this.txtPeriodo);
            this.pnlDeck.Controls.Add(this.label10);
            this.pnlDeck.Controls.Add(this.txtHasta);
            this.pnlDeck.Controls.Add(this.label3);
            this.pnlDeck.Controls.Add(this.label12);
            this.pnlDeck.Controls.Add(this.txtObs);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.txtIndice);
            this.pnlDeck.Controls.Add(this.txtUserRegistro);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.label8);
            this.pnlDeck.Controls.Add(this.label2);
            this.pnlDeck.Controls.Add(this.txtDesde);
            this.pnlDeck.Controls.Add(this.txtId);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(1067, 548);
            this.pnlDeck.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbInscripcion);
            this.groupBox2.Controls.Add(this.rdbSemestral);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(449, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 60);
            this.groupBox2.TabIndex = 155;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo Liquidación";
            // 
            // rdbInscripcion
            // 
            this.rdbInscripcion.AutoSize = true;
            this.rdbInscripcion.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInscripcion.ForeColor = System.Drawing.Color.Yellow;
            this.rdbInscripcion.Location = new System.Drawing.Point(169, 24);
            this.rdbInscripcion.Name = "rdbInscripcion";
            this.rdbInscripcion.Size = new System.Drawing.Size(107, 24);
            this.rdbInscripcion.TabIndex = 1;
            this.rdbInscripcion.TabStop = true;
            this.rdbInscripcion.Text = "Inscripción";
            this.rdbInscripcion.UseVisualStyleBackColor = true;
            this.rdbInscripcion.Click += new System.EventHandler(this.rdbInscripcion_Click);
            // 
            // rdbSemestral
            // 
            this.rdbSemestral.AutoSize = true;
            this.rdbSemestral.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSemestral.ForeColor = System.Drawing.Color.Yellow;
            this.rdbSemestral.Location = new System.Drawing.Point(23, 24);
            this.rdbSemestral.Name = "rdbSemestral";
            this.rdbSemestral.Size = new System.Drawing.Size(96, 24);
            this.rdbSemestral.TabIndex = 0;
            this.rdbSemestral.TabStop = true;
            this.rdbSemestral.Text = "Semestral";
            this.rdbSemestral.UseVisualStyleBackColor = true;
            this.rdbSemestral.Click += new System.EventHandler(this.rdbSemestral_Click);
            // 
            // grpSemestre
            // 
            this.grpSemestre.Controls.Add(this.rdbSegundo);
            this.grpSemestre.Controls.Add(this.rdbPrimero);
            this.grpSemestre.Controls.Add(this.lblPeriodo);
            this.grpSemestre.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSemestre.ForeColor = System.Drawing.Color.White;
            this.grpSemestre.Location = new System.Drawing.Point(43, 80);
            this.grpSemestre.Name = "grpSemestre";
            this.grpSemestre.Size = new System.Drawing.Size(385, 60);
            this.grpSemestre.TabIndex = 154;
            this.grpSemestre.TabStop = false;
            this.grpSemestre.Text = "Semestre";
            // 
            // rdbSegundo
            // 
            this.rdbSegundo.AutoSize = true;
            this.rdbSegundo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSegundo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdbSegundo.Location = new System.Drawing.Point(134, 22);
            this.rdbSegundo.Name = "rdbSegundo";
            this.rdbSegundo.Size = new System.Drawing.Size(92, 24);
            this.rdbSegundo.TabIndex = 1;
            this.rdbSegundo.TabStop = true;
            this.rdbSegundo.Text = "Segundo";
            this.rdbSegundo.UseVisualStyleBackColor = true;
            this.rdbSegundo.Click += new System.EventHandler(this.rdbSegundo_Click);
            // 
            // rdbPrimero
            // 
            this.rdbPrimero.AutoSize = true;
            this.rdbPrimero.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPrimero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdbPrimero.Location = new System.Drawing.Point(20, 22);
            this.rdbPrimero.Name = "rdbPrimero";
            this.rdbPrimero.Size = new System.Drawing.Size(82, 24);
            this.rdbPrimero.TabIndex = 0;
            this.rdbPrimero.TabStop = true;
            this.rdbPrimero.Text = "Primero";
            this.rdbPrimero.UseVisualStyleBackColor = true;
            this.rdbPrimero.Click += new System.EventHandler(this.rdbPrimero_Click);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblPeriodo.Location = new System.Drawing.Point(268, 24);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(18, 23);
            this.lblPeriodo.TabIndex = 6;
            this.lblPeriodo.Text = "-";
            // 
            // reportReclamo
            // 
            this.reportReclamo.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rpt_Reclamo_Soc.rdlc";
            this.reportReclamo.Location = new System.Drawing.Point(872, 10);
            this.reportReclamo.Name = "reportReclamo";
            this.reportReclamo.ServerReport.BearerToken = null;
            this.reportReclamo.Size = new System.Drawing.Size(150, 32);
            this.reportReclamo.TabIndex = 148;
            // 
            // reportLiquidacion
            // 
            reportDataSource1.Name = "DS_Liquidacion";
            reportDataSource1.Value = this.spLiquidacionBindingSource;
            reportDataSource2.Name = "DS_Detalle";
            reportDataSource2.Value = this.spDetalleLiquiBindingSource;
            reportDataSource3.Name = "DS_Deuda";
            reportDataSource3.Value = this.spDeudaLiquiBindingSource;
            this.reportLiquidacion.LocalReport.DataSources.Add(reportDataSource1);
            this.reportLiquidacion.LocalReport.DataSources.Add(reportDataSource2);
            this.reportLiquidacion.LocalReport.DataSources.Add(reportDataSource3);
            this.reportLiquidacion.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rpt_Liquidacion_Sociedades.rdlc";
            this.reportLiquidacion.Location = new System.Drawing.Point(704, 10);
            this.reportLiquidacion.Name = "reportLiquidacion";
            this.reportLiquidacion.ServerReport.BearerToken = null;
            this.reportLiquidacion.Size = new System.Drawing.Size(161, 32);
            this.reportLiquidacion.TabIndex = 147;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 17);
            this.label6.TabIndex = 146;
            this.label6.Text = "Cuotas Pendientes:";
            // 
            // nudCuotas
            // 
            this.nudCuotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudCuotas.ForeColor = System.Drawing.Color.White;
            this.nudCuotas.Location = new System.Drawing.Point(167, 158);
            this.nudCuotas.Name = "nudCuotas";
            this.nudCuotas.Size = new System.Drawing.Size(52, 23);
            this.nudCuotas.TabIndex = 3;
            this.nudCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCuotas.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // dtpFechaLiq
            // 
            this.dtpFechaLiq.BorderColor = System.Drawing.Color.Gray;
            this.dtpFechaLiq.BorderSize = 1;
            this.dtpFechaLiq.CalendarMonthBackground = System.Drawing.Color.Silver;
            this.dtpFechaLiq.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.dtpFechaLiq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpFechaLiq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiq.Location = new System.Drawing.Point(621, 48);
            this.dtpFechaLiq.MinimumSize = new System.Drawing.Size(4, 23);
            this.dtpFechaLiq.Name = "dtpFechaLiq";
            this.dtpFechaLiq.Size = new System.Drawing.Size(108, 23);
            this.dtpFechaLiq.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFechaLiq.TabIndex = 2;
            this.dtpFechaLiq.TextColor = System.Drawing.Color.White;
            this.dtpFechaLiq.Leave += new System.EventHandler(this.dtpFechaLiq_Leave);
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(39, 344);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(16, 22);
            this.lblProcesando.TabIndex = 17;
            this.lblProcesando.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 276);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 17);
            this.label14.TabIndex = 139;
            this.label14.Text = "Nombre Tesorero:";
            // 
            // txtTesorero
            // 
            this.txtTesorero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTesorero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTesorero.ForeColor = System.Drawing.Color.White;
            this.txtTesorero.Location = new System.Drawing.Point(167, 274);
            this.txtTesorero.Multiline = true;
            this.txtTesorero.Name = "txtTesorero";
            this.txtTesorero.Size = new System.Drawing.Size(289, 23);
            this.txtTesorero.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 135;
            this.label13.Text = "Mensaje Mail:";
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensaje.ForeColor = System.Drawing.Color.White;
            this.txtMensaje.Location = new System.Drawing.Point(167, 216);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(826, 23);
            this.txtMensaje.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 133;
            this.label11.Text = "Asunto Mail:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsunto.ForeColor = System.Drawing.Color.White;
            this.txtAsunto.Location = new System.Drawing.Point(167, 187);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(826, 23);
            this.txtAsunto.TabIndex = 5;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeriodo.Enabled = false;
            this.txtPeriodo.ForeColor = System.Drawing.Color.White;
            this.txtPeriodo.Location = new System.Drawing.Point(565, 6);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(67, 16);
            this.txtPeriodo.TabIndex = 3;
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(518, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 17);
            this.label10.TabIndex = 67;
            this.label10.Text = "Fecha Liquid.:";
            // 
            // txtHasta
            // 
            this.txtHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHasta.ForeColor = System.Drawing.Color.White;
            this.txtHasta.Location = new System.Drawing.Point(396, 51);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(54, 23);
            this.txtHasta.TabIndex = 1;
            this.txtHasta.Text = "69999";
            this.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHasta.Leave += new System.EventHandler(this.txtHasta_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Hasta Sociedad:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 17);
            this.label12.TabIndex = 57;
            this.label12.Text = "Observación Boleta:";
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.ForeColor = System.Drawing.Color.White;
            this.txtObs.Location = new System.Drawing.Point(167, 245);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(826, 23);
            this.txtObs.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(25, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 96);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
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
            this.btnClear.IconSize = 40;
            this.btnClear.Location = new System.Drawing.Point(449, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 63);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Limpiar";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.IconChar = FontAwesome.Sharp.IconChar.Whmcs;
            this.btnProcesar.IconColor = System.Drawing.Color.Aqua;
            this.btnProcesar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesar.IconSize = 40;
            this.btnProcesar.Location = new System.Drawing.Point(36, 21);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(77, 63);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
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
            this.btnSalir.IconSize = 40;
            this.btnSalir.Location = new System.Drawing.Point(862, 21);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(77, 63);
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
            this.txtIndice.Location = new System.Drawing.Point(494, 6);
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
            this.txtUserRegistro.Location = new System.Drawing.Point(420, 6);
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
            this.label9.Location = new System.Drawing.Point(25, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 22);
            this.label9.TabIndex = 47;
            this.label9.Text = "Detalle de la Liquidación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(21, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "Sociedad en Proceso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Desde Sociedad:";
            // 
            // txtDesde
            // 
            this.txtDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesde.ForeColor = System.Drawing.Color.White;
            this.txtDesde.Location = new System.Drawing.Point(167, 51);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(54, 23);
            this.txtDesde.TabIndex = 0;
            this.txtDesde.Text = "60001";
            this.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(365, 6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 16);
            this.txtId.TabIndex = 30;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // spLiquidacionTableAdapter
            // 
            this.spLiquidacionTableAdapter.ClearBeforeFill = true;
            // 
            // spDetalleLiquiTableAdapter
            // 
            this.spDetalleLiquiTableAdapter.ClearBeforeFill = true;
            // 
            // spDeudaLiquiTableAdapter
            // 
            this.spDeudaLiquiTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 156;
            this.label4.Text = "Precio Kg. Novillo:";
            // 
            // txtValorKilo
            // 
            this.txtValorKilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtValorKilo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorKilo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorKilo.ForeColor = System.Drawing.Color.White;
            this.txtValorKilo.Location = new System.Drawing.Point(444, 158);
            this.txtValorKilo.Name = "txtValorKilo";
            this.txtValorKilo.Size = new System.Drawing.Size(73, 23);
            this.txtValorKilo.TabIndex = 4;
            this.txtValorKilo.Text = "0";
            this.txtValorKilo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmLiquidarSociedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1067, 588);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLiquidarSociedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIQUIDACIÓN A SOCIEDADES";
            this.Load += new System.EventHandler(this.frmLiquidarSociedades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spLiquidacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDetalleLiquiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDeudaLiquiBindingSource)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpSemestre.ResumeLayout(false);
            this.grpSemestre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        private Controles.Controles.DatePicker dtpFechaLiq;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTesorero;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.RadioButton rdbInscripcion;
        private System.Windows.Forms.RadioButton rdbSemestral;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCuotas;
        private Microsoft.Reporting.WinForms.ReportViewer reportLiquidacion;
        private System.Windows.Forms.BindingSource spLiquidacionBindingSource;
        private DataSetPrincipal dataSetPrincipal;
        private System.Windows.Forms.BindingSource spDetalleLiquiBindingSource;
        private System.Windows.Forms.BindingSource spDeudaLiquiBindingSource;
        private DataSetPrincipalTableAdapters.spLiquidacionTableAdapter spLiquidacionTableAdapter;
        private DataSetPrincipalTableAdapters.spDetalleLiquiTableAdapter spDetalleLiquiTableAdapter;
        private DataSetPrincipalTableAdapters.spDeudaLiquiTableAdapter spDeudaLiquiTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportReclamo;
        private System.Windows.Forms.GroupBox grpSemestre;
        private System.Windows.Forms.RadioButton rdbSegundo;
        private System.Windows.Forms.RadioButton rdbPrimero;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtValorKilo;
        private System.Windows.Forms.Label label4;
    }
}