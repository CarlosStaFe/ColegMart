using CapaEntidad;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_PadronSoc : Conexion
    {
        //***** METODO PARA REGISTRAR UN PADRON DE LAS SOCIEDADES *****
        public int Registrar(CE_PadronSoc obj, out string mensaje)
        {
            int idPadron = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistroPadronSoc", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Contador", obj.Contador);
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
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
                        command.Parameters.AddWithValue("_Nombre1", obj.Nombre1);
                        command.Parameters.AddWithValue("_Fianza1", obj.Fianza1);
                        command.Parameters.AddWithValue("_Martillero2", obj.Martillero2);
                        command.Parameters.AddWithValue("_Nombre2", obj.Nombre2);
                        command.Parameters.AddWithValue("_Fianza2", obj.Fianza2);
                        command.Parameters.AddWithValue("_Martillero3", obj.Martillero3);
                        command.Parameters.AddWithValue("_Nombre3", obj.Nombre3);
                        command.Parameters.AddWithValue("_Fianza3", obj.Fianza3);
                        command.Parameters.AddWithValue("_Martillero4", obj.Martillero4);
                        command.Parameters.AddWithValue("_Nombre4", obj.Nombre4);
                        command.Parameters.AddWithValue("_Fianza4", obj.Fianza4);
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
                        command.CommandText = "DELETE FROM PadronSoc";
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
