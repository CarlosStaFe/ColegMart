using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_DetalleLiqui:Conexion
    {
        //***** METODO PARA REGISTRAR EL DETALLE DE LA LIQUIDACION *****
        public int Registrar(CE_DetalleLiqui obj, out string Mensaje)
        {
            int idDetLiq = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarDetLiqui", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("Item", obj.Item);
                        command.Parameters.AddWithValue("Codigo", obj.Codigo);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Importe", obj.Importe);
                        command.Parameters.AddWithValue("UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idDetLiq = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idDetLiq = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idDetLiq;
        }
    }
}
