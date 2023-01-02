using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Departamentos:Conexion
    {
        //***** METODO PARA LISTAR LOS DEPARTAMENTOS *****
        public List<CE_Departamentos> ListaDeptos()
        {
            List<CE_Departamentos> lista = new List<CE_Departamentos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SP_ListaDepartamentos";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Departamentos()
                                {
                                    id_Depto = Convert.ToInt32(dr["id_Depto"]),
                                    Departamento = dr["Departamento"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Departamentos>();
                    }
                }
            }
            return lista;
        }
    }
}
