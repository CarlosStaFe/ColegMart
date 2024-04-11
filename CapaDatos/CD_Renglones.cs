using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Renglones : Conexion
    {
        //***** METODO PARA REGISTRAR LOS RENGLONES DE COBRO *****
        public int Registrar(CE_Renglones obj, out string Mensaje)
        {
            int idRenglon = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarRenglon", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Codigo", obj.Codigo);
                        command.Parameters.AddWithValue("_Matricula", obj.Codigo);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Importe", obj.Importe);
                        command.Parameters.AddWithValue("_Cantidad", obj.Cantidad);
                        command.Parameters.AddWithValue("_Subtotal", obj.Subtotal);
                        command.Parameters.AddWithValue("_Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idRenglon = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idRenglon = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idRenglon;
        }

        //***** METODO PARA BLANQUEAR LA TABLA *****
        public int Blanquear()
        {
            int idRenglon = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE Renglones";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        idRenglon = Convert.ToInt32(command.Parameters["idResultado"].Value);
                    }
                    catch (Exception)
                    {
                        idRenglon = 0;
                    }
                }
            }
            return idRenglon;
        }

        //***** METODO PARA ACTUALIZAR LOS RENGLONES *****
        public bool Actualizar(CE_Renglones obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spReGrabarRenglon", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Codigo", obj.Codigo);
                        command.Parameters.AddWithValue("_Matricula", obj.Codigo);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        Mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }
    }
}
