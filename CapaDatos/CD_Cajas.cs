using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Cajas : Conexion
    {
        //***** METODO PARA REGISTRAR UNA VENTA *****
        public int Registrar(CE_Cajas obj, out string Mensaje)
        {
            int idCaja = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarCaja", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("Item", obj.Item);
                        command.Parameters.AddWithValue("Numero", obj.Numero);
                        command.Parameters.AddWithValue("Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("Efectivo", obj.Efectivo);
                        command.Parameters.AddWithValue("Transferencia", obj.Transferencia);
                        command.Parameters.AddWithValue("Tarjeta", obj.Tarjeta);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FechaCierre", obj.FechaCierre);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCaja = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idCaja = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idCaja;
        }
    }
}
