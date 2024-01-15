using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlPadColegElecc : Form
    {
        public string detalle { get; set; }
        public string user { get; set; }

        public mdlPadColegElecc()
        {
            InitializeComponent();
        }

        private void mdlPadColegElecc_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.spListaPadronColeg' Puede moverla o quitarla según sea necesario.
            this.spListaPadronColegTableAdapter.Fill(this.dataSetPrincipal.spListaPadronColeg);
            this.spListaPadronColegTableAdapter.Fill(this.dataSetPrincipal.spListaPadronColeg);

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("prmDetalle", detalle);
            parametros[1] = new ReportParameter("prmUser", user);

            reportViewer1.LocalReport.SetParameters(parametros);

            this.reportViewer1.RefreshReport();
        }
    }
}
