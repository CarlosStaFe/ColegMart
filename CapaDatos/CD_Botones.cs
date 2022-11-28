using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Botones
    {
        //***** METODO PARA LISTAR LOS BOTONES PARA LOS BOTONES *****
        public List<CE_Botones> Listador(int idUsuario)
        {
            List<CE_Botones> lista = new List<CE_Botones>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT B.Nombre FROM Botones B");
                    query.AppendLine("INNER JOIN Permisos P ON B.id_Boton = P.fk_Botones");
                    query.AppendLine("INNER JOIN Usuarios U ON U.id_Usuario = P.fk_Usuarios");
                    query.AppendLine("WHERE U.id_Usuario = @idUsuario");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    if (oconexion.State == ConnectionState.Closed)
                        oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CE_Botones()
                            {
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<CE_Botones>();
                }
                oconexion.Close();
            }
            return lista;
        }

        //***** METODO PARA LISTAR LOS BOTONES *****
        public List<CE_Botones> Listar()
        {
            List<CE_Botones> lista = new List<CE_Botones>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select * from Botones";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    if (oconexion.State == ConnectionState.Closed)
                        oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CE_Botones()
                            {
                                id_Boton = Convert.ToInt32(dr["id_Boton"]),
                                Nombre = dr["Nombre"].ToString(),
                                Detalle = dr["Detalle"].ToString(),
                                UserRegistro = dr["UserRegistro"].ToString()//,
                                //FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<CE_Botones>();
                }
                oconexion.Close();
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN BOTON *****
        public int Registrar(CE_Botones obj, out string Mensaje)
        {
            int idBoton = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarBoton", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Detalle", obj.Detalle);
                    cmd.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                    cmd.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (oconexion.State == ConnectionState.Closed)
                        oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idBoton = Convert.ToInt32(cmd.Parameters["idResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idBoton = 0;
                Mensaje = ex.Message;
            }
            return idBoton;
        }

        //***** METODO PARA EDITAR UN BOTON *****
        public bool Editar(CE_Botones obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarBoton", oconexion);
                    cmd.Parameters.AddWithValue("id_Boton", obj.id_Boton);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Detalle", obj.Detalle);
                    cmd.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                    cmd.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (oconexion.State == ConnectionState.Closed)
                        oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }

        //***** METODO PARA ELIMINAR UN BOTON *****
        public bool Eliminar(CE_Botones obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarBoton", oconexion);
                    cmd.Parameters.AddWithValue("id_Boton", obj.id_Boton);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (oconexion.State == ConnectionState.Closed)
                        oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
    }
}
