using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmCobrarVarios : Form
    {
        CN_CtasCtesColeg cN_CtasCtesColeg = new CN_CtasCtesColeg();

        decimal efectivo, transferencia, tarjeta;
        decimal saldo, saldoant, pagado, saldoactual, pagoactual, importe, subtotal, total;
        string nombrePDF, tipo, comprobante, buscar, linea, path, estado, detalle;
        int nrocpbte, idColeg, idctacte, matricula, cantidad, renglon, item;
        DateTime fecha, desde, hasta;
        string cae, vtocae, ddcae, mmcae, yycae;

        public frmCobrarVarios()
        {
            InitializeComponent();
        }

        private void frmCobrarVarios_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fecha = DateTime.Now;
            Limpiar();

            txtMatricula.Select();
        }

        //***** PROCEDIMIENTO CUENDO SE PRESIONA F1 EN EL CAMPO MATRICULA *****
        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Consulta();
        }

        //***** PROCEDIMIENTO CUANDO PRESIONA ENTER *****
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Limpiar();
                LeerColegiado();
                txtCodigo.Select();
            }
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE COLEGIADOS *****
        private void Consulta()
        {
            Limpiar();
            mdlColegiado CobrarVarios = new mdlColegiado("btnCobrarVarios");
            AddOwnedForm(CobrarVarios);
            CobrarVarios.ShowDialog();
        }

        //***** PROCEDIMIENTO PARA LIMPIAR LOS DATOS *****
        private void Limpiar()
        {
            int idRenglon = new CN_Renglones().Blanquear();

            lblNombre.Text = "-";
            txtEfectivo.Text = "0.00";
            txtTransferencia.Text = "0.00";
            txtTarjeta.Text = "0.00";
            lblAntiguedad.Text = "";
            lblVenceFianza.Text = "";
            txtSaldoMat.Text = "";
            LimpiarIngreso();
            txtSaldo.Text = "0.00";
            txtTotal.Text = "0.00";
            txtObs.Text = "";
            efectivo = 0;
            transferencia = 0;
            tarjeta = 0;
            total = 0;
            dgvCobros.Rows.Clear();
            btnImprimir.Visible = false;
            renglon = 0;
            txtMatricula.Select();
        }

        //***** PROCEDIMIENTO PARA LIMPIAR INGRESOS *****
        private void LimpiarIngreso()
        {
            txtCodigo.Text = "";
            lblDetalle.Text = "";
            txtImporte.Text = "";
            txtCantidad.Text = "";
            txtSubtotal.Text = "";
            btnCargar.Visible = false;
            txtCodigo.Select();
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
                int anios = CalcularAnios.TraerAnios(Convert.ToDateTime(item.Juramento.ToString()));
                lblAntiguedad.Text = anios.ToString() + " años";
                lblVenceFianza.Text = new ProcesarFecha().Proceso(item.FecVenceFianza.ToString());
                saldoant = CalcularSaldo(idColeg);
                txtSaldoMat.Text = saldoant.ToString("$##,###,##0.00");
            }
        }

        //***** CALCULO EL SALDO DEL COLEGIADO EN LA CUENTA CORRIENTE *****
        decimal CalcularSaldo(int idColeg)
        {
            var saldo = cN_CtasCtesColeg.CalcularSaldo(idColeg);

            return saldo;
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
            btnImprimir.Enabled = true;
            btnImprimir.Select();
        }

        //***** PROCEDIMIENTO CUANDO SE PRESIONA F1 *****
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) ConsultaDebitos();
        }

        //***** PROCEDIMIENTO CUANDO SE PRESIONA ENTER *****
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtCodigo.Text != "")
                {
                    LeerDebitos();
                    txtImporte.Select();
                }
                else
                {
                    txtEfectivo.Select();
                }
            }
        }

        //***** PROCEDIMIENTO PARA LLAMAR A LA CONSULTA DE DÉBITOS *****
        private void ConsultaDebitos()
        {
            mdlDebitos CobrarVarios = new mdlDebitos("btnCobrarVarios");
            AddOwnedForm(CobrarVarios);
            CobrarVarios.ShowDialog();
        }

        //***** PROCEDIMIENTO PARA LEER LOS CÓDIGOS DE DÉBITOS *****
        private void LeerDebitos()
        {
            string mensaje = string.Empty;
            List<CE_Debitos> ListaDebito = new CN_Debitos().BuscoDebito(txtCodigo.Text, txtCodigo.Text);

            foreach (CE_Debitos item in ListaDebito)
            {
                txtCodigo.Text = Convert.ToString(item.Codigo);
                lblDetalle.Text = item.Detalle.ToString().Trim();
                txtImporte.Text = new FormatoMoneda().Proceso(item.Importe.ToString());
                desde = Convert.ToDateTime(item.Desde);
                hasta = Convert.ToDateTime(item.Hasta);
                txtCantidad.Text = "1";
                txtSubtotal.Text = txtImporte.Text;
            }

            if (fecha < desde && fecha > hasta)
            {
                mensaje += "CONCEPTO FUERA DE FECHA PERMITIDA...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dialogo = msg.ShowDialog();
                LimpiarIngreso();
                txtCodigo.Select();
            }
        }

        //***** PROCEDIMIENTO PARA EL IMPORTE INGRESADO *****
        private void txtImporte_Leave(object sender, EventArgs e)
        {
            importe = Convert.ToDecimal(txtImporte.Text);
            txtImporte.Text = new FormatoMoneda().Proceso(txtImporte.Text);
        }

        //***** PROCEDIMIENTO PARA LA CANTIDAD INGRESADA *****
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            cantidad = Convert.ToInt32(txtCantidad.Text);
            subtotal = importe * cantidad;
            txtSubtotal.Text = new FormatoMoneda().Proceso(Convert.ToString(subtotal));
            btnCargar.Visible = true;
            btnCargar.Select();
        }

        //***** PROCEDIMIENTO CUANDO SE PRESIONA EL BOTÓN DE CARGAR EL CONCEPTO *****
        private void btnCargar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            CE_Renglones cERenglones = new CE_Renglones()
            {
                Codigo = Convert.ToInt32(txtCodigo.Text),
                Detalle = lblDetalle.Text,
                Importe = importe,
                Cantidad = cantidad,
                Subtotal = subtotal
            };

            int idRenglon = new CN_Renglones().Registrar(cERenglones, out mensaje);

            if (idRenglon != 0)
            {
                dgvCobros.Rows.Add(new object[] { "", txtCodigo.Text, lblDetalle.Text, txtImporte.Text, txtCantidad.Text, txtSubtotal.Text });
                total = total + subtotal;
                txtTotal.Text = total.ToString("$##,###,##0.00");
                txtSaldo.Text = total.ToString("$##,###,##0.00");
            }
            else
            {
                mensaje += ". VERIFIQUE...!!!";
                frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                msg1.ShowDialog();
            }
            txtCodigo.Select();
            LimpiarIngreso();
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
            saldoactual = total - efectivo - transferencia - tarjeta;
            txtSaldo.Text = Convert.ToString(saldoactual);

            if (saldoactual < 0)
            {
                string mensaje = string.Empty;

                mensaje += "NO SE PERMITE PAGOS SUPERIORES A LA DEUDA...!!! CONTROLE SI PUEDE CARGAR MÁS CÓDIGOS...!!!";
                frmMsgBox msg = new frmMsgBox(mensaje, "info", 1);
                DialogResult dr = msg.ShowDialog();
            }
            txtEfectivo.Select();
        }

        //***** PROCEDIMIENTO PARA IMPRIMIR EL RECIBO DE COBRO *****
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            tipo = "CIC";
            BuscoComprobante();
            GraboMovimientos();
            GraboPagoCtaCte();
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

            item = 0;
            pagado = efectivo + transferencia + tarjeta;

            foreach (DataGridViewRow row in dgvCobros.Rows)
            {
                subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString());
                detalle = row.Cells["Detalle"].Value.ToString();
                item = item + 1;

                CalculoImporte();

                if (saldo >= 0) estado = "PAGADA";
                if (saldo < 0) estado = "PENDIENTE";

                CE_CtasCtesColeg cE_CtasCtesColeg = new CE_CtasCtesColeg()
                {
                    id_CtaCte = 0,
                    Matricula = Convert.ToInt32(txtMatricula.Text),
                    Fecha = DateTime.Today,
                    Tipo = tipo,
                    Prefijo = "0000",
                    Subfijo = comprobante,
                    Item = item,
                    fk_idDebito = Convert.ToInt32(row.Cells["Codigo"].Value.ToString()),
                    Detalle = detalle,
                    Periodo = "",
                    Debe = Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString()),
                    Pagado = pagoactual,
                    FechaPago = DateTime.Today,
                    Saldo = saldoactual,
                    Estado = estado,
                    Obs = "",
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                bool resultado = new CN_CtasCtesColeg().Actualizar(cE_CtasCtesColeg, idctacte, matricula, out mensaje);

                CE_Renglones cERenglones = new CE_Renglones()
                {
                    Codigo = Convert.ToInt32(row.Cells["Codigo"].Value.ToString()),
                    Detalle = detalle,
                    Pagado = pagoactual,
                    Saldo = saldoactual
                };

                bool Resultado = new CN_Renglones().Actualizar(cERenglones, out mensaje);

                GraboCaja();
            }
        }

        //***** PROCESO PARA GRABAR LOS PAGOS A CADA COMRPOBANTE MARCADO *****
        private void CalculoImporte()
        {
            saldo = pagado - subtotal;

            if (saldo > 0)
            {
                saldoactual = 0;
                pagoactual = subtotal;
            }
            if (saldo == 0)
            {
                saldoactual = 0;
                pagoactual = subtotal;
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
                id_CtaCte = 0,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                Fecha = DateTime.Today,
                Tipo = tipo,
                Prefijo = "0000",
                Subfijo = comprobante,
                Item = 1,
                fk_idDebito = 901,
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
            idctacte = idCtaCte;
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
                Numero = matricula,
                Nombre = lblNombre.Text,
                Detalle = detalle,
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

        //***** PROCESO PARA GENERAR EL PDF DE LA LIQUIDACIÓN *****
        private void ExportarPDF()
        {
            int matri = Convert.ToInt32(txtMatricula.Text);
            nombrePDF = "CIC-" + comprobante + "-" + DateTime.Now.ToString() + ".pdf";

            //renglonesTableAdapter.Fill(dataSetPrincipal.Renglones);

            reportCobroVarios.RefreshReport();

            reportCobroVarios.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrincipal", renglonesBindingSource));

            ReportParameter[] parametros = new ReportParameter[8];
            parametros[0] = new ReportParameter("prmTipo", txtObs.Text);
            parametros[1] = new ReportParameter("prmNumero", txtObs.Text);
            parametros[2] = new ReportParameter("prmNombre", txtObs.Text);
            parametros[3] = new ReportParameter("prmComprobante", txtObs.Text);
            parametros[4] = new ReportParameter("prmFecha", txtObs.Text);
            parametros[5] = new ReportParameter("prmLetras", txtObs.Text);
            parametros[6] = new ReportParameter("prmCuit", txtObs.Text);
            parametros[7] = new ReportParameter("prmObs", txtObs.Text);

            reportCobroVarios.LocalReport.SetParameters(parametros);

            var bytes = reportCobroVarios.LocalReport.Render("PDF");

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
