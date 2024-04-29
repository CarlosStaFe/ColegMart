using CapaPresentacion.Utiles;
using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPrintCaja : Form
    {
        public string user { get; set; }
        string buscar, mailorigen, password, maildestino, linea, path, respuesta;

        public frmPrintCaja()
        {
            InitializeComponent();
        }

        //***** PROCESO PARA IMPRIMIR LA CAJA DEL DÍA *****
        private void frmPrintCaja_Load(object sender, EventArgs e)
        {
            cajasTableAdapter.Fill(dataSetPrincipal.cajas);

            ReportParameter[] parametros = new ReportParameter[1];
            parametros[0] = new ReportParameter("prmUser", user);

            reportViewer1.LocalReport.SetParameters(parametros);

            byte[] bytes = reportViewer1.LocalReport.Render("PDF");

            buscar = "PathCajas";
            linea = new LeerConfig().Proceso(buscar);
            string nombrePDF = "Caja" + "-" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "";
            path = linea + nombrePDF;

            var newFile = new FileStream(path, FileMode.Create);

            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();

            EnviarMail();

            reportViewer1.RefreshReport();
        }

        //***** PROCESO PARA ENVIAR EL MAIL DE LA CAJA A TESORERÍA *****
        private void EnviarMail()
        {
            buscar = "MailOrigen";
            mailorigen = new LeerConfig().Proceso(buscar);

            buscar = "PasswordMail";
            password = new LeerConfig().Proceso(buscar);

            maildestino = "tesoreria@martilleros.org.ar";
            maildestino = "carlos.a.mayans@gmail.com";            //*** mail para pruebas

            bool enviado = new EnviarCorreo().EnviarMail(mailorigen, password, maildestino, "Cierre de caja", "", path);

            if (enviado == false)
            {
                string mensaje = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append("NO SE ENVIÓ EL MAIL DE CIERRE DE CAJA...!!!");
                mensaje = sb.ToString();
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                respuesta = dialogo.ToString();
            }
        }

    }
}
