using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Bancos:Conexion
    {
        //***** METODO PARA BUSCAR LOS BANCOS PARA HABILITARLOS *****
        public List<CE_Bancos> BuscaBancos(int idBanco)
        {
            List<CE_Bancos> lista = new List<CE_Bancos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@idBanco", idBanco);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Bancos WHERE id_Bco = @idBanco";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Bancos()
                                {
                                    Nombre = dr["Nombre"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Bancos>();
                    }
                    return lista;
                }
            }
        }

        //***** METODO PARA LISTAR LOS BANCOS BUSCADOS *****
        public List<CE_Bancos> ListaBancos()
        {
            List<CE_Bancos> lista = new List<CE_Bancos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Bancos ORDER BY Nombre";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Bancos()
                                {
                                    id_Bco = Convert.ToInt32(dr["id_Bco"]),
                                    Cuit = dr["Cuit"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    UserRegistro = dr["UserRegistro"].ToString()//,
                                                                                //FechaRegistro = dr["FechaRegistro"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Bancos>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN BANCO *****
        public int Registrar(CE_Bancos obj, out string Mensaje)
        {
            int idBanco = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarBanco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Activo", obj.Activo);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idBanco = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idBanco = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idBanco;
        }

        //***** METODO PARA EDITAR UN BANCO *****
        public bool Editar(CE_Bancos obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarBanco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Bco", obj.id_Bco);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Activo", obj.Activo);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
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
