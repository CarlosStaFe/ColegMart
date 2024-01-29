using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FEAFIPLib;


namespace CapaPresentacion.Formularios
{
    public partial class frmLiquidarSociedades : Form
    {
        CN_CtasCtesSoc cN_CtasCtesSoc = new CN_CtasCtesSoc();
        CN_Sociedades cN_Sociedades = new CN_Sociedades();

        public int Nrosoc { get; set; }
        public string Subfijo { get; set; }

        string desde, hasta, dd, mm, yy, yyyy, fechaQR, debitoI, debitoS, tipoFac, detalleLiq, comprobante, ddcae, mmcae, yycae;
        string cae, vtocae, tipoLiq, fechaLiq, tipodoc, cuit, domicilio, telefono, email, estadoSoc, localidad, respuesta;
        string maildestino = string.Empty;
        string password = string.Empty;
        string mailorigen = string.Empty;
        string nombre, prefijo;

        decimal totalAfip, saldoAnt, valorKilo, importeLiq;
        bool senial = true;
        int idSoc, numeroSoc, codpostal, codins, codsem, cuotasAnt, nrocpbte;
        int matri1, matri2, matri3, matri4, documAfip, item, idDebito, id;
        double cuitAfip;
        //---

        string nombrePDF, path, buscar, linea;
        string ddfianza, mmfianza, yyyyfianza, avisofianza;

        DateTime vencefianza, fechanacim, fecestado;

        public frmLiquidarSociedades()
        {
            InitializeComponent();
        }

