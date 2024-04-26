using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class mdlPadronSocie : Form
    {
        public string detalle { get; set; }
        public string user { get; set; }

        public mdlPadronSocie()
        {
            InitializeComponent();
        }

        private void mdlPadronSocie_Load(object sender, EventArgs e)
        {
            spListaPadronSocTableAdapter.Fill(DataSetPrincipal.spListaPadronSoc);

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("prmDetalle", detalle);
            parametros[1] = new ReportParameter("prmUser", user);

            reportViewer1.LocalReport.SetParameters(parametros);

            reportViewer1.RefreshReport();
        }
    }
}
