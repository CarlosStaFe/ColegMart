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
                        command.Parameters.AddWithValue("_Contador", obj.Contador);
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
                        command.Parameters.AddWithValue("_LocalidadParti", obj.LocalidadParti);
                        command.Parameters.AddWithValue("_idCodPosParti", obj.idCodPosParti);
                        command.Parameters.AddWithValue("_idLocalParti", obj.idLocalParti);
                        command.Parameters.AddWithValue("_idDeptoParti", obj.idDeptoParti);
                        command.Parameters.AddWithValue("_idProvParti", obj.idProvParti);
                        command.Parameters.AddWithValue("_FijoParti", obj.FijoParti);
                        command.Parameters.AddWithValue("_CeluParti", obj.CeluParti);
                        command.Parameters.AddWithValue("_DomLabor", obj.DomLabor);
                        command.Parameters.AddWithValue("_LocalidadLabor", obj.LocalidadLabor);
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
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idPadron = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
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
                        command.CommandText = "DELETE FROM PadronColeg";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

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
