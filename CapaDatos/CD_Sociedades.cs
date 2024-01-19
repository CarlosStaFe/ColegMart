using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Sociedades:Conexion
    {
        //***** METODO PARA LISTAR LAS SOCIEDADES *****
        public List<CE_Sociedades> ListaSoc()
        {
            List<CE_Sociedades> lista = new List<CE_Sociedades>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Sociedades ORDER BY Numero";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Sociedades()
                                {
                                    id_Soc = Convert.ToInt32(dr["id_Soc"]),
                                    Numero = Convert.ToInt32(dr["Numero"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Cuit = Convert.ToInt32(dr["Cuit"]),
                                    Domicilio = dr["Domicilio"].ToString(),
                                    idCodPostal = Convert.ToInt32(dr["idCodPostal"]),
                                    idLocal = Convert.ToInt32(dr["idLocal"]),
                                    idDepto = Convert.ToInt32(dr["idDepto"]),
                                    idProv = Convert.ToInt32(dr["idProv"]),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
                                    Inscripcion = Convert.ToInt32(dr["Inscripcion"]),
                                    Semestral = Convert.ToInt32(dr["Semestral"]),
                                    Martillero1 = Convert.ToInt32(dr["Martillero1"]),
                                    Martillero2 = Convert.ToInt32(dr["Martillero2"]),
                                    Martillero3 = Convert.ToInt32(dr["Martillero3"]),
                                    Martillero4 = Convert.ToInt32(dr["Martillero4"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Sociedades>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA SOCIEDAD *****
        public int Registrar(CE_Sociedades obj, out string mensaje)
        {
            int idSociedad = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarSociedad", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_idCodPostal", obj.idCodPostal);
                        command.Parameters.AddWithValue("_idLocal", obj.idLocal);
                        command.Parameters.AddWithValue("_idDepto", obj.idDepto);
                        command.Parameters.AddWithValue("_idProv", obj.idProv);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_Inscripcion", obj.Inscripcion);
                        command.Parameters.AddWithValue("_Semestral", obj.Semestral);
                        command.Parameters.AddWithValue("_Martillero1", obj.Martillero1);
                        command.Parameters.AddWithValue("_Martillero2", obj.Martillero2);
                        command.Parameters.AddWithValue("_Martillero3", obj.Martillero3);
                        command.Parameters.AddWithValue("_Martillero4", obj.Martillero4);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);

                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idSociedad = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idSociedad = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idSociedad;
        }

        //***** METODO PARA EDITAR LA SOCIEDAD *****
        public bool Editar(CE_Sociedades obj, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarSociedad", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Soc", obj.id_Soc);
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_idCodPostal", obj.idCodPostal);
                        command.Parameters.AddWithValue("_idLocal", obj.idLocal);
                        command.Parameters.AddWithValue("_idDepto", obj.idDepto);
                        command.Parameters.AddWithValue("_idProv", obj.idProv);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_Inscripcion", obj.Inscripcion);
                        command.Parameters.AddWithValue("_Semestral", obj.Semestral);
                        command.Parameters.AddWithValue("_Martillero1", obj.Martillero1);
                        command.Parameters.AddWithValue("_Martillero2", obj.Martillero2);
                        command.Parameters.AddWithValue("_Martillero3", obj.Martillero3);
                        command.Parameters.AddWithValue("_Martillero4", obj.Martillero4);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);

                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }

        //***** METODO PARA DARLE UN NUMERO A UNA SOCIEDAD *****
        public string AsignarNumero(string nro, out string mensaje)
        {
            mensaje = string.Empty;
            string nrosoc = string.Empty;
            int numero = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT MAX(Numero) Numero FROM Sociedades WHERE Numero < 80000";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nrosoc = dr["Numero"].ToString();
                                numero = int.Parse(nrosoc) + 1;
                                nrosoc = numero.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                    }
                    return nrosoc;
                }
            }
        }


    }
}
