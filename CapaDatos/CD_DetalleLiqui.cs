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
                        command.Parameters.AddWithValue("_Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("_Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("_Item", obj.Item);
                        command.Parameters.AddWithValue("_Codigo", obj.Codigo);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Importe", obj.Importe);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idDetLiq = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
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
