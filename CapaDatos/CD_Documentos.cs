using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Documentos : Conexion
    {
        //***** METODO PARA LISTAR LOS TIPOS DE DOCUMENTOS *****
        public List<CE_Documentos> ListaDocum()
        {
            List<CE_Documentos> lista = new List<CE_Documentos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Documentos";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Documentos()
                                {
                                    id_Doc = Convert.ToInt32(dr["id_Doc"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Codigo = Convert.ToInt32(dr["Codigo"]),
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Documentos>();
                    }
                }
            }
            return lista;
        }
    }
}
