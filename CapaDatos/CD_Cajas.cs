using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("_Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("_Item", obj.Item);
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("_Efectivo", obj.Efectivo);
                        command.Parameters.AddWithValue("_Transferencia", obj.Transferencia);
                        command.Parameters.AddWithValue("_Tarjeta", obj.Tarjeta);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaCierre", obj.FechaCierre);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCaja = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
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

        //***** METODO PARA LISTAR LAS CAJAS *****
        public List<CE_Cajas> ListaCaja()
        {
            List<CE_Cajas> lista = new List<CE_Cajas>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Cajas WHERE Estado = 'ABIERTA' ORDER BY id_Caja";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Cajas()
                                {
                                    id_Caja = Convert.ToInt32(dr["id_Caja"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Prefijo = dr["Prefijo"].ToString(),
                                    Subfijo = dr["Subfijo"].ToString(),
                                    Item = Convert.ToInt32(dr["Item"]),
                                    Numero = Convert.ToInt32(dr["Numero"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Detalle = dr["Detalle"].ToString(),
                                    Periodo = dr["Periodo"].ToString(),
                                    Efectivo = Convert.ToDecimal(dr["Efectivo"]),
                                    Transferencia = Convert.ToDecimal(dr["Transferencia"]),
                                    Tarjeta = Convert.ToDecimal(dr["Tarjeta"]),
                                    Estado = dr["Estado"].ToString(),
                                    FechaCierre = Convert.ToDateTime(dr["FechaCierre"]),
                                    Obs = dr["Obs"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<CE_Cajas>();
                    }
                }
            }
            return lista;
        }

    }
}
