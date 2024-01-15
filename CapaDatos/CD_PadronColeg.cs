using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_PadronColeg : Conexion
    {
        //***** METODO PARA REGISTRAR UN PADRON DE LOS COLEGIADOS *****
        public int Registrar(CE_PadronColeg obj, out string mensaje)
        {
            int idPadron = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistroPadronColeg", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Contador", obj.Contador);
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
                        command.Parameters.AddWithValue("CodigoIapos", obj.CodigoIapos);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("DomParti", obj.DomParti);
                        command.Parameters.AddWithValue("LocalidadParti", obj.LocalidadParti);
                        command.Parameters.AddWithValue("idCodPosParti", obj.idCodPosParti);
                        command.Parameters.AddWithValue("idLocalParti", obj.idLocalParti);
                        command.Parameters.AddWithValue("idDeptoParti", obj.idDeptoParti);
                        command.Parameters.AddWithValue("idProvParti", obj.idProvParti);
                        command.Parameters.AddWithValue("FijoParti", obj.FijoParti);
                        command.Parameters.AddWithValue("CeluParti", obj.CeluParti);
                        command.Parameters.AddWithValue("DomLabor", obj.DomLabor);
                        command.Parameters.AddWithValue("LocalidadLabor", obj.LocalidadLabor);
                        command.Parameters.AddWithValue("idCodPosLabor", obj.idCodPosLabor);
                        command.Parameters.AddWithValue("idLocalLabor", obj.idLocalLabor);
                        command.Parameters.AddWithValue("idDeptoLabor", obj.idDeptoLabor);
                        command.Parameters.AddWithValue("idProvLabor", obj.idProvLabor);
                        command.Parameters.AddWithValue("FijoLabor", obj.FijoLabor);
                        command.Parameters.AddWithValue("CeluLabor", obj.CeluLabor);
                        command.Parameters.AddWithValue("FecVenceFianza", obj.FecVenceFianza);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idPadron = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idPadron = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idPadron;
        }

        //***** METODO PARA BLANQUEAR LA TABLA *****
        public int Blanquear()
        {
            int idPadron = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE PadronColeg";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        idPadron = Convert.ToInt32(command.Parameters["idResultado"].Value);
                    }
                    catch (Exception)
                    {
                        idPadron = 0;
                    }
                }
            }
            return idPadron;
        }
    }
}
