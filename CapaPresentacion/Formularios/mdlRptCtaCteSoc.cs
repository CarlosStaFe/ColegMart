using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlRptCtaCteSoc : Form
    {
        public int numero { get; set; }
        public string detalle { get; set; }
        public string user { get; set; }

        public mdlRptCtaCteSoc()
        {
            InitializeComponent();
        }

        private void mdlCtaCteSoc_Load(object sender, EventArgs e)
        {
            spCtaCteSocTableAdapter.Fill(dataSetPrincipal.spCtaCteSoc, numero);

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("prmDetalle", detalle);
            parametros[1] = new ReportParameter("prmUser", user);

            reportViewer1.LocalReport.SetParameters(parametros);

            reportViewer1.RefreshReport();
        }
    }
}
