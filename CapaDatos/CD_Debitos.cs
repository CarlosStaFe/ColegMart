using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Debitos:Conexion
    {
        //***** METODO PARA LISTAR LOS DÉBITOS *****
        public List<CE_Debitos> ListaDebito()
        {
            List<CE_Debitos> lista = new List<CE_Debitos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Debitos ORDER BY Codigo";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Debitos()
                                {
                                    id_Debito = Convert.ToInt32(dr["id_Debito"]),
                                    Codigo = Convert.ToInt32(dr["Codigo"]),
                                    Detalle = dr["Detalle"].ToString(),
                                    Importe = Convert.ToDecimal(dr["Importe"]),
                                    Kilos = Convert.ToInt32(dr["Kilos"]),
                                    Categoria = dr["Categoria"].ToString(),
                                    TipoDebito = dr["TipoDebito"].ToString(),
                                    Desde = dr.IsDBNull(dr.GetOrdinal("Desde")) ? (DateTime?) null : dr.GetDateTime(dr.GetOrdinal("Desde")),
                                    Hasta = dr.IsDBNull(dr.GetOrdinal("Hasta")) ? (DateTime?) null : dr.GetDateTime(dr.GetOrdinal("Hasta")),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Debitos>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN DÉBITO *****
        public int Registrar(CE_Debitos obj, out string Mensaje)
        {
            int idDebito = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarDebito", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Codigo", obj.Codigo);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Importe", obj.Importe);
                        command.Parameters.AddWithValue("Kilos", obj.Kilos);
                        command.Parameters.AddWithValue("Categoria", obj.Categoria);
                        command.Parameters.AddWithValue("TipoDebito", obj.TipoDebito);
                        command.Parameters.AddWithValue("Desde", obj.Desde);
                        command.Parameters.AddWithValue("Hasta", obj.Hasta);
                        command.Parameters.AddWithValue("Activo", obj.Activo);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idDebito = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idDebito = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idDebito;
        }

        //***** METODO PARA EDITAR UN DÉBITO *****
        public bool Editar(CE_Debitos obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarDebito", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Debito", obj.id_Debito);
                        command.Parameters.AddWithValue("Codigo", obj.Codigo);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Importe", obj.Importe);
                        command.Parameters.AddWithValue("Kilos", obj.Kilos);
                        command.Parameters.AddWithValue("Categoria", obj.Categoria);
                        command.Parameters.AddWithValue("TipoDebito", obj.TipoDebito);
                        command.Parameters.AddWithValue("Desde", obj.Desde);
                        command.Parameters.AddWithValue("Hasta", obj.Hasta);
                        command.Parameters.AddWithValue("Activo", obj.Activo);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
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
