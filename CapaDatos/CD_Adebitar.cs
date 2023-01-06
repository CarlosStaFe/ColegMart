using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Adebitar:Conexion
    {
        //***** METODO PARA LISTAR LOS DEBITOS A COLEGIADOS *****
        public List<CE_Adebitar> ListaAdebitar()
        {
            List<CE_Adebitar> lista = new List<CE_Adebitar>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT Adebitar.id_Debitar,Adebitar.fk_idColeg,Colegiados.Matricula,Colegiados.ApelNombres,Adebitar.fk_idDebito," +
                                              "Debitos.Codigo, Debitos.Detalle,Debitos.Importe,Adebitar.Activo,Adebitar.Obs,Adebitar.UserRegistro,Adebitar.FechaRegistro FROM Adebitar " +
                                              "INNER JOIN Colegiados ON id_Coleg  = Adebitar.fk_idColeg " +
                                              "INNER JOIN Debitos    ON id_Debito = Adebitar.fk_idDebito " +
                                              "ORDER BY Colegiados.ApelNombres";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Adebitar()
                                {
                                    id_Debitar = Convert.ToInt32(dr[0]),
                                    fk_idColeg = Convert.ToInt32(dr[1]),
                                    Matricula = Convert.ToInt32(dr[2].ToString()),
                                    Nombres = dr[3].ToString(),
                                    fk_idDebito = Convert.ToInt32(dr[4]),
                                    Codigo = Convert.ToInt32(dr[5].ToString()),
                                    Detalle = dr[6].ToString(),
                                    Importe = Convert.ToDecimal(dr[6]),
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
                        lista = new List<CE_Adebitar>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN USUARIO *****
        public int Registrar(CE_Usuarios obj, out string Mensaje)
        {
            int idUsuario = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarUsuario", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Apellido", obj.Apellido);
                        command.Parameters.AddWithValue("Nombres", obj.Nombres);
                        command.Parameters.AddWithValue("Nivel", obj.Nivel);
                        command.Parameters.AddWithValue("Funcion", obj.Funcion);
                        command.Parameters.AddWithValue("Usuario", obj.Usuario);
                        command.Parameters.AddWithValue("Clave", obj.Clave);
                        command.Parameters.AddWithValue("Activo", obj.Activo);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idUsuario = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idUsuario = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idUsuario;
        }

        //***** METODO PARA EDITAR UN USUARIO *****
        public bool Editar(CE_Usuarios obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarUsuario", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Usuario", obj.id_Usuario);
                        command.Parameters.AddWithValue("Apellido", obj.Apellido);
                        command.Parameters.AddWithValue("Nombres", obj.Nombres);
                        command.Parameters.AddWithValue("Nivel", obj.Nivel);
                        command.Parameters.AddWithValue("Funcion", obj.Funcion);
                        command.Parameters.AddWithValue("Usuario", obj.Usuario);
                        command.Parameters.AddWithValue("Clave", obj.Clave);
                        command.Parameters.AddWithValue("Activo", obj.Activo);
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

        //***** METODO PARA ELIMINAR UN USUARIO *****
        public bool Eliminar(CE_Usuarios obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EliminarUsuario", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Usuario", obj.id_Usuario);
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

        //***** METODO PARA BUSCAR LA LOCALIDAD COMPLETA *****
        public string BuscaCodPos(int local)
        {
            string localidad = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@local", local);
                    command.Connection = connection;
                    command.CommandText = "SELECT Localidades.CodigoPostal,Localidades.Localidad,Departamentos.Departamento,Provincias.Provincia FROM Localidades " +
                                          "INNER JOIN Departamentos ON id_Depto = Localidades.fk_Deptos " +
                                          "INNER JOIN Provincias    ON id_Prov  = Localidades.fk_Prov " +
                                          "WHERE id_Local = @local";
                    command.CommandType = CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            localidad = Convert.ToInt32(dr[0].ToString()) + " - " + dr[1].ToString() + " - " + dr[2].ToString() + " - " + dr[3].ToString();
                        };
                    }
                }
            }
            return localidad;
        }


    }
}
