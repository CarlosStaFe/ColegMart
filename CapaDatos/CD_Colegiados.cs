using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class CD_Colegiados : Conexion
    {

        //***** METODO PARA LISTAR LOS COLEGIADOS *****
        public List<CE_Colegiados> ListaColeg()
        {
            List<CE_Colegiados> lista = new List<CE_Colegiados>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Colegiados ORDER BY Matricula";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    CodigoIapos = dr["CodigoIapos"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FecEstado = Convert.ToDateTime(dr["FecEstado"]),
                                    DomParti = dr["DomParti"].ToString(),
                                    idCodPosParti = Convert.ToInt32(dr["idCodPosParti"] is DBNull ? 164 : dr["idCodPosParti"]),
                                    idLocalParti = Convert.ToInt32(dr["idLocalParti"] is DBNull ? 164 : dr["idLocalParti"]),
                                    idDeptoParti = Convert.ToInt32(dr["idDeptoParti"] is DBNull ? 1 : dr["idDeptoParti"]),
                                    idProvParti = Convert.ToInt32(dr["idProvParti"] is DBNull ? 1 : dr["idProvParti"]),
                                    FijoParti = dr["FijoParti"].ToString(),
                                    CeluParti = dr["CeluParti"].ToString(),
                                    DomLabor = dr["DomParti"].ToString(),
                                    idCodPosLabor = Convert.ToInt32(dr["idCodPosLabor"] is DBNull ? 164 : dr["idCodPosLabor"]),
                                    idLocalLabor = Convert.ToInt32(dr["idLocalLabor"] is DBNull ? 164 : dr["idLocalLabor"]),
                                    idDeptoLabor = Convert.ToInt32(dr["idDeptoLabor"] is DBNull ? 1 : dr["idDeptoLabor"]),
                                    idProvLabor = Convert.ToInt32(dr["idProvLabor"] is DBNull ? 1 : dr["idProvLabor"]),
                                    FijoLabor = dr["FijoLabor"].ToString(),
                                    CeluLabor = dr["CeluLabor"].ToString(),
                                    FecVenceFianza = Convert.ToDateTime(dr["FecVenceFianza"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                    Foto = dr["Foto"].ToString()
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

        //***** METODO PARA REGISTRAR UN COLEGIADO *****
        public int Registrar(CE_Colegiados obj, out string mensaje)
        {
            int idColegiado = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarColegiado", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_ApelMaterno", obj.ApelMaterno);
                        command.Parameters.AddWithValue("_FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("_LugarNacim", obj.LugarNacim);
                        command.Parameters.AddWithValue("_Nacionalidad", obj.Nacionalidad);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("_NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("_EstadoCivil", obj.EstadoCivil);
                        command.Parameters.AddWithValue("_Juramento", obj.Juramento);
                        command.Parameters.AddWithValue("_Tomo", obj.Tomo);
                        command.Parameters.AddWithValue("_Folio", obj.Folio);
                        command.Parameters.AddWithValue("_Categoria", obj.Categoria);
                        command.Parameters.AddWithValue("_CodigoIapos", obj.CodigoIapos);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("_DomParti", obj.DomParti);
                        command.Parameters.AddWithValue("_idCodPosParti", obj.idCodPosParti);
                        command.Parameters.AddWithValue("_idLocalParti", obj.idLocalParti);
                        command.Parameters.AddWithValue("_idDeptoParti", obj.idDeptoParti);
                        command.Parameters.AddWithValue("_idProvParti", obj.idProvParti);
                        command.Parameters.AddWithValue("_FijoParti", obj.FijoParti);
                        command.Parameters.AddWithValue("_CeluParti", obj.CeluParti);
                        command.Parameters.AddWithValue("_DomLabor", obj.DomLabor);
                        command.Parameters.AddWithValue("_idCodPosLabor", obj.idCodPosLabor);
                        command.Parameters.AddWithValue("_idLocalLabor", obj.idLocalLabor);
                        command.Parameters.AddWithValue("_idDeptoLabor", obj.idDeptoLabor);
                        command.Parameters.AddWithValue("_idProvLabor", obj.idProvLabor);
                        command.Parameters.AddWithValue("_FijoLabor", obj.FijoLabor);
                        command.Parameters.AddWithValue("_CeluLabor", obj.CeluLabor);
                        command.Parameters.AddWithValue("_FecVenceFianza", obj.FecVenceFianza);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.AddWithValue("_Foto", obj.Foto);

                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idColegiado = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
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

        //***** METODO PARA EDITAR UN COLEGIADO *****
        public bool Editar(CE_Colegiados obj, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarColegiado", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Coleg", obj.id_Coleg);
                        command.Parameters.AddWithValue("_Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_ApelMaterno", obj.ApelMaterno);
                        command.Parameters.AddWithValue("_FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("_LugarNacim", obj.LugarNacim);
                        command.Parameters.AddWithValue("_Nacionalidad", obj.Nacionalidad);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("_NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("_EstadoCivil", obj.EstadoCivil);
                        command.Parameters.AddWithValue("_Juramento", obj.Juramento);
                        command.Parameters.AddWithValue("_Tomo", obj.Tomo);
                        command.Parameters.AddWithValue("_Folio", obj.Folio);
                        command.Parameters.AddWithValue("_Categoria", obj.Categoria);
                        command.Parameters.AddWithValue("_CodigoIapos", obj.CodigoIapos);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("_DomParti", obj.DomParti);
                        command.Parameters.AddWithValue("_idCodPosParti", obj.idCodPosParti);
                        command.Parameters.AddWithValue("_idLocalParti", obj.idLocalParti);
                        command.Parameters.AddWithValue("_idDeptoParti", obj.idDeptoParti);
                        command.Parameters.AddWithValue("_idProvParti", obj.idProvParti);
                        command.Parameters.AddWithValue("_FijoParti", obj.FijoParti);
                        command.Parameters.AddWithValue("_CeluParti", obj.CeluParti);
                        command.Parameters.AddWithValue("_DomLabor", obj.DomLabor);
                        command.Parameters.AddWithValue("_idCodPosLabor", obj.idCodPosLabor);
                        command.Parameters.AddWithValue("_idLocalLabor", obj.idLocalLabor);
                        command.Parameters.AddWithValue("_idDeptoLabor", obj.idDeptoLabor);
                        command.Parameters.AddWithValue("_idProvLabor", obj.idProvLabor);
                        command.Parameters.AddWithValue("_FijoLabor", obj.FijoLabor);
                        command.Parameters.AddWithValue("_CeluLabor", obj.CeluLabor);
                        command.Parameters.AddWithValue("_FecVenceFianza", obj.FecVenceFianza);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.AddWithValue("_Foto", obj.Foto);

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

        //***** METODO PARA PONER UNA MATRÍCULA MAYOR A 80000 *****
        public string SinMatricula(string nromatri, out string mensaje)
        {
            mensaje = string.Empty;
            //bool respuesta = true;
            int numero = 0;


            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT MAX(Matricula) Matricula FROM Colegiados WHERE Matricula > 79000 AND Matricula < 90000";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
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
            //bool respuesta = true;
            int numero = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT MAX(Matricula) Matricula FROM Colegiados WHERE Matricula < 50000";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
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

        //***** METODO PARA BUSCAR UN COLEGIADO DESEADO *****
        public List<CE_Colegiados> ListaBuscado(string matri, out string mensaje)
        {
            List<CE_Colegiados> lista = new List<CE_Colegiados>();

            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@matri", matri);
                        command.CommandText = "SELECT * FROM Colegiados WHERE Matricula = @matri";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Colegiados()
                                {
                                    id_Coleg = Convert.ToInt32(dr["id_Coleg"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FecVenceFianza = Convert.ToDateTime(dr["FecVenceFianza"]),
                                    Juramento = Convert.ToDateTime(dr["Juramento"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Colegiados>();
                    }
                    return lista;
                }
            }
        }

        //***** METODO PARA ACTUALIZAR EL ESTADO *****
        public bool ActualizarEstado(int matri, string estado)
        {
            bool respuesta = true;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Matricula", matri);
                        command.Parameters.AddWithValue("@Estado", estado);
                        command.Parameters.AddWithValue("@FecEstado", DateTime.Now);
                        command.Connection = connection;
                        command.CommandText = "UPDATE Colegiados SET Estado = @Estado, FecEstado = @FecEstado WHERE Matricula = @Matricula";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                //FotoByte = (byte[])dr["Foto"];
                            }
                        };
                    }
                    catch (Exception)
                    {
                        respuesta = false;
                    }
                    return respuesta;
                }
            }
        }

        //***** METODO PARA LISTAR LOS COLEGIADOS *****
        public List<CE_Colegiados> ListaPadron(string comando)
        {
            List<CE_Colegiados> lista = new List<CE_Colegiados>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = comando;
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    CodigoIapos = dr["CodigoIapos"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FecEstado = Convert.ToDateTime(dr["FecEstado"]),
                                    DomParti = dr["DomParti"].ToString(),
                                    idCodPosParti = Convert.ToInt32(dr["idCodPosParti"] is DBNull ? 164 : dr["idCodPosParti"]),
                                    idLocalParti = Convert.ToInt32(dr["idLocalParti"] is DBNull ? 164 : dr["idLocalParti"]),
                                    idDeptoParti = Convert.ToInt32(dr["idDeptoParti"] is DBNull ? 1 : dr["idDeptoParti"]),
                                    idProvParti = Convert.ToInt32(dr["idProvParti"] is DBNull ? 1 : dr["idProvParti"]),
                                    FijoParti = dr["FijoParti"].ToString(),
                                    CeluParti = dr["CeluParti"].ToString(),
                                    DomLabor = dr["DomParti"].ToString(),
                                    idCodPosLabor = Convert.ToInt32(dr["idCodPosLabor"] is DBNull ? 164 : dr["idCodPosLabor"]),
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

        //***** METODO PARA LISTAR LOS COLEGIADOS A LIQUIDAR *****
        public List<CE_Colegiados> LiquidaColeg(string desde, string hasta)
        {
            List<CE_Colegiados> lista = new List<CE_Colegiados>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@desde", desde);
                        command.Parameters.AddWithValue("@hasta", hasta);
                        command.CommandText = "SELECT * FROM Colegiados WHERE Matricula >= @desde AND Matricula <= @hasta ORDER BY Matricula";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
                                    CodigoIapos = dr["CodigoIapos"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FecEstado = Convert.ToDateTime(dr["FecEstado"]),
                                    DomParti = dr["DomParti"].ToString(),
                                    idCodPosParti = Convert.ToInt32(dr["idCodPosParti"] is DBNull ? 164 : dr["idCodPosParti"]),
                                    idLocalParti = Convert.ToInt32(dr["idLocalParti"] is DBNull ? 164 : dr["idLocalParti"]),
                                    idDeptoParti = Convert.ToInt32(dr["idDeptoParti"] is DBNull ? 1 : dr["idDeptoParti"]),
                                    idProvParti = Convert.ToInt32(dr["idProvParti"] is DBNull ? 1 : dr["idProvParti"]),
                                    FijoParti = dr["FijoParti"].ToString(),
                                    CeluParti = dr["CeluParti"].ToString(),
                                    DomLabor = dr["DomParti"].ToString(),
                                    idCodPosLabor = Convert.ToInt32(dr["idCodPosLabor"] is DBNull ? 164 : dr["idCodPosLabor"]),
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
    }
}
