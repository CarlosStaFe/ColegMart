using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Estratos : Conexion
    {
        //***** METODO PARA BUSCAR LOS ESTRATOS PARA HABILITARLOS *****
        public List<CE_Estratos> BuscaEstratos(int numero)
        {
            List<CE_Estratos> lista = new List<CE_Estratos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@numero", numero);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Estratos WHERE NroBanco = @numero";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Estratos()
                                {
                                    NroBanco = Convert.ToInt32(dr["NroBanco"].ToString())
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Estratos>();
                    }
                    return lista;
                }
            }
        }

        //***** METODO PARA LISTAR LOS ESTRATOS BUSCADOS *****
        public List<CE_Estratos> ListaEstrato()
        {
            List<CE_Estratos> lista = new List<CE_Estratos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Estratos ORDER BY Fecha";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Estratos()
                                {
                                    id_Estra = Convert.ToInt32(dr["id_Estra"]),
                                    NroBanco = Convert.ToInt32(dr["NroBanco"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Referencia = dr["Referencia"].ToString(),
                                    Causal = dr["Causal"].ToString(),
                                    Concepto = dr["Concepto"].ToString(),
                                    Debito = Convert.ToDecimal(dr["Debito"]),
                                    Credito = Convert.ToDecimal(dr["Credito"]),
                                    Saldo = Convert.ToDecimal(dr["Saldo"]),
                                    FechaConci = Convert.ToDateTime(dr["FechaConci"]),
                                    Titular = Convert.ToInt32(dr["Titular"]),
                                    NroCic = Convert.ToInt32(dr["NroCic"]),
                                    UserRegistro = dr["UserRegistro"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Estratos>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN ESTRATOS *****
        public int Registrar(CE_Estratos obj, out string Mensaje)
        {
            int idEstra = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarEstrato", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_NroBanco", obj.NroBanco);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Referencia", obj.Referencia);
                        command.Parameters.AddWithValue("_Causal", obj.Causal);
                        command.Parameters.AddWithValue("_Concepto", obj.Concepto);
                        command.Parameters.AddWithValue("_Debito", obj.Debito);
                        command.Parameters.AddWithValue("_Credito", obj.Credito);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("_FechaConci", obj.FechaConci);
                        command.Parameters.AddWithValue("_Titular", obj.Titular);
                        command.Parameters.AddWithValue("_NroCic", obj.NroCic);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idEstra = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idEstra = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idEstra;
        }

        //***** METODO PARA EDITAR UN ESTRATO *****
        public bool Editar(CE_Estratos obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarEstrato", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Estra", obj.id_Estra);
                        command.Parameters.AddWithValue("_NroBanco", obj.NroBanco);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Referencia", obj.Referencia);
                        command.Parameters.AddWithValue("_Causal", obj.Causal);
                        command.Parameters.AddWithValue("_Concepto", obj.Concepto);
                        command.Parameters.AddWithValue("_Debito", obj.Debito);
                        command.Parameters.AddWithValue("_Credito", obj.Credito);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("_FechaConci", obj.FechaConci);
                        command.Parameters.AddWithValue("_Titular", obj.Titular);
                        command.Parameters.AddWithValue("_NroCic", obj.NroCic);
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

        //***** METODO PARA ELIMINAR UN ESTRATO *****
        public bool Eliminar(CE_Estratos obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarEstrato", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Estra", obj.id_Estra);
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
