using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Localidades:Conexion
    {
        //***** METODO PARA LISTAR LAS LOCALIDADES *****
        public List<CE_Localidades> ListaCodPos()
        {
            List<CE_Localidades> lista = new List<CE_Localidades>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SP_ListaLocalidades";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Localidades()
                                {
                                    id_Local = Convert.ToInt32(dr["id_Local"]),
                                    fk_Deptos = Convert.ToInt32(dr["fk_Deptos"]),
                                    fk_Prov = Convert.ToInt32(dr["fk_Prov"]),
                                    CodigoPostal = Convert.ToInt32(dr["CodigoPostal"]),
                                    Localidad = dr["Localidad"].ToString(),
                                    Departamento = dr["Departamento"].ToString(),
                                    Provincia = dr["Provincia"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Localidades>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA LOCALIDAD *****
        public int Registrar(CE_Localidades obj, out string Mensaje)
        {
            int idBoton = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarLocalidad", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("fk_Deptos", obj.fk_Deptos);
                        command.Parameters.AddWithValue("fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idBoton = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idBoton = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idBoton;
        }

        //***** METODO PARA EDITAR UNA LOCALIDAD *****
        public bool Editar(CE_Localidades obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarLocalidad", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Local", obj.id_Local);
                        command.Parameters.AddWithValue("fk_Deptos", obj.fk_Deptos);
                        command.Parameters.AddWithValue("fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("UserRegistro", CE_UserLogin.UserRegistro);
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
