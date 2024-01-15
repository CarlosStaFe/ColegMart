using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmLiquidarColegiados : Form
    {
        CN_CtasCtesColeg cN_CtasCtesColeg = new CN_CtasCtesColeg();
        CN_Colegiados cN_Colegiados = new CN_Colegiados();

        public int matri { get; set; }
        public string subfijo { get; set; }

        string dd, mm, yy, yyyy, debitoAB, debitoI, tipoliq, codigoiapos, respuesta, desde, hasta;
        string categoria, tipo, prefijo, email, nombrePDF, path, buscar, linea, apelnombres, domicilio, estado;
        string ddfianza, mmfianza, yyyyfianza, mmcumple, avisofianza, avisocumple;
        string codigopago, localidad, comprobante, detalle;
        DateTime vencefianza, fechanacim, juramento, fecestado;
        object CodigoTotal, CodigoBarra;
        decimal saldo, total, importe;
        int cuotas, idColeg, matricula, codpos, item, nrocpbte, idDebito, id;
        bool senial = true;
        string password = string.Empty;
        string mailorigen = string.Empty;
        string maildestino = string.Empty;
        string cae, vtocae, ddcae, mmcae, yycae,fechaliq,cuit;

        public frmLiquidarColegiados()
        {
            InitializeComponent();
        }

        private void frmLiquidarColegiados_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            rdbMatricula.Checked = true;
            txtObs.Text = "Informar al colegio el medio de pago y el monto si no paga con esta boleta en el banco, gracias.";
            txtDesde.Select();
        }

        //***** PROCEDIMIENTO DEL BOTÓN LIMPIAR *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDesde.Text = "0";
            txtHasta.Text = "60000";
            dtpFechaLiq.Value = DateTime.Now;
            rdbMatricula.Checked = true;
            nudCuotasMat.Value = 3;
            nudCuotasIapos.Value = 1;
            txtAsunto.Text = string.Empty;
            txtMensaje.Text = string.Empty;
            txtObs.Text = "Informar al colegio el medio de pago y el monto si no paga con esta boleta en el banco, gracias.";
            txtDesde.Select();
        }

        //***** PROCEDIMIENTO DEL BOTÓN SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO PARA OBTENER dd, mm, yyyy *****
        private void dtpFechaLiq_Leave(object sender, EventArgs e)
        {
            ObtenerFecha();
        }

        //***** PROCEDIMIENTO VERIFICAR MATRICULAS DESDE/HASTA *****
        private void txtHasta_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtDesde.Text) > Convert.ToInt32(txtHasta.Text))
            {
                string mensaje = string.Empty;

                mensaje += "LA MATRÍCULA HASTA NO PUEDE SER MAYOR A LA MATRÍCULA DESDE...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                txtDesde.Text = "0";
                txtHasta.Text = "60000";
                txtDesde.Select();
            }
            else
            {
                desde = txtDesde.Text;
                hasta = txtHasta.Text;
            }
        }

        //***** PROCEDIMIENTO PARA OBTENER dd, mm, yy, yyyy *****
        private void ObtenerFecha()
        {
            string fecha = new ProcesarFecha().Proceso(dtpFechaLiq.Text);
            dd = new PonerCeros().Proceso(fecha.Substring(0, 2), 2);
            mm = new PonerCeros().Proceso(fecha.Substring(3, 2), 2);
            yyyy = fecha.Substring(6, 4);
            yy = yyyy.Substring(2, 2);

            lblPeriodo.Text = mm + "-" + yyyy;
            txtPeriodo.Text = yyyy + mm;
        }

        //***** PROCEDIMIENTO PARA EL BOTON PROCESAR *****
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            tipoliq = "";
            fechaliq = dtpFechaLiq.Text;

            if (rdbMatricula.Checked && codigoiapos == "") tipoliq = "M";
            if (rdbIapos.Checked && codigoiapos != "") tipoliq = "I";
            if (rdbTodos.Checked) tipoliq = "T";

            string mensaje = string.Empty;

            mensaje += "DESEA INICIAR EL PROCESO DE LIQUIDACIÓN...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dialogo = msg.ShowDialog();
            respuesta = dialogo.ToString();

            if (respuesta == "OK")
            {
                List<CE_Colegiados> LiquidaColeg = new CN_Colegiados().LiquidaColeg(desde, hasta);

                foreach (CE_Colegiados item in LiquidaColeg)
                {
                    idColeg = item.id_Coleg;
                    matricula = item.Matricula;
                    apelnombres = item.ApelNombres;
                    domicilio = item.DomParti;
                    categoria = item.Categoria;
                    codigoiapos = item.CodigoIapos;
                    codpos = item.idCodPosParti;
                    vencefianza = item.FecVenceFianza;
                    fechanacim = item.FechaNacim;
                    juramento = item.Juramento;
                    fecestado = item.FecEstado;
                    estado = item.Estado;
                    email = item.Email;
                    //maildestino = "carlos.a.mayans@gmail.com";
                    maildestino = item.Email.Trim();
                    cuit = item.Cuit;
                    debitoAB = string.Empty;
                    debitoI = string.Empty;

                    if (categoria == "A") debitoAB = "3";
                    if (categoria == "B") debitoAB = "4";
                    if (categoria == "I") debitoI = codigoiapos;

                    saldo = 0;
                    cuotas = 0;
                    tipo = "LIQ";
                    prefijo = "0000";
                    BuscoLocalidad();

                    switch (estado)
                    {
                        case "BAJA":            //***** baja por fallecimiento, no se liquida
                            break;
                        case "SUSPENDIDO":      //***** pidió deshabilitar la matrícula, no se liquida
                            break;
                        case "MOROSO":          //***** no realizó ningún pago, no se liquida, se envió 2da carta/reclamo
                            break;
                        case "SUSP.MOROSO":     //***** más de 3 períodos impagos, no se liquida, se envió 1er carta/reclamo
                            //BuscoLocalidad();
                            tipo = "RCL2";
                            BuscoComprobante();
                            EnviarReclamo2();
                            GraboCpbte();
                            CambiarEstado(matricula, "MOROSO");
                            break;
                        case "INACTIVO":        //***** sin fianza activa
                            break;
                        case "ACTIVO":          //***** se liquida, se controla saldo, cant. de cuotas impagas y fianza

                            cuotas = ContarDeuda(idColeg);      //***** calculo la cantidad de períodos adeudados
                            saldo = CalcularSaldo(idColeg);     //***** calculo el importe total adeudado

                            if (cuotas < nudCuotasMat.Value)    // && rdbMatricula.Checked)
                            {
                                GraboDetalle();
                                SepararCodigo();
                                GraboLiquidacionAB();
                                GraboCpbte();
                                ControlFianza();
                                ControlCumple();
                                ExportarPDF();
                            }
                            else
                            {
                                tipo = "RCL1";
                                BuscoComprobante();
                                GraboDeuda();
                                EnviarReclamo1();
                                GraboCpbte();
                                CambiarEstado(matricula, "SUSP.MOROSO");
                            }
                            break;
                    }
                    senial = true;
                }
            }
            else
            {
                senial = false;
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

        //***** CUENTO LA CANTIDAD DE PERÍODOS ADEUDADOS *****
        int ContarDeuda(int idColeg)
        {
            var cuotas = cN_CtasCtesColeg.ContarDeuda(idColeg);

            return cuotas;
        }

        //***** CALCULO EL SALDO DEL COLEGIADO EN LA CUENTA CORRIENTE *****
        decimal CalcularSaldo(int idColeg)
        {
            var saldo = cN_CtasCtesColeg.CalcularSaldo(idColeg);

            return saldo;
        }

        //***** BUSCO DETALLE E IMPORTE DEL CÓDIGO A DEBITAR *****
        private void GraboDetalle()
        {
            string mensaje = string.Empty;
            item = 0;
            total = 0;

            List<CE_Debitos> BuscoDebito = new CN_Debitos().BuscoDebito(debitoAB, debitoI);

            foreach (CE_Debitos linea in BuscoDebito)
            {
                if (rdbTodos.Checked == false)
                {
                    if (rdbMatricula.Checked && codigoiapos != "")
                    {
                        continue;
                    }

                    if (rdbIapos.Checked && codigoiapos == "")
                    {
                        continue;
                    }
                }

                item = item + 1;
                idDebito = linea.id_Debito;
                detalle = linea.Detalle;
                importe = linea.Importe;

                CE_DetalleLiqui cE_DetalleLiqui = new CE_DetalleLiqui()
                {
                    Prefijo = prefijo,
                    Subfijo = comprobante,
                    Item = item,
                    Codigo = linea.Codigo,
                    Detalle = detalle,
                    Importe = linea.Importe,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                GraboDeuda();
                GraboCtaCte();
                GraboVentas();

                total = total + linea.Importe;
                int idDetLiq = new CN_DetalleLiqui().Registrar(cE_DetalleLiqui, out mensaje);
            }
        }

        //***** BUSCO CÓDIGO POSTAL, LOCALIDAD, DEPTO. Y PROVINCIA DEL COLEGIADO *****
        private void BuscoLocalidad()
        {
            localidad = string.Empty;
            localidad = new CN_CodigosPostales().BuscaCodPos(codpos);
        }

        //***** BUSCO EL NÚMERO DE COMPROBANTE DE LA LIQUIDACIÓN *****
        private void BuscoComprobante()
        {
            nrocpbte = new CN_Comprobantes().BuscoCpbte(tipo);
            comprobante = Convert.ToString(nrocpbte + 1);
            comprobante = new PonerCeros().Proceso(comprobante, 8);
        }

        //***** PROCESO PARA GRABAR LA DEUDA *****
        private void GraboDeuda()
        {
            if (cuotas != 0)
            {
                List<CE_CtasCtesColeg> ListaDeuda = new CN_CtasCtesColeg().ListaDeuda(matricula);

                foreach (var item in ListaDeuda)
                {
                    string mensaje = string.Empty;

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

        //***** PROCESO PARA GRABAR LA CUENTA CORRIENTE DE LOS MATRICULADOS *****
        private void GraboCtaCte()
        {
            string mensaje = string.Empty;

            // ACÁ CALCULAR EL SALDO SI TIENE A FAVOR POR PAGOS ADELANTADOS

            CE_CtasCtesColeg cE_CtasCtesColeg = new CE_CtasCtesColeg()
            {
                id_CtaCte = 0,
                fk_idColeg = Convert.ToInt32(idColeg),
                Matricula = matricula,
                Fecha = dtpFechaLiq.Value,
                Tipo = tipo,
                Prefijo = prefijo,
                Subfijo = comprobante,
                Item = item,
                fk_idDebito = idDebito,
                Detalle = detalle,
                Periodo = txtPeriodo.Text,
                Debe = importe,
                Pagado = 0,
                FechaPago = Convert.ToDateTime("1/1/1900"),
                Saldo = importe,
                Estado = "PENDIENTE",
                Obs = "",
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idCtaCte = new CN_CtasCtesColeg().Registrar(cE_CtasCtesColeg, out mensaje);
        }

        //***** PROCESO PARA GRABAR LA TABLA DE VENTAS *****
        private void GraboVentas()
        {
            string mensaje = string.Empty;

            CE_Ventas cE_Ventas = new CE_Ventas()
            {
                id_Venta = 0,
                Fecha = dtpFechaLiq.Value,
                Tipo = tipo,
                Prefijo = "0000",
                Subfijo = comprobante,
                Detalle = detalle,
                Importe = importe,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idVenta = new CN_Ventas().Registrar(cE_Ventas, out mensaje);
        }

        //***** PROCESO PARA SEPARAR EL CÓDIGO DE BARRA Y EL CÓDIGO DE PAGO *****
        private void SepararCodigo()
        {
            string matri = Convert.ToString(matricula);
            CodigoTotal = new ArmarCodigoBarra().ArmaCodigoBarra(matri, mm, yyyy, total, dd, mm, yy);

            int pos1 = CodigoTotal.ToString().IndexOf("*");

            CodigoBarra = CodigoTotal.ToString().Substring(0, pos1);
            codigopago = CodigoTotal.ToString().Substring(pos1 + 1);
        }

        //***** PROCESO DE LIQUIDACIÓN CATEGORÍAS A Y B *****
        private void GraboLiquidacionAB()
        {
            string mensaje = string.Empty;

            CE_Liquidacion cE_Liquidacion = new CE_Liquidacion()
            {
                Matricula = matricula,
                ApelNombres = apelnombres,
                Fecha = dtpFechaLiq.Value,
                Tipo = tipo,
                Prefijo = "0001",
                Subfijo = comprobante,
                Domicilio = domicilio,
                Localidad = localidad,
                Periodo = txtPeriodo.Text,
                Total = total,
                CodigoBarra = CodigoBarra.ToString(),
                NumeroPago = codigopago.ToString(),
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
            var ok = new CN_Comprobantes().GraboCpbte(tipo, nrocpbte);
        }

        //***** PROCESO PARA GENERAR EL PDF DE LA LIQUIDACIÓN *****
        private void ExportarPDF()
        {
            string matri = new PonerCeros().Proceso(Convert.ToString(matricula), 5);
            nombrePDF = matri + "-" + txtPeriodo.Text + ".pdf";

            spLiquidacionTableAdapter.Fill(dataSetPrincipal.spLiquidacion, matricula);
            spDetalleLiquiTableAdapter.Fill(dataSetPrincipal.spDetalleLiqui, prefijo, subfijo);
            spDeudaLiquiTableAdapter.Fill(dataSetPrincipal.spDeudaLiqui, prefijo, subfijo);

            reportLiquidacion.RefreshReport();

            reportLiquidacion.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spLiquidacionBindingSource));
            reportLiquidacion.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spDetalleLiquiBindingSource));
            reportLiquidacion.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spDeudaLiquiBindingSource));

            FechaVtoCae();

            ReportParameter[] parametros = new ReportParameter[7];
            parametros[0] = new ReportParameter("prmObsFianza", avisofianza);
            parametros[1] = new ReportParameter("prmObsCumple", avisocumple);
            parametros[2] = new ReportParameter("prmObsGral", txtObs.Text);
            parametros[3] = new ReportParameter("prmCae", cae);
            parametros[4] = new ReportParameter("prmVtoCae", vtocae);
            parametros[5] = new ReportParameter("prmFecha", fechaliq);
            parametros[6] = new ReportParameter("prmCuit", cuit);

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
                sb.Append("Matrícula: " + matricula + " - " + apelnombres);
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
                CambiarEstado(matricula, "INACTIVO");
            }
            else if (int.Parse(yyyy) < int.Parse(yyyyfianza))
            {
                avisofianza = string.Empty;
            }
        }

        //***** PROCESO PARA CONTROLAR EL MES DEL CUMPLEAÑOS *****
        private void ControlCumple()
        {
            string fecha = new ProcesarFecha().Proceso(Convert.ToString(fechanacim));
            mmcumple = new PonerCeros().Proceso(fecha.Substring(3, 2), 2);
            avisocumple = "";

            if (mmcumple == mm)
            {
                avisocumple = "EN ESTE SU MES, LE DESAMOS UN MUY FELIZ CUMPLEAÑOS...!!!";
            }
            else
            {
                avisocumple = string.Empty;
            }
        }

        //***** PROCESO PARA ENVIAR LA PRIMER CARTA DE RECLAMO *****
        private void EnviarReclamo1()
        {
            string matri = new PonerCeros().Proceso(Convert.ToString(matricula), 5);
            nombrePDF = matri + "-" + txtPeriodo.Text + ".pdf";

            spDeudaLiquiTableAdapter.Fill(dataSetPrincipal.spDeudaLiqui, prefijo, subfijo);

            reportReclamo1.RefreshReport();

            reportReclamo1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spDeudaLiquiBindingSource));

            ReportParameter[] parametros = new ReportParameter[6];
            parametros[0] = new ReportParameter("prmMatricula", Convert.ToString(matricula));
            parametros[1] = new ReportParameter("prmNombre", apelnombres);
            parametros[2] = new ReportParameter("prmDomicilio", domicilio);
            parametros[3] = new ReportParameter("prmLocalidad", localidad);
            parametros[4] = new ReportParameter("prmComprobante", comprobante);
            parametros[5] = new ReportParameter("prmTesorero", txtTesorero.Text);

            reportReclamo1.LocalReport.SetParameters(parametros);

            byte[] bytes = reportReclamo1.LocalReport.Render("PDF");

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
                sb.Append("Matrícula: " + matricula + " - " + apelnombres);
                sb.Append("Email: " + maildestino);
                mensaje = sb.ToString();
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                respuesta = dialogo.ToString();
            }
        }

        //***** PROCESO PARA CAMBIAR EL ESTADO DEL COLEGIADO *****
        private void CambiarEstado(int matricula, string estado)
        {
            bool cambio = cN_Colegiados.ActualizarEstado(matricula, estado);
        }

        //***** PROCESO PARA CAMBIAR LA FECHA DEL VTO DEL CAE *****
        private void FechaVtoCae()
        {
            yycae = new PonerCeros().Proceso(vtocae.Substring(0, 4), 4);
            mmcae = new PonerCeros().Proceso(vtocae.Substring(4, 2), 2);
            ddcae = new PonerCeros().Proceso(vtocae.Substring(6, 2), 2);
            vtocae = ddcae + "/" + mmcae + "/" + yycae;
        }

        //***** PROCESO PARA ENVIAR EL SEGUNDO RECLAMO *****
        private void EnviarReclamo2()
        {
            string matri = new PonerCeros().Proceso(Convert.ToString(matricula), 5);
            nombrePDF = matri + "-" + lblPeriodo.Text.Trim() + ".pdf";

            reportReclamo2.RefreshReport();

            ReportParameter[] parametros = new ReportParameter[6];
            parametros[0] = new ReportParameter("prmMatricula", Convert.ToString(matricula));
            parametros[1] = new ReportParameter("prmNombre", apelnombres);
            parametros[2] = new ReportParameter("prmDomicilio", domicilio);
            parametros[3] = new ReportParameter("prmLocalidad", localidad);
            parametros[4] = new ReportParameter("prmComprobante", comprobante);
            parametros[5] = new ReportParameter("prmTesorero", txtTesorero.Text);

            reportReclamo2.LocalReport.SetParameters(parametros);

            byte[] bytes = reportReclamo2.LocalReport.Render("PDF");

            buscar = "PathReclamo2";
            linea = new LeerConfig().Proceso(buscar);
            path = linea + nombrePDF;

            var newFile = new FileStream(path, FileMode.Create);

            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();

            buscar = "MailOrigen";
            mailorigen = new LeerConfig().Proceso(buscar);

            buscar = "PasswordMail";
            password = new LeerConfig().Proceso(buscar);

            maildestino = "carlos.a.mayans@gmail.com";    //*** mail para pruebas

            bool enviado = new EnviarCorreo().EnviarMail(mailorigen, password, maildestino, txtAsunto.Text, txtMensaje.Text, path);

            if (enviado == false)
            {
                string mensaje = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append("NO SE ENVIÓ EL MAIL DEL SEGUNDO RECLAMO...!!! VERIFIQUE DATOS...!!!");
                sb.Append("Matrícula: " + matricula + " - " + apelnombres);
                sb.Append("Email: " + maildestino);
                mensaje = sb.ToString();
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                respuesta = dialogo.ToString();
            }
            else
            {
                lblProcesando.Text = lblProcesando.Text + " ENVIADO";
            }
        }
    }
}
