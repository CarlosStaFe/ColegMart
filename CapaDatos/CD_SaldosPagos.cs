using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_SaldosPagos:Conexion
    {
        //***** METODO PARA REGISTRAR LOS SALDOS O PAGOS *****
        public int Registrar(CE_SaldosPagos obj, out string Mensaje)
        {
            int idSP = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarSaldosPagos", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("_Debe", obj.Debe);
                        command.Parameters.AddWithValue("_Haber", obj.Haber);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idSP = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idSP = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idSP;
        }

        //***** METODO PARA BLANQUEAR LA TABLA *****
        public int Blanquear()
        {
            int idSP = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM SaldosPagos";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        idSP = 0;
                    }
                }
            }
            return idSP;
        }
    }
}
