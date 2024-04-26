
namespace CapaPresentacion.Formularios
{
    partial class mdlRptCtaCteSoc
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdlRptCtaCteSoc));
            this.spCtaCteSocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPrincipal = new CapaPresentacion.DataSetPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spCtaCteSocTableAdapter = new CapaPresentacion.DataSetPrincipalTableAdapters.spCtaCteSocTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spCtaCteSocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // spCtaCteSocBindingSource
            // 
            this.spCtaCteSocBindingSource.DataMember = "spCtaCteSoc";
            this.spCtaCteSocBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DS_CtaCteSocie";
            reportDataSource2.Value = this.spCtaCteSocBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rpt_CtaCte_Soc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1077, 603);
            this.reportViewer1.TabIndex = 0;
            // 
            // spCtaCteSocTableAdapter
            // 
            this.spCtaCteSocTableAdapter.ClearBeforeFill = true;
            // 
            // mdlRptCtaCteSoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 603);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mdlRptCtaCteSoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPRESIÓN DE LA CUENTA CORRIENTE DE SOCIEDADES";
            this.Load += new System.EventHandler(this.mdlCtaCteSoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spCtaCteSocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spCtaCteSocBindingSource;
        private DataSetPrincipal dataSetPrincipal;
        private DataSetPrincipalTableAdapters.spCtaCteSocTableAdapter spCtaCteSocTableAdapter;
    }
}