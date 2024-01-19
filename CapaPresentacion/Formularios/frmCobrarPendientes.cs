using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmCobrarPendientes : Form
    {
        CN_CtasCtesColeg cN_CtasCtesColeg = new CN_CtasCtesColeg();

        decimal saldodeudor, apagar, diferencia, efectivo, transferencia, tarjeta;
        decimal saldo, saldoant, pagado, saldoactual, pagoactual;
        string nombrePDF, tipo, comprobante, buscar, linea, path, estado, detalle, letras, periodo;
        int nrocpbte, idColeg, idctacte, matricula, orden;

        public frmCobrarPendientes()
        {
            InitializeComponent();
        }

        private void frmCobrarPendientes_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Limpiar();

            txtMatricula.Select();
        }

        //***** PROCEDIMIENTO CUENDO SE PRESIONA F1 EN EL CAMPO MATRICULA *****
        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) ConsultaMat();
            if (e.KeyCode == Keys.F2) ConsultaSoc();
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA ENTER *****
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Limpiar();
                LeerColegiado();
                CargarDGV();
            }
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE COLEGIADOS *****
        private void ConsultaMat()
        {
            Limpiar();
            mdlColegiado CobrarPendientes = new mdlColegiado("btnCobrarPendientes");
            AddOwnedForm(CobrarPendientes);
            CobrarPendientes.ShowDialog();

            CargarDGV();
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE SOCIEDADES *****
        private void ConsultaSoc()
        {
            Limpiar();
            mdlColegiado CobrarPendientes = new mdlColegiado("btnCobrarPendientes");
            AddOwnedForm(CobrarPendientes);
            CobrarPendientes.ShowDialog();

            CargarDGV();
        }

        //***** PROCEDIMIENTO PARA CARGAR LOS MOVIMIENTOS PENDIENTES DE LAS CTASCTES *****
        private void CargarDGV()
        {
            int matri = Convert.ToInt32(txtMatricula.Text);

            List<CE_CtasCtesColeg> ListaCtaCte = new CN_CtasCtesColeg().ListaDeuda(matri);

            if (ListaCtaCte.Count > 0)
            {
                foreach (CE_CtasCtesColeg item in ListaCtaCte)
                {
                    dgvCtasCtes.Rows.Add(new object[] { item.id_CtaCte, item.fk_idColeg, item.Matricula, item.Fecha, item.Tipo, item.Prefijo, item.Subfijo, item.Item, item.fk_idDebito,
                                                item.Detalle, item.Periodo, item.Debe, item.Pagado, item.FechaPago, item.Saldo, item.Estado, item.Obs,
                                                item.UserRegistro, item.FechaRegistro, "" });

                    saldodeudor = saldodeudor + Convert.ToDecimal(item.Saldo);
                    matricula = Convert.ToInt32(item.Matricula);
                }
                PintarDGV();
            }
            else
            {
                string mensaje = string.Empty;

                mensaje += "NO REGISTRA DEUDAS PENDIENTES...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
            }
            txtSaldoDeudor.Text = Convert.ToString(saldodeudor);
        }

        //***** PROCEDIMIENTO PARA PINTAR EL DGV DE LAS CUENTAS CORRIENTES *****
        private void PintarDGV()
        {
            if (dgvCtasCtes.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvCtasCtes.Rows)
                {
                    if (fila.Cells["C_FechaPago"].Value.ToString() == "1/1/1900 00:00:00")
                    {
                        fila.Cells["C_FechaPago"].Value = "";
                    }
                }

                dgvCtasCtes.FirstDisplayedScrollingRowIndex = dgvCtasCtes.RowCount - 1;
                dgvCtasCtes.CurrentCell = dgvCtasCtes.Rows[dgvCtasCtes.RowCount - 1].Cells[3];
                txtMatricula.Select();
            }
        }

        //***** PROCEDIMIENTO PARA LIMPIAR LOS DATOS *****
        private void Limpiar()
        {
            lblNombre.Text = "-";
            txtEfectivo.Text = "0.00";
            txtTransferencia.Text = "0.00";
            txtTarjeta.Text = "0.00";
            txtSaldoDeudor.Text = "0.00";
            txtApagar.Text = "0.00";
            txtDiferencia.Text = "0.00";
            txtImporteNCR.Text = "";
            detalle = "";
            saldodeudor = 0;
            apagar = 0;
            diferencia = 0;
            efectivo = 0;
            transferencia = 0;
            tarjeta = 0;
            dgvCtasCtes.Rows.Clear();
            btnImprimir.Visible = false;
            txtMatricula.Select();
        }

        //***** PROCEDIMIENTO PARA LEER EL COLEGIADO INGRESADO *****
        private void LeerColegiado()
        {
            string mensaje = string.Empty;
            List<CE_Colegiados> ListaBuscado = new CN_Colegiados().ListaBuscado(txtMatricula.Text, out mensaje);

            foreach (CE_Colegiados item in ListaBuscado)
            {
                txtId.Text = Convert.ToString(item.id_Coleg);
                idColeg = Convert.ToInt32(item.id_Coleg);
                txtMatricula.Text = Convert.ToString(item.Matricula);
                lblNombre.Text = item.ApelNombres.ToString().Trim();
            }
        }

        //***** PROCEDIMIENTO PARA EL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO PARA EL BOTON LIMPIAR *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = string.Empty;
            Limpiar();
        }

        //***** PROCEDIMIENTO PARA EL BOTÓN IMPRIMIR *****
        private void txtObs_Leave(object sender, EventArgs e)
        {
            btnImprimir.Visible = true;
            btnImprimir.Select();
        }

        //***** PROCEDIMIENTO PARA MARCAR QUE RENGLÓN QUIERO COBRAR *****
        private void dgvCtasCtes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCtasCtes.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (Convert.ToString(dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Value) == "")
                {
                    if (indice >= 0)
                    {
                        dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Value = "X";
                        dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Style.ForeColor = Color.Red;
                        dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Style.BackColor = Color.Yellow;
                        apagar = apagar + Convert.ToDecimal(dgvCtasCtes.Rows[indice].Cells["C_Saldo"].Value);
                        txtApagar.Text = Convert.ToString(apagar);
                        ProcesarImportes(apagar);
                        txtApagar.Refresh();
                    }
                }
                else
                {
                    if (indice >= 0)
                    {
                        dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Value = "";
                        dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Style.ForeColor = Color.White;
                        dgvCtasCtes.Rows[indice].Cells["Seleccionar"].Style.BackColor = Color.Black;
                        apagar = apagar - Convert.ToDecimal(dgvCtasCtes.Rows[indice].Cells["C_Saldo"].Value);
                        txtApagar.Text = Convert.ToString(apagar);
                        ProcesarImportes(apagar);
                        txtApagar.Refresh();
                    }
                }
            }
        }

        //***** PROCEDIMIENTO CUANDO INGRESO LOS IMPORTES DE PAGO *****
        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            txtEfectivo.Text = new FormatoMoneda().Proceso(txtEfectivo.Text);
            efectivo = Convert.ToDecimal(txtEfectivo.Text);
            ProcesarImportes(efectivo);
        }

        private void txtTransferencia_Leave(object sender, EventArgs e)
        {
            txtTransferencia.Text = new FormatoMoneda().Proceso(txtTransferencia.Text);
            transferencia = Convert.ToDecimal(txtTransferencia.Text);
            ProcesarImportes(transferencia);
        }

        private void txtTarjeta_Leave(object sender, EventArgs e)
        {
            txtTarjeta.Text = new FormatoMoneda().Proceso(txtTarjeta.Text);
            tarjeta = Convert.ToDecimal(txtTarjeta.Text);
            ProcesarImportes(tarjeta);
        }

        private void ProcesarImportes(decimal importe)
        {
            diferencia = apagar - efectivo - transferencia - tarjeta;
            txtDiferencia.Text = Convert.ToString(diferencia);

            if (diferencia < 0)
            {
                string mensaje = string.Empty;

                mensaje += "ESTÁ SEGURO DE LOS IMPORTES INGRESADOS...??? CONTROLE SI PUEDE CARGAR MÁS COMPROBANTES...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
            }
        }

        //***** PROCEDIMIENTO PARA IMPRIMIR EL RECIBO DE COBRO *****
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            tipo = "CIC";
            orden = 0;

            BuscoComprobante();
            GraboMovimientos();
            GraboPagoCtaCte();
            GraboCpbte();
            ExportarPDF();
        }

        //***** BUSCO EL NÚMERO DE COMPROBANTE DE LA LIQUIDACIÓN *****
        private void BuscoComprobante()
        {
            nrocpbte = new CN_Comprobantes().BuscoCpbte(tipo);
            comprobante = Convert.ToString(nrocpbte + 1);
            comprobante = new PonerCeros().Proceso(comprobante, 8);
        }

        //***** PROCESO PARA GRABAR LA DEUDA Y LAS CUENTAS CORRIENTES CON LOS IMPORTES PAGADOS *****
        private void GraboMovimientos()
        {
            string mensaje = string.Empty;

            pagado = efectivo + transferencia + tarjeta;

            foreach (DataGridViewRow row in dgvCtasCtes.Rows)
            {
                if (Convert.ToString(row.Cells["Seleccionar"].Value) == "X")
                {
                    saldoant = Convert.ToDecimal(row.Cells["C_Saldo"].Value.ToString());
                    idctacte = Convert.ToInt32(row.Cells["C_id_CtaCte"].Value.ToString());
                    detalle = row.Cells["C_Detalle"].Value.ToString();
                    periodo = row.Cells["C_Periodo"].Value.ToString();
                    orden = orden + 1;

                    if (row.Cells["C_FechaPago"].Value.ToString() == "")
                    {
                        row.Cells["C_FechaPago"].Value = "1/1/1900 00:00:00";
                    }

                    CalculoImporte();

                    CE_CobroBoletas cE_CobroBoleta = new CE_CobroBoletas()
                    {
                        Matricula = Convert.ToInt32(txtMatricula.Text),
                        Prefijo = row.Cells["C_Prefijo"].Value.ToString(),
                        Subfijo = row.Cells["C_Subfijo"].Value.ToString(),
                        Fecha = Convert.ToDateTime(row.Cells["C_Fecha"].Value.ToString()),
                        Tipo = row.Cells["C_Tipo"].Value.ToString(),
                        Comprobante = comprobante,
                        Item = orden,
                        Detalle = row.Cells["C_Detalle"].Value.ToString(),
                        Periodo = periodo,
                        Importe = Convert.ToDecimal(row.Cells["C_Debe"].Value.ToString()),
                        Pagado = Convert.ToDecimal(row.Cells["C_Pagado"].Value.ToString()),
                        FechaPago = Convert.ToDateTime(row.Cells["C_FechaPago"].Value.ToString()),
                        Saldo = Convert.ToDecimal(row.Cells["C_Saldo"].Value.ToString()),
                        PagoActual = pagoactual,
                        SaldoActual = saldoactual,
                        UserRegistro = CE_UserLogin.Usuario,
                        FechaRegistro = DateTime.Today
                    };

                    int idCobro = new CN_CobroBoletas().Registrar(cE_CobroBoleta, out mensaje);

                    if (saldo >= 0) estado = "PAGADA";
                    if (saldo < 0) estado = "PENDIENTE";

                    
                    CE_CtasCtesColeg cE_CtasCtesColeg = new CE_CtasCtesColeg()
                    {
                        Pagado = pagoactual + Convert.ToDecimal(row.Cells["C_Pagado"].Value.ToString()),
                        FechaPago = DateTime.Today,
                        Saldo = saldoactual,
                        Estado = estado,
                        Obs = row.Cells["C_Obs"].Value.ToString() + "CIC Nro.: " + comprobante + " * ",
                        UserRegistro = CE_UserLogin.Usuario,
                        FechaRegistro = DateTime.Today
                    };

                    bool resultado = new CN_CtasCtesColeg().Actualizar(cE_CtasCtesColeg, idctacte, matricula, out mensaje);

                    GraboCaja();
                }
            }
        }

        //***** PROCESO PARA GRABAR LOS PAGOS A CADA COMRPOBANTE MARCADO *****
        private void CalculoImporte()
        {
            saldo = pagado - saldoant;

            if (saldo > 0)
            {
                saldoactual = 0;
                pagoactual = saldoant;
            }
            if (saldo == 0)
            {
                saldoactual = 0;
                pagoactual = saldoant;
            }
            if (saldo < 0)
            {
                saldoactual = saldo * -1;
                pagoactual = pagado;
            }
            pagado = saldo;
        }

        //***** PROCESO PARA GRABAR LA CUENTA CORRIENTE DE LOS MATRICULADOS *****
        private void GraboPagoCtaCte()
        {
            string mensaje = string.Empty;

            pagado = efectivo + transferencia + tarjeta;

            CE_CtasCtesColeg cE_CtasCtesColeg = new CE_CtasCtesColeg()
            {
                fk_idColeg = idColeg,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                Fecha = DateTime.Today,
                Tipo = tipo,
                Prefijo = "0000",
                Subfijo = comprobante,
                Item = 1,
                fk_idDebito = 116,
                Detalle = "CIC Nro.: " + comprobante,
                Periodo = "",
                Debe = 0,
                Pagado = pagado,
                FechaPago = DateTime.Today,
                Saldo = 0,
                Estado = "PAGO",
                Obs = "",
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idCtaCte = new CN_CtasCtesColeg().Registrar(cE_CtasCtesColeg, out mensaje);
        }

        //***** PROCESO PARA GRABAR EN LA CAJA DEL DÍA ACTUAL *****
        private void GraboCaja()
        {
            string mensaje = string.Empty;

            CE_Cajas cE_Cajas = new CE_Cajas()
            {
                id_Caja = 0,
                Fecha = DateTime.Today,
                Tipo = tipo,
                Prefijo = "0000",
                Subfijo = comprobante,
                Item = orden,
                Numero = matricula,
                Nombre = lblNombre.Text,
                Detalle = detalle,
                Periodo = periodo,
                Efectivo = Convert.ToDecimal(txtEfectivo.Text),
                Transferencia = Convert.ToDecimal(txtTransferencia.Text),
                Tarjeta = Convert.ToDecimal(txtTarjeta.Text),
                Estado = "ABIERTA",
                FechaCierre = Convert.ToDateTime("1/1/1900 00:00:00"),
                Obs = txtObs.Text,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idCaja = new CN_Cajas().Registrar(cE_Cajas, out mensaje);
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
            letras = pagado.NumeroALetras();

            int matri = Convert.ToInt32(txtMatricula.Text);
            nombrePDF = "CIC-" + comprobante + "-" + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";

            //spCobroBoletasTableAdapter.Fill(dataSetPrincipal.spCobroBoletas, matri, comprobante);

            reportCobroBoletas.RefreshReport();

            reportCobroBoletas.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", spCobroBoletasBindingSource));

            ReportParameter[] parametros = new ReportParameter[8];
            parametros[0] = new ReportParameter("prmTipo", "MATRÍCULA:");
            parametros[1] = new ReportParameter("prmNumero", Convert.ToString(matricula));
            parametros[2] = new ReportParameter("prmNombre", lblNombre.Text);
            parametros[3] = new ReportParameter("prmComprobante", comprobante);
            parametros[4] = new ReportParameter("prmFecha", lblFecha.Text);
            parametros[5] = new ReportParameter("prmLetras", letras);
            parametros[6] = new ReportParameter("prmCuit", "CUIT");
            parametros[7] = new ReportParameter("prmObs", txtObs.Text);

            reportCobroBoletas.LocalReport.SetParameters(parametros);

            reportCobroBoletas.RefreshReport();

            byte[] bytes = reportCobroBoletas.LocalReport.Render("PDF");
            //var bytes = reportCobroBoleta.LocalReport.Render("PDF");

            buscar = "PathCIC";
            linea = new LeerConfig().Proceso(buscar);
            path = linea + nombrePDF;

            var newFile = new FileStream(path, FileMode.Create);

            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();

            string FileName = path;
            PrintDocument pdoc = new PrintDocument();
            pdoc.DocumentName = FileName;
            pdoc.Print();
        }



    }
}
