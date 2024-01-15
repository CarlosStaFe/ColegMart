using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlPadColegSubasta : Form
    {
        public string detalle { get; set; }
        public string user { get; set; }

        public mdlPadColegSubasta()
        {
            InitializeComponent();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            spListaPadronColegTableAdapter.Fill(dataSetPrincipal.spListaPadronColeg);

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("prmDetalle", detalle);
            parametros[1] = new ReportParameter("prmUser", user);

            reportViewer1.LocalReport.SetParameters(parametros);

            reportViewer1.RefreshReport();
        }
    }
}
