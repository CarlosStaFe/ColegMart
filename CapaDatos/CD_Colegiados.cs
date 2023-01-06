using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CapaDatos
{
    public class CD_Colegiados:Conexion
    {
        byte[] FotoByte = new byte[0];
        private int img;

        //***** METODO PARA LISTAR LOS COLEGIADOS *****
        public List<CE_Colegiados> ListaColeg()
        {
            List<CE_Colegiados> lista = new List<CE_Colegiados>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Colegiados ORDER BY Matricula";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Colegiados()
                                {
                                    id_Coleg = Convert.ToInt32(dr["id_Coleg"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    ApelMaterno = dr["ApelMaterno"].ToString(),
                                    FechaNacim = Convert.ToDateTime(dr["FechaNacim"]),
                                    LugarNacim = dr["LugarNacim"].ToString(),
                                    Nacionalidad = dr["Nacionalidad"].ToString(),
                                    TipoDoc = dr["TipoDoc"].ToString(),
                                    NumeroDoc = Convert.ToInt32(dr["NumeroDoc"].ToString()),
                                    Cuit = dr["Cuit"].ToString(),
                                    Sexo = dr["Sexo"].ToString(),
                                    EstadoCivil = dr["EstadoCivil"].ToString(),
                                    Juramento = Convert.ToDateTime(dr["Juramento"]),
                                    Tomo = dr["Tomo"].ToString(),
                                    Folio = dr["Folio"].ToString(),
                                    Categoria = dr["Categoria"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FecEstado = Convert.ToDateTime(dr["FecEstado"]),
                                    DomParti = dr["DomParti"].ToString(),
                                    idLocalParti = Convert.ToInt32(dr["idLocalParti"] is DBNull ? 164 : dr["idLocalParti"]),
                                    idDeptoParti = Convert.ToInt32(dr["idDeptoParti"] is DBNull ? 1 : dr["idDeptoParti"]),
                                    idProvParti = Convert.ToInt32(dr["idProvParti"] is DBNull ? 1 : dr["idProvParti"]),
                                    FijoParti = dr["FijoParti"].ToString(),
                                    CeluParti = dr["CeluParti"].ToString(),
                                    DomLabor = dr["DomParti"].ToString(),
                                    idLocalLabor = Convert.ToInt32(dr["idLocalLabor"] is DBNull ? 164 : dr["idLocalLabor"]),
                                    idDeptoLabor = Convert.ToInt32(dr["idDeptoLabor"] is DBNull ? 1 : dr["idDeptoLabor"]),
                                    idProvLabor = Convert.ToInt32(dr["idProvLabor"] is DBNull ? 1 : dr["idProvLabor"]),
                                    FijoLabor = dr["FijoLabor"].ToString(),
                                    CeluLabor = dr["CeluLabor"].ToString(),
                                    FecVenceFianza = Convert.ToDateTime(dr["FecVenceFianza"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Colegiados>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN USUARIO *****
        public int Registrar(CE_Colegiados obj, out string mensaje)
        {
            int idColegiado = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarColegiado", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("ApelMaterno", obj.ApelMaterno);
                        command.Parameters.AddWithValue("FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("LugarNacim", obj.LugarNacim);
                        command.Parameters.AddWithValue("Nacionalidad", obj.Nacionalidad);
                        command.Parameters.AddWithValue("TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("EstadoCivil", obj.EstadoCivil);
                        command.Parameters.AddWithValue("Juramento", obj.Juramento);
                        command.Parameters.AddWithValue("Tomo", obj.Tomo);
                        command.Parameters.AddWithValue("Folio", obj.Folio);
                        command.Parameters.AddWithValue("Categoria", obj.Categoria);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("DomParti", obj.DomParti);
                        command.Parameters.AddWithValue("idLocalParti", obj.idLocalParti);
                        command.Parameters.AddWithValue("idDeptoParti", obj.idDeptoParti);
                        command.Parameters.AddWithValue("idProvParti", obj.idProvParti);
                        command.Parameters.AddWithValue("FijoParti", obj.FijoParti);
                        command.Parameters.AddWithValue("CeluParti", obj.CeluParti);
                        command.Parameters.AddWithValue("DomLabor", obj.DomLabor);
                        command.Parameters.AddWithValue("idLocalLabor", obj.idLocalLabor);
                        command.Parameters.AddWithValue("idDeptoLabor", obj.idDeptoLabor);
                        command.Parameters.AddWithValue("idProvLabor", obj.idProvLabor);
                        command.Parameters.AddWithValue("FijoLabor", obj.FijoLabor);
                        command.Parameters.AddWithValue("CeluLabor", obj.CeluLabor);
                        command.Parameters.AddWithValue("FecVenceFianza", obj.FecVenceFianza);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idColegiado = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idColegiado = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idColegiado;
        }

        //***** METODO PARA EDITAR UN USUARIO *****
        public bool Editar(CE_Colegiados obj, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarColegiado", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Coleg", obj.id_Coleg);
                        command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("ApelMaterno", obj.ApelMaterno);
                        command.Parameters.AddWithValue("FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("LugarNacim", obj.LugarNacim);
                        command.Parameters.AddWithValue("Nacionalidad", obj.Nacionalidad);
                        command.Parameters.AddWithValue("TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("EstadoCivil", obj.EstadoCivil);
                        command.Parameters.AddWithValue("Juramento", obj.Juramento);
                        command.Parameters.AddWithValue("Tomo", obj.Tomo);
                        command.Parameters.AddWithValue("Folio", obj.Folio);
                        command.Parameters.AddWithValue("Categoria", obj.Categoria);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("DomParti", obj.DomParti);
                        command.Parameters.AddWithValue("idLocalParti", obj.idLocalParti);
                        command.Parameters.AddWithValue("idDeptoParti", obj.idDeptoParti);
                        command.Parameters.AddWithValue("idProvParti", obj.idProvParti);
                        command.Parameters.AddWithValue("FijoParti", obj.FijoParti);
                        command.Parameters.AddWithValue("CeluParti", obj.CeluParti);
                        command.Parameters.AddWithValue("DomLabor", obj.DomLabor);
                        command.Parameters.AddWithValue("idLocalLabor", obj.idLocalLabor);
                        command.Parameters.AddWithValue("idDeptoLabor", obj.idDeptoLabor);
                        command.Parameters.AddWithValue("idProvLabor", obj.idProvLabor);
                        command.Parameters.AddWithValue("FijoLabor", obj.FijoLabor);
                        command.Parameters.AddWithValue("CeluLabor", obj.CeluLabor);
                        command.Parameters.AddWithValue("FecVenceFianza", obj.FecVenceFianza);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
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

        //***** METODO PARA OBTENER LA FOTO DEL COLEGIADO *****
        public byte[] ObtenerFoto(int id, out bool obtenido)
        {
            obtenido = true;
            byte[] FotoByte = new byte[0];

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id_Coleg", id);
                        command.Connection = connection;
                        command.CommandText = "SELECT Foto FROM Colegiados WHERE id_Coleg = @id_Coleg";
                        command.CommandType = CommandType.Text;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if(!dr.IsDBNull(0))
                                {
                                    FotoByte = (byte[])dr["Foto"];
                                }
                                else
                                {
                                    obtenido = false;
                                    FotoByte = new byte[0];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        obtenido = false;
                        FotoByte = new byte[0];
                    }
                    return FotoByte;
                }
            }
        }

        //***** METODO PARA REGRABAR LA FOTO DEL COLEGIADO *****
        public bool ActualizarFoto(int id, byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id_Coleg", id);
                        command.Parameters.AddWithValue("@Foto", image);
                        command.Connection = connection;
                        command.CommandText = "UPDATE Colegiados SET Foto = @Foto WHERE id_Coleg = @id_Coleg";
                        command.CommandType = CommandType.Text;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                FotoByte = (byte[])dr["Foto"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                        respuesta = false;
                    }
                    return respuesta;
                }
            }
        }

        //***** METODO PARA PONER UNA MATRÍCULA MAYOR A 80000 *****
        public string SinMatricula(string nromatri, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            int numero = 0;


            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT MAX(Matricula) Matricula FROM Colegiados WHERE Matricula > 79000 AND Matricula < 90000";
                        command.CommandType = CommandType.Text;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nromatri = dr["Matricula"].ToString();
                                if (nromatri == "")
                                {
                                    nromatri = "80000";
                                }
                                else
                                {
                                    numero = int.Parse(nromatri) + 1;
                                    nromatri = numero.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                    }
                    return nromatri;
                }
            }
        }

        //***** METODO PARA DARLE LA MATRICULA DESPUÉS DEL JURAMENTO *****
        public string AsignarMatricula(string nromatri, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            int numero = 0;


            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT MAX(Matricula) Matricula FROM Colegiados WHERE Matricula < 50000";
                        command.CommandType = CommandType.Text;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nromatri = dr["Matricula"].ToString();
                                numero = int.Parse(nromatri) + 1;
                                nromatri = numero.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                    }
                    return nromatri;
                }
            }
        }




    }
}
