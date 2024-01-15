using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_CobroBoletas:Conexion
    {
        //***** METODO PARA REGISTRAR EL COBRO DE LAS BOLETAS *****
        public int Registrar(CE_CobroBoletas obj, out string Mensaje)
        {
            int idCobro = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarCobroBoletas", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Comprobante", obj.Comprobante);
                        command.Parameters.AddWithValue("Item", obj.Item);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("Importe", obj.Importe);
                        command.Parameters.AddWithValue("Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("FechaPago", obj.FechaPago);
                        command.Parameters.AddWithValue("Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("PagoActual", obj.PagoActual);
                        command.Parameters.AddWithValue("SaldoActual", obj.SaldoActual);
                        command.Parameters.AddWithValue("UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCobro = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idCobro = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idCobro;
        }
    }
}
