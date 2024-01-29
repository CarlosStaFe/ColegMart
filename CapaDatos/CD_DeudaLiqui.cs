using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_DeudaLiqui:Conexion
    {
        //***** METODO PARA REGISTRAR UNA LOCALIDAD *****
        public int Registrar(CE_DeudaLiqui obj, out string Mensaje)
        {
            int idDeuda = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarDeuda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("_Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Comprobante", obj.Comprobante);
                        command.Parameters.AddWithValue("_Item", obj.Item);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("_Importe", obj.Importe);
                        command.Parameters.AddWithValue("_Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("_FechaPago", obj.FechaPago);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idDeuda = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idDeuda = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idDeuda;
        }
    }
}
