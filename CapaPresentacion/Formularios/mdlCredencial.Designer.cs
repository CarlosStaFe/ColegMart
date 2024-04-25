
namespace CapaPresentacion.Formularios
{
    partial class mdlCredencial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdlCredencial));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtApelNombre = new System.Windows.Forms.TextBox();
            this.txtTomo = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.txtJuramento = new System.Windows.Forms.TextBox();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtParticular = new System.Windows.Forms.TextBox();
            this.txtLaboral = new System.Windows.Forms.TextBox();
            this.txtFianza = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rpt_Credencial.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(819, 370);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(770, 13);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(100, 20);
            this.txtMatricula.TabIndex = 1;
            // 
            // txtApelNombre
            // 
            this.txtApelNombre.Location = new System.Drawing.Point(770, 39);
            this.txtApelNombre.Name = "txtApelNombre";
            this.txtApelNombre.Size = new System.Drawing.Size(100, 20);
            this.txtApelNombre.TabIndex = 2;
            // 
            // txtTomo
            // 
            this.txtTomo.Location = new System.Drawing.Point(770, 65);
            this.txtTomo.Name = "txtTomo";
            this.txtTomo.Size = new System.Drawing.Size(100, 20);
            this.txtTomo.TabIndex = 3;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(770, 91);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(100, 20);
            this.txtFolio.TabIndex = 4;
            // 
            // txtJuramento
            // 
            this.txtJuramento.Location = new System.Drawing.Point(770, 117);
            this.txtJuramento.Name = "txtJuramento";
            this.txtJuramento.Size = new System.Drawing.Size(100, 20);
            this.txtJuramento.TabIndex = 5;
            // 
            // txtFoto
            // 
            this.txtFoto.Location = new System.Drawing.Point(770, 143);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new System.Drawing.Size(100, 20);
            this.txtFoto.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(770, 169);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(100, 20);
            this.txtNroDoc.TabIndex = 7;
            // 
            // txtParticular
            // 
            this.txtParticular.Location = new System.Drawing.Point(770, 195);
            this.txtParticular.Name = "txtParticular";
            this.txtParticular.Size = new System.Drawing.Size(100, 20);
            this.txtParticular.TabIndex = 8;
            // 
            // txtLaboral
            // 
            this.txtLaboral.Location = new System.Drawing.Point(770, 221);
            this.txtLaboral.Name = "txtLaboral";
            this.txtLaboral.Size = new System.Drawing.Size(100, 20);
            this.txtLaboral.TabIndex = 9;
            // 
            // txtFianza
            // 
            this.txtFianza.Location = new System.Drawing.Point(770, 247);
            this.txtFianza.Name = "txtFianza";
            this.txtFianza.Size = new System.Drawing.Size(100, 20);
            this.txtFianza.TabIndex = 10;
            // 
            // mdlCredencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 370);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.txtFianza);
            this.Controls.Add(this.txtLaboral);
            this.Controls.Add(this.txtParticular);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.txtFoto);
            this.Controls.Add(this.txtJuramento);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.txtTomo);
            this.Controls.Add(this.txtApelNombre);
            this.Controls.Add(this.txtMatricula);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mdlCredencial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPRESIÓN DE CREDENCIAL DEL MATRICULADO";
            this.Load += new System.EventHandler(this.mdlCredencial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtApelNombre;
        private System.Windows.Forms.TextBox txtTomo;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.TextBox txtJuramento;
        private System.Windows.Forms.TextBox txtFoto;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtParticular;
        private System.Windows.Forms.TextBox txtLaboral;
        private System.Windows.Forms.TextBox txtFianza;
    }
}