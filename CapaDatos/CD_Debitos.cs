using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
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
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Debitos ORDER BY Codigo";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    Desde = Convert.ToDateTime(dr["Desde"].ToString()),
                                    Hasta = Convert.ToDateTime(dr["Hasta"].ToString()),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<CE_Debitos>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA LISTAR LOS DÉBITOS SOLO PARA BOLETAS *****
        public List<CE_Debitos> ListaDebitoBol()
        {
            List<CE_Debitos> lista = new List<CE_Debitos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Debitos WHERE TipoDebito = 'BOL' AND Activo = 1 ORDER BY Detalle";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    Desde = Convert.ToDateTime(dr["Desde"].ToString()),
                                    Hasta = Convert.ToDateTime(dr["Hasta"].ToString()),
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

        //***** METODO PARA LISTAR LOS DÉBITOS SOLO PARA RECIBOS *****
        public List<CE_Debitos> ListaDebitoRec()
        {
            List<CE_Debitos> lista = new List<CE_Debitos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Debitos WHERE TipoDebito = 'REC' AND Activo = 1 ORDER BY Detalle";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    Desde = Convert.ToDateTime(dr["Desde"].ToString()),
                                    Hasta = Convert.ToDateTime(dr["Hasta"].ToString()),
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
                using (var command = new MySqlCommand("spRegistrarDebito", connection))
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
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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
                using (var command = new MySqlCommand("spEditarDebito", connection))
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
                        command.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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

        //***** BUSQUEDA DE UN CÓDIGO A DEBITAR PARA LIQUIDAR *****
        public List<CE_Debitos> BuscoDebito(string debitoAB, string debitoI)
        {
            List<CE_Debitos> lista = new List<CE_Debitos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@debitoAB", debitoAB);
                        command.Parameters.AddWithValue("@debitoI", debitoI);
                        command.CommandText = "SELECT * FROM Debitos WHERE Codigo = @debitoAB OR Codigo = @debitoI";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    Desde = Convert.ToDateTime(dr["Desde"].ToString()),
                                    Hasta = Convert.ToDateTime(dr["Hasta"].ToString()),
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
    }
}
