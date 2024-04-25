using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using CapaPresentacion.Utiles;

namespace CapaPresentacion.Formularios
{
    public partial class mdlCredencial : Form
    {
        string matricula,fecha,localidad;

        public mdlCredencial(string matri)
        {
            InitializeComponent();
            matricula = matri;
        }

        private void mdlCredencial_Load(object sender, EventArgs e)
        {
            LeerColegiado();

            ReportParameter[] parametros = new ReportParameter[10];
            parametros[0] = new ReportParameter("prmMatricula", txtMatricula.Text);
            parametros[1] = new ReportParameter("prmApelNombre", txtApelNombre.Text);
            parametros[2] = new ReportParameter("prmTomo", txtTomo.Text);
            parametros[3] = new ReportParameter("prmFolio", txtFolio.Text);
            parametros[4] = new ReportParameter("prmJuramento", txtJuramento.Text);
            parametros[5] = new ReportParameter("prmFoto", "File:\\" + txtFoto.Text, true);
            parametros[6] = new ReportParameter("prmNroDoc", txtNroDoc.Text);
            parametros[7] = new ReportParameter("prmParticular", txtParticular.Text);
            parametros[8] = new ReportParameter("prmLaboral", txtParticular.Text);
            parametros[9] = new ReportParameter("prmFianza", txtFianza.Text);

            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(parametros);

            reportViewer1.RefreshReport();
        }

        //***** PROCEDIMIENTO PARA LEER EL COLEGIADO INGRESADO *****
        private void LeerColegiado()
        {
            string mensaje = string.Empty;
            List<CE_Colegiados> ListaBuscado = new CN_Colegiados().ListaBuscado(matricula, out mensaje);

            foreach (CE_Colegiados item in ListaBuscado)
            {
                txtMatricula.Text = Convert.ToString(item.Matricula);
                txtMatricula.Text = new PonerCeros().Proceso(txtMatricula.Text, 5);

                txtApelNombre.Text = item.ApelNombres.ToString().Trim();
                txtTomo.Text = item.Tomo.ToString().Trim();
                txtFolio.Text = item.Folio.ToString().Trim();
                txtFoto.Text = item.Foto.ToString().Trim();

                txtJuramento.Text = item.Juramento.ToString().Trim();
                int pos1 = txtJuramento.Text.IndexOf(" ");
                string fecha1 = txtJuramento.Text.Substring(0, pos1);
                fecha = fecha1;
                txtJuramento.Text = fecha1;

                txtNroDoc.Text = item.NumeroDoc.ToString().Trim();
                txtFianza.Text = item.FecVenceFianza.ToString().Trim();
                int pos2 = txtFianza.Text.IndexOf(" ");
                string fecha2 = txtFianza.Text.Substring(0, pos2);
                fecha = fecha2;
                txtFianza.Text = fecha2;

                txtParticular.Text = item.DomParti.ToString().Trim();
                localidad = new CN_CodigosPostales().BuscaCodPos(item.idCodPosParti);
                txtParticular.Text = txtParticular.Text + " - " + localidad;
                txtLaboral.Text = item.DomLabor.ToString().Trim();
                localidad = new CN_CodigosPostales().BuscaCodPos(item.idCodPosLabor);
                txtLaboral.Text = txtLaboral.Text + " - " + localidad;
            }
        }

    }
}
