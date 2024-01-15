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
                        command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("Total", obj.Total);
                        command.Parameters.AddWithValue("CodigoBarra", obj.CodigoBarra);
                        command.Parameters.AddWithValue("NumeroPago", obj.NumeroPago);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idLiqui = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
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
