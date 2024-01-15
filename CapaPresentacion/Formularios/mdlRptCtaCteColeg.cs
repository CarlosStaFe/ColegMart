using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlRptCtaCteColeg : Form
    {
        public int matri { get; set; }
        public string detalle { get; set; }
        public string user { get; set; }

        public mdlRptCtaCteColeg()
        {
            InitializeComponent();
        }

        private void mdlRptCtaCteColeg_Load(object sender, EventArgs e)
        {
            spCtaCteColegTableAdapter.Fill(dataSetPrincipal.spCtaCteColeg, matri);

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("prmDetalle", detalle);
            parametros[1] = new ReportParameter("prmUser", user);

            reportViewer1.LocalReport.SetParameters(parametros);

            reportViewer1.RefreshReport();
        }
    }
}
