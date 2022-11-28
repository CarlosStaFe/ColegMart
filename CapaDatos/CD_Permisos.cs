using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Permisos
    {
        //***** METODO PARA LISTAR LOS PERMISOS PARA LOS USUARIOS *****
        public List<CE_Permisos> ListaPermiso(int idUsuario)
        {
            List<CE_Permisos> lista = new List<CE_Permisos>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Permisos P");
                    query.AppendLine("INNER JOIN Usuarios U ON U.id_Usuario = P.fk_Usuarios");
                    query.AppendLine("INNER JOIN Botones B ON B.id_Boton = P.fk_Botones");
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

        //***** METODO PARA REGISTRAR UN PERMISO *****
        public int Registrar(CE_Permisos obj, out string Mensaje)
        {
            int idBoton = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarPermiso", oconexion);
                    cmd.Parameters.AddWithValue("fk_Usuarios", obj.OUsuario);
                    cmd.Parameters.AddWithValue("fk_Botones", obj.OBoton);
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



    }
}