        private void frmLiquidarSociedades_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            rdbSemestral.Checked = true;
            txtObs.Text = "Informar al colegio el medio de pago y el monto si no paga con esta boleta en el banco, gracias.";
            txtObs.Refresh();
            txtDesde.Select();
        }

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDesde.Text = "60001";
            txtHasta.Text = "69999";
            dtpFechaLiq.Value = DateTime.Now;
            rdbSemestral.Checked = true;
            rdbPrimero.Checked = true;
            rdbSegundo.Checked = true;
            txtValorKilo.Text = string.Empty;
            txtAsunto.Text = string.Empty;
            txtMensaje.Text = string.Empty;
            txtObs.Text = "Informar al colegio el medio de pago y el monto si no paga con esta boleta en el banco, gracias.";
            txtObs.Refresh();
            txtDesde.Select();
        }

        //***** PROCEDIMIENTO DEL BOTÓN SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO VERIFICAR LOS NUMEROS DESDE/HASTA *****
        private void txtHasta_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtDesde.Text) > Convert.ToInt32(txtHasta.Text))
            {
                string mensaje = string.Empty;

                mensaje += "EL NÚMERO DE LA SOCIEDAD HASTA NO PUEDE SER MAYOR A LA SOCIEDAD DESDE...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                txtDesde.Text = "60001";
                txtHasta.Text = "69999";
                txtDesde.Select();
            }
            else
            {
                desde = txtDesde.Text;
                hasta = txtHasta.Text;
            }
        }

        //***** PROCEDIMIENTO PARA OBTENER dd, mm, yyyy *****
        private void dtpFechaLiq_Leave(object sender, EventArgs e)
        {
            ObtenerFecha();
            rdbPrimero.Select();
        }

        //***** PROCEDIMIENTO PARA OBTENER dd, mm, yy, yyyy *****
        private void ObtenerFecha()
        {
            string fecha = new ProcesarFecha().Proceso(dtpFechaLiq.Text);
            dd = new PonerCeros().Proceso(fecha.Substring(0, 2), 2);
            mm = new PonerCeros().Proceso(fecha.Substring(3, 2), 2);
            yyyy = fecha.Substring(6, 4);
            yy = yyyy.Substring(2, 2);
            fechaQR = yyyy + "-" + mm + "-" + dd;
        }

        //***** PROCEDIMIENTO PARA ELEGIR EL PRIMER SEMESTRE *****
        private void rdbPrimero_Click(object sender, EventArgs e)
        {
            mm = "01";
            lblPeriodo.Text = mm + "-" + yyyy;
            txtPeriodo.Text = yyyy + mm;
            lblPeriodo.Refresh();
        }

        //***** PROCEDIMIENTO PARA ELEGIR EL SEGUNDO SEMESTRE *****
        private void rdbSegundo_Click(object sender, EventArgs e)
        {
            mm = "02";
            lblPeriodo.Text = mm + "-" + yyyy;
            txtPeriodo.Text = yyyy + mm;
            lblPeriodo.Refresh();
        }

        //***** PROCEDIMIENTO PARA ELEGIR SEMESTRAL *****
        private void rdbSemestral_Click(object sender, EventArgs e)
        {
            if (rdbPrimero.Checked) mm = "01";
            if (rdbSegundo.Checked) mm = "02";

            lblPeriodo.Text = mm + "-" + yyyy;
            txtPeriodo.Text = yyyy + mm;
            lblPeriodo.Refresh();
        }

        //***** PROCEDIMIENTO PARA ELEGIR LA INSCRIPCION *****
        private void rdbInscripcion_Click(object sender, EventArgs e)
        {
            mm = "00";
            lblPeriodo.Text = mm + "-" + yyyy;
            txtPeriodo.Text = yyyy + mm;
            lblPeriodo.Refresh();
        }

        //***** PROCEDIMIENTO PARA EL BOTON PROCESAR *****
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtValorKilo.Text) == 0)
            {
                MessageBox.Show("DEBE COLOCAR UN VALOR DE KILOS...!!! ");
                txtValorKilo.Focus();
                return;
            }
            if (!rdbPrimero.Checked && !rdbSegundo.Checked)
            {
                MessageBox.Show("DEBE SELECCIONAR UN TIPOD DE LIQUIDACIÓN...!!! ");
                rdbPrimero.Focus();
                return;
            }

            string mensaje = string.Empty;

            tipoLiq = "";
            fechaLiq = dtpFechaLiq.Text;

            if (rdbSemestral.Checked) tipoLiq = "S";
            if (rdbInscripcion.Checked) tipoLiq = "I";

            mensaje += "DESEA INICIAR EL PROCESO DE LIQUIDACIÓN...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dialogo = msg.ShowDialog();
            respuesta = dialogo.ToString();

            if (respuesta == "OK")
            {
                ProcesoGeneral();
            }
            else
            {
                senial = false;
                respuesta = "";
            }

            if (senial)
            {
                mensaje = string.Empty;

                mensaje += "EL PROCESO DE LIQUIDACIÓN HA FINALIZADO...!!!";
                frmMsgBox msj = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialog = msj.ShowDialog();
                respuesta = dialog.ToString();
            }

            txtDesde.Select();
        }

        //***** PROCESO PARA LA LIQUIDACIÓN DE LA SOCIEDAD *****
        private void ProcesoGeneral()
        {
            string mensaje = string.Empty;

            List<CE_Sociedades> LiquidaSoc = new CN_Sociedades().LiquidaSoc(desde, hasta);

            foreach (CE_Sociedades item in LiquidaSoc)
            {
                idSoc = item.id_Soc;
                numeroSoc = item.Numero;
                nombre = item.Nombre;
                tipodoc = item.TipoDoc;
                cuit = item.Cuit;
                cuitAfip = Convert.ToDouble(cuit);
                domicilio = item.Domicilio;
                codpostal = item.idCodPostal;
                codins = item.Inscripcion;
                codsem = item.Semestral;
                telefono = item.Telefono;
                email = item.Email;
                maildestino = item.Email.Trim();
                maildestino = "carlos.a.mayans@gmail.com";
                estadoSoc = item.Estado;
                matri1 = item.Martillero1;
                matri2 = item.Martillero2;
                matri3 = item.Martillero3;
                matri4 = item.Martillero4;
                debitoS = string.Empty;
                debitoI = string.Empty;

                saldoAnt = 0;
                tipoFac = "FAC";
                prefijo = "0004";
                BuscoLocalidad();

                switch (estadoSoc)
                {
                    case "BAJA":            //***** baja por desición del directorio
                        break;
                    case "SUSPENDIDA":      //***** pidió deshabilitar por falta de pago, no se liquida
                        CambiarEstado(numeroSoc, "MOROSA");
                        break;
                    case "MOROSA":          //***** no realizó ningún pago, no se liquida, se envió 1ra carta/reclamo
                        break;
                    case "ACTIVA":          //***** se liquida, se controla saldo, cant. de cuotas impagas y fianza

                        cuotasAnt = ContarDeuda(numeroSoc);      //***** calculo la cantidad de períodos adeudados
                        saldoAnt = CalcularSaldo(numeroSoc);     //***** calculo el importe total adeudado

                        if (cuotasAnt < nudCuotas.Value)
                        {
                            //ProcesoLiquidacion();
                            PruebaLiquidacion();
                        }
                        else
                        {
                            tipoFac = "RCL1";
                            BuscoComprobante();
                            GraboDeuda();
                            EnviarReclamo();
                            GraboCpbte();
                            CambiarEstado(numeroSoc, "SUSPENDIDA");
                        }
                        break;
                }
                senial = true;
            }
        }

        //***** PROCESO PARA REALIZAR LA FACTURA DE PRUEBA *****
        private void PruebaLiquidacion()
        {
            /* Los nombres de los parametros de las funciones se obtienen descomprimiendo FEAFIP DOC
                y luego abriendo el archivo index.html de la carpeta "Doc Interfaces".
                la interfaz correspondiente a este ejemplo es Iwsfev1 para facturas A y B.*/
            const
            //URLs de autenticacion y negocio. Cambiarlas por las de producción al implementarlas en el cliente(abajo)
            string URLWSAA = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
            // Desarrollo: https://wsaahomo.afip.gov.ar/ws/services/LoginCms
            string URLWSW = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";
            // Desarrollo: https://wswhomo.afip.gov.ar/wsfev1/service.asmx

            // Agregar FEAFIPlib como referencia al proyecto desde el menu y luego en el using.

            string CAE = "";
            string Vencimiento = "";
            string Resultado = "";
            string Reproceso = "";
            double nro = 0;
            double total = 0;
            int PtoVta = 4;
            int TipoComp = 11; // Factura C(ir a http://www.bitingenieria.com.ar/codigos.html)
            string FechaComp = DateTime.Today.ToString("yyyyMMdd");

            wsfev1 lwsfev1 = new wsfev1();
            lwsfev1.CUIT = 20939802593;
            lwsfev1.URL = URLWSW;
            if (lwsfev1.login("certificado.crt", "clave.key", URLWSAA))
            {
                if (lwsfev1.SFRecuperaLastCMP(PtoVta, TipoComp) == false)
                {
                    MessageBox.Show(lwsfev1.ErrorDesc);
                }
                else
                {
                    nro = lwsfev1.SFLastCMP + 1;
                    comprobante = new PonerCeros().Proceso(Convert.ToString(nro), 8);    // muevo el comprobante recuperado de AFIP 

                    //***** PROCESO GENERAL PARA LIQUIDAR LA SOCIEDAD *****
                    senial = true;

                    GraboDetalle();
                    GraboLiquidacion();
                    GraboCpbte();

                    if (senial)
                    {
                        lwsfev1.Reset();
                        total = Convert.ToDouble(totalAfip);

                        lwsfev1.AgregaFactura(3, documAfip, cuitAfip, nro, nro, FechaComp, total, 0, total, 0, FechaComp, FechaComp, FechaComp, "PES", 1);
                        //lwsfev1.AgregaIVA(3, 0, 0); 

                        if (lwsfev1.Autorizar(PtoVta, (int)FEAFIPLib.TipoComprobante.tcFacturaC))
                        {
                            lwsfev1.AutorizarRespuesta(0, out CAE, out Vencimiento, out Resultado, out Reproceso);
                            if (Resultado == "A")
                            {
                                cae = CAE;
                                vtocae = Vencimiento;
                                MessageBox.Show("Felicitaciones! Si ve este mensaje instalo correctamente FEAFIP. CAE y Vencimiento "
                                    + ":" + CAE + " " + Vencimiento);
                                ExportarPDF();
                            }
                            else
                            {
                                MessageBox.Show(lwsfev1.AutorizarRespuestaObs(0));
                            }
                        }
                        else
                        {
                            MessageBox.Show(lwsfev1.ErrorDesc);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(lwsfev1.ErrorDesc);
            }
        }


        //***** CUENTO LA CANTIDAD DE PERÍODOS ADEUDADOS *****
        int ContarDeuda(int numerosoc)
        {
            var cuotas = cN_CtasCtesSoc.ContarDeuda(numerosoc);

            return cuotas;
        }

        //***** CALCULO EL SALDO DEL COLEGIADO EN LA CUENTA CORRIENTE *****
        decimal CalcularSaldo(int numerosoc)
        {
            var saldo = cN_CtasCtesSoc.CalcularSaldo(numerosoc);

            return saldo;
        }

        //***** BUSCO DETALLE E IMPORTE DEL CÓDIGO A DEBITAR *****
        private void GraboDetalle()
        {
            string mensaje = string.Empty;
            item = 0;
            totalAfip = 0;
            valorKilo = (Convert.ToDecimal(txtValorKilo.Text) / 100);

            if (rdbInscripcion.Checked)
            {
                debitoI = Convert.ToString(codins);
                debitoS = "0";
            }
            else
            {
                debitoS = Convert.ToString(codsem);
                debitoI = "0";
            }

            List<CE_Debitos> BuscoDebito = new CN_Debitos().BuscoDebito(debitoI, debitoS);

            foreach (CE_Debitos linea in BuscoDebito)
            {
                item = item + 1;
                idDebito = linea.id_Debito;
                detalleLiq = linea.Detalle;
                importeLiq = valorKilo * linea.Kilos;
                importeLiq = Math.Round(importeLiq, 0);

                CE_DetalleLiqui cE_DetalleLiqui = new CE_DetalleLiqui()
                {
                    Prefijo = prefijo,
                    Subfijo = comprobante,
                    Item = item,
                    Codigo = linea.Codigo,
                    Detalle = detalleLiq,
                    Importe = importeLiq,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                totalAfip = totalAfip + importeLiq;
                int idDetLiq = new CN_DetalleLiqui().Registrar(cE_DetalleLiqui, out mensaje);

                if (totalAfip > 0)
                {
                    GraboCtaCte();
                    GraboVentas();
                }
            }

            if (totalAfip > 0)
            {
                GraboDeuda();
                BuscarTipoDoc();
            }
        }

        //***** PROCESO PARA GRABAR LA CUENTA CORRIENTE DE LOS MATRICULADOS *****
        private void GraboCtaCte()
        {
            string mensaje = string.Empty;

            // ACÁ CALCULAR EL SALDO SI TIENE A FAVOR POR PAGOS ADELANTADOS

            CE_CtasCtesSoc cE_CtasCtesSoc = new CE_CtasCtesSoc()
            {
                id_CtaCte = 0,
                Numero = numeroSoc,
                Fecha = dtpFechaLiq.Value,
                Tipo = tipoFac,
                Prefijo = prefijo,
                Subfijo = comprobante,
                Item = item,
                fk_idDebito = idDebito,
                Detalle = detalleLiq,
                Periodo = txtPeriodo.Text,
                Debe = importeLiq,
                Pagado = 0,
                FechaPago = Convert.ToDateTime("1/1/1900"),
                Saldo = importeLiq,
                Estado = "PENDIENTE",
                Obs = "",
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idCtaCte = new CN_CtasCtesSoc().Registrar(cE_CtasCtesSoc, out mensaje);
        }

        //***** PROCESO PARA GRABAR LA TABLA DE VENTAS *****
        private void GraboVentas()
        {
            string mensaje = string.Empty;

            CE_Ventas cE_Ventas = new CE_Ventas()
            {
                id_Venta = 0,
                Fecha = dtpFechaLiq.Value,
                Tipo = tipoFac,
                Prefijo = "0004",
                Subfijo = comprobante,
                Item = item,
                Detalle = detalleLiq,
                Importe = importeLiq,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idVenta = new CN_Ventas().Registrar(cE_Ventas, out mensaje);
        }

        //***** PROCESO PARA GRABAR LA DEUDA *****
        private void GraboDeuda()
        {
            if (cuotasAnt != 0)
            {
                List<CE_CtasCtesSoc> ListaDeuda = new CN_CtasCtesSoc().ListaDeuda(numeroSoc);

                foreach (var item in ListaDeuda)
                {
                    string mensaje = string.Empty;

                    if (item.Subfijo != comprobante)
                    {
                        CE_DeudaLiqui cE_DeudaLiqui = new CE_DeudaLiqui()
                        {
                            Prefijo = prefijo,
                            Subfijo = comprobante,
                            Fecha = item.Fecha,
                            Tipo = item.Tipo,
                            Comprobante = item.Subfijo,
                            Item = item.Item,
                            Detalle = item.Detalle,
                            Periodo = item.Periodo,
                            Importe = item.Debe,
                            Pagado = item.Pagado,
                            FechaPago = item.FechaPago,
                            Saldo = item.Saldo,
                            UserRegistro = CE_UserLogin.Usuario,
                            FechaRegistro = DateTime.Today
                        };

                        int idDeuda = new CN_DeudaLiqui().Registrar(cE_DeudaLiqui, out mensaje);
                    }
                }
            }
        }

        //***** BUSCO CÓDIGO POSTAL, LOCALIDAD, DEPTO. Y PROVINCIA DEL COLEGIADO *****
        private void BuscarTipoDoc()
        {
            if (tipodoc == "CUIT") documAfip = 80;
            if (tipodoc == "CUIL") documAfip = 86;
            if (tipodoc == "CDI") documAfip = 87;
            if (tipodoc == "LE") documAfip = 89;
            if (tipodoc == "LC") documAfip = 90;
            if (tipodoc == "DNI") documAfip = 96;
        }

        //***** BUSCO CÓDIGO POSTAL, LOCALIDAD, DEPTO. Y PROVINCIA DEL COLEGIADO *****
        private void BuscoLocalidad()
        {
            localidad = string.Empty;
            localidad = new CN_CodigosPostales().BuscaCodPos(codpostal);
        }

        //***** PROCESO DE LIQUIDACIÓN CATEGORÍAS A Y B *****
        private void GraboLiquidacion()
        {
            string mensaje = string.Empty;

            CE_Liquidacion cE_Liquidacion = new CE_Liquidacion()
            {
                Matricula = numeroSoc,
                ApelNombres = nombre,
                Fecha = dtpFechaLiq.Value,
                Tipo = tipoFac,
                Prefijo = "0004",
                Subfijo = comprobante,
                Domicilio = domicilio,
                Localidad = localidad,
                Periodo = txtPeriodo.Text,
                Total = totalAfip,
                CodigoBarra = "",
                NumeroPago = "",
                Email = email,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idLiqui = new CN_Liquidacion().Registrar(cE_Liquidacion, out mensaje);
            id = idLiqui;
        }

        //***** PROCESO PARA GRABAR EL NÚMERO DE COMPROBANTE UTILIZADO *****
        private void GraboCpbte()
        {
            nrocpbte = Convert.ToInt32(comprobante);
            var ok = new CN_Comprobantes().GraboCpbte(tipoFac, nrocpbte);
        }

        //***** BUSCO EL NÚMERO DE COMPROBANTE DE LA LIQUIDACIÓN *****
        private void BuscoComprobante()
        {
            nrocpbte = new CN_Comprobantes().BuscoCpbte(tipoLiq);
            comprobante = Convert.ToString(nrocpbte + 1);
            comprobante = new PonerCeros().Proceso(comprobante, 8);
        }

        //***** PROCESO PARA GENERAR EL PDF DE LA LIQUIDACIÓN *****
        private void ExportarPDF()
        {
            string numero = new PonerCeros().Proceso(Convert.ToString(numeroSoc), 5);
            nombrePDF = numero + "-" + txtPeriodo.Text + ".pdf";

            spLiquidacionTableAdapter.Fill(dataSetPrincipal.spLiquidacion, numeroSoc);
            spDetalleLiquiTableAdapter.Fill(dataSetPrincipal.spDetalleLiqui, Convert.ToInt32(prefijo), Convert.ToInt32(Subfijo));
            spDeudaLiquiTableAdapter.Fill(dataSetPrincipal.spDeudaLiqui, prefijo, Subfijo);

            reportLiquidacion.RefreshReport();

            reportLiquidacion.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spLiquidacionBindingSource));
            reportLiquidacion.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spDetalleLiquiBindingSource));
            reportLiquidacion.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spDeudaLiquiBindingSource));

            FechaVtoCae();
            GenerarQR();
            avisofianza = "";

            ReportParameter[] parametros = new ReportParameter[6];
            parametros[0] = new ReportParameter("prmObsFianza", avisofianza);
            parametros[1] = new ReportParameter("prmObsGral", txtObs.Text);
            parametros[2] = new ReportParameter("prmCae", cae);
            parametros[3] = new ReportParameter("prmVtoCae", vtocae);
            parametros[4] = new ReportParameter("prmFecha", fechaLiq);
            parametros[5] = new ReportParameter("prmCuit", Convert.ToString(cuit));

            reportLiquidacion.LocalReport.SetParameters(parametros);

            byte[] bytes = reportLiquidacion.LocalReport.Render("PDF");

            buscar = "PathBoletas";
            linea = new LeerConfig().Proceso(buscar);
            path = linea + nombrePDF;

            var newFile = new FileStream(path, FileMode.Create);

            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();

            buscar = "MailOrigen";
            mailorigen = new LeerConfig().Proceso(buscar);

            buscar = "PasswordMail";
            password = new LeerConfig().Proceso(buscar);

            maildestino = "carlos.a.mayans@gmail.com";            //*** mail para pruebas

            bool enviado = new EnviarCorreo().EnviarMail(mailorigen, password, maildestino, txtAsunto.Text, txtMensaje.Text, path);

            if (enviado == false)
            {
                string mensaje = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append("NO SE ENVIÓ EL MAIL CON LIQUIDACIÓN...!!!");
                sb.Append("Sociedad: " + numero + " - " + nombre);
                sb.Append("Email: " + maildestino);
                mensaje = sb.ToString();
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                respuesta = dialogo.ToString();
            }
        }

        //***** PROCESO PARA CONTROLAR EL VENCIMIENTO DE LA FIANZA *****
        private void ControlFianza()
        {
            string fecha = new ProcesarFecha().Proceso(Convert.ToString(vencefianza));
            ddfianza = new PonerCeros().Proceso(fecha.Substring(0, 2), 2);
            mmfianza = new PonerCeros().Proceso(fecha.Substring(3, 2), 2);
            yyyyfianza = fecha.Substring(6, 4);
            avisofianza = "";

            if (int.Parse(mm) == int.Parse(mmfianza) && int.Parse(yyyy) == int.Parse(yyyyfianza))
            {
                avisofianza = "SU FIANZA VENCE EL: " + ddfianza + "/" + mmfianza + "/" + yyyyfianza;
            }
            else if (int.Parse(mm) > int.Parse(mmfianza) && (int.Parse(yyyy) == int.Parse(yyyyfianza) || int.Parse(yyyy) > int.Parse(yyyyfianza)))
            {
                avisofianza = "SU FIANZA ESTÁ VENCIDA DESDE EL: " + ddfianza + "/" + mmfianza + "/" + yyyyfianza;
                CambiarEstado(numeroSoc, "INACTIVA");
            }
            else if (int.Parse(yyyy) < int.Parse(yyyyfianza))
            {
                avisofianza = string.Empty;
            }
        }

        //***** PROCESO PARA ENVIAR LA PRIMER CARTA DE RECLAMO *****
        private void EnviarReclamo()
        {
            string numero = new PonerCeros().Proceso(Convert.ToString(numeroSoc), 5);
            nombrePDF = numero + "-" + txtPeriodo.Text + ".pdf";

            spDeudaLiquiTableAdapter.Fill(dataSetPrincipal.spDeudaLiqui, prefijo, Subfijo);

            reportReclamo.RefreshReport();

            reportReclamo.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spDeudaLiquiBindingSource));

            ReportParameter[] parametros = new ReportParameter[6];
            parametros[0] = new ReportParameter("prmNumero", Convert.ToString(numero));
            parametros[1] = new ReportParameter("prmNombre", nombre);
            parametros[2] = new ReportParameter("prmDomicilio", domicilio);
            parametros[3] = new ReportParameter("prmLocalidad", localidad);
            parametros[4] = new ReportParameter("prmComprobante", comprobante);
            parametros[5] = new ReportParameter("prmTesorero", txtTesorero.Text);

            reportReclamo.LocalReport.SetParameters(parametros);

            byte[] bytes = reportReclamo.LocalReport.Render("PDF");

            buscar = "PathReclamo1";
            linea = new LeerConfig().Proceso(buscar);
            path = linea + nombrePDF;

            var newFile = new FileStream(path, FileMode.Create);

            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();

            buscar = "MailOrigen";
            mailorigen = new LeerConfig().Proceso(buscar);

            buscar = "PasswordMail";
            password = new LeerConfig().Proceso(buscar);

            maildestino = "carlos.a.mayans@gmail.com";       //*** mail para pruebas

            bool enviado = new EnviarCorreo().EnviarMail(mailorigen, password, maildestino, txtAsunto.Text, txtMensaje.Text, path);

            if (enviado == false)
            {
                string mensaje = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append("NO SE ENVIÓ EL MAIL DEL PRIMER RECLAMO...!!!");
                sb.Append("Matrícula: " + numero + " - " + nombre);
                sb.Append("Email: " + maildestino);
                mensaje = sb.ToString();
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                respuesta = dialogo.ToString();
            }
        }

        //***** PROCESO PARA CAMBIAR EL ESTADO DEL COLEGIADO *****
        private void CambiarEstado(int numero, string estado)
        {
            bool cambio = cN_Sociedades.ActualizarEstado(numero, estado);
        }

        //***** PROCESO PARA REALIZAR LA FACTURA DE AFIP *****
        private void GenerarQR()
        {
            QrAfip.IQr Qr = new QrAfip.Qr();
            Qr.ArchivoQR = Qr.RutaLibreria + "qr.png";
            Int32 ver = 1;
            String fecha = fechaQR;
            Double cuit = 30999007283;
            Int32 ptoVta = 4;
            Int32 tipoComp = 11;
            Int32 nroCmp = Convert.ToInt32(comprobante);
            Double importe = Convert.ToDouble(totalAfip);
            String moneda = "PES";
            Double ctz = 1.0;
            Int32 tipoDocRec = documAfip;
            Double nroDocRec = cuitAfip;
            String tipoCodAut = "E";  // A = CAEA E = CAE
            Double codAut = Convert.ToDouble(cae);
            if (Qr.Generar(ver, fecha, cuit, ptoVta, tipoComp, nroCmp, importe, moneda, ctz, tipoDocRec, nroDocRec, tipoCodAut, codAut))
            {
                MessageBox.Show("QR generado con éxito");
            }
            else
            {
                MessageBox.Show(Qr.ErrorDesc);
            }
        }

        //***** PROCESO PARA CAMBIAR LA FECHA DEL VTO DEL CAE *****
        private void FechaVtoCae()
        {
            yycae = new PonerCeros().Proceso(vtocae.Substring(0, 4), 4);
            mmcae = new PonerCeros().Proceso(vtocae.Substring(4, 2), 2);
            ddcae = new PonerCeros().Proceso(vtocae.Substring(6, 2), 2);
            vtocae = ddcae + "/" + mmcae + "/" + yycae;
        }

        private void ProcesoLiquidacion()
        {
            /* Los nombres de los parametros de las funciones se obtienen descomprimiendo FEAFIP DOC
                y luego abriendo el archivo index.html de la carpeta "Doc Interfaces".
                la interfaz correspondiente a este ejemplo es Iwsfev1 para facturas A y B.*/
            const
            //URLs de autenticacion y negocio. Cambiarlas por las de producción al implementarlas en el cliente(abajo)
            string URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
            // Producción: https://wsaa.afip.gov.ar/ws/services/LoginCms
            string URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx";
            // Producción: https://servicios1.afip.gov.ar/wsfev1/service.asmx

            // Agregar FEAFIPlib como referencia al proyecto desde el menu y luego en el using.

            string CAE = "";
            string Vencimiento = "";
            string Resultado = "";
            string Reproceso = "";
            double nro = 0;
            double total = Convert.ToDouble(totalAfip);
            int PtoVta = 4;
            int TipoComp = 11; // Factura C(ir a http://www.bitingenieria.com.ar/codigos.html)
            string FechaComp = DateTime.Today.ToString("yyyyMMdd");

            wsfev1 lwsfev1 = new wsfev1();
            lwsfev1.CUIT = 30999007283;
            lwsfev1.URL = URLWSW;
            if (lwsfev1.login("ColMart_193c78ccf85efd12.crt", "MiClave.key", URLWSAA))
            {
                if (lwsfev1.SFRecuperaLastCMP(PtoVta, TipoComp) == false)
                {
                    MessageBox.Show(lwsfev1.ErrorDesc);
                }
                else
                {
                    nro = lwsfev1.SFLastCMP + 1;
                    comprobante = new PonerCeros().Proceso(Convert.ToString(nro), 8);    // muevo el comprobante recuperado de AFIP 

                    lwsfev1.Reset();
                    lwsfev1.AgregaFactura(3, 80, 30508664180, nro, nro, FechaComp, total, 0, total, 0, FechaComp, FechaComp, FechaComp, "PES", 1);
                    //lwsfev1.AgregaIVA(3, 0, 0); -------NO SE DECLARA

                    if (lwsfev1.Autorizar(PtoVta, (int)FEAFIPLib.TipoComprobante.tcFacturaC))
                    {
                        lwsfev1.AutorizarRespuesta(0, out CAE, out Vencimiento, out Resultado, out Reproceso);
                        if (Resultado == "A")
                        {
                            cae = CAE;
                            vtocae = Vencimiento;
                            //MessageBox.Show("Felicitaciones! Si ve este mensaje instalo correctamente FEAFIP. CAE y Vencimiento "
                            //    + ":" + CAE + " " + Vencimiento);
                        }
                        else
                        {
                            MessageBox.Show(lwsfev1.AutorizarRespuestaObs(0));
                        }
                    }
                    else
                    {
                        MessageBox.Show(lwsfev1.ErrorDesc);
                    }
                }
            }
            else
            {
                MessageBox.Show(lwsfev1.ErrorDesc);
            }
        }





    }

}
