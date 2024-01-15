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
                        command.Parameters.AddWithValue("Numero", obj.Numero);
                        command.Parameters.AddWithValue("Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("Debe", obj.Debe);
                        command.Parameters.AddWithValue("Haber", obj.Haber);
                        command.Parameters.AddWithValue("Saldo", obj.Saldo);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idSP = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
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
                        command.CommandText = "DELETE SaldosPagos";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        idSP = Convert.ToInt32(command.Parameters["idResultado"].Value);
                    }
                    catch (Exception)
                    {
                        idSP = 0;
                    }
                }
            }
            return idSP;
        }
    }
}
