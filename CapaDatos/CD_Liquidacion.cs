using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Liquidacion:Conexion
    {
        //***** METODO PARA REGISTRAR LA LIQUIDACION *****
        public int Registrar(CE_Liquidacion obj, out string mensaje)
        {
            int idLiqui = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarLiquidacion", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("_Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("_Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("_Total", obj.Total);
                        command.Parameters.AddWithValue("_CodigoBarra", obj.CodigoBarra);
                        command.Parameters.AddWithValue("_NumeroPago", obj.NumeroPago);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idLiqui = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idLiqui = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idLiqui;
        }
    }
}
