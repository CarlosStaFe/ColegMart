using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_LoteBanco:Conexion
    {
        //***** METODO PARA BUSCAR LOS LOTES DE BANCOS *****
        public List<CE_LoteBanco> BuscaLote(int lote)
        {
            List<CE_LoteBanco> lista = new List<CE_LoteBanco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@lote", lote);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM LoteBanco WHERE NroLote = @lote";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_LoteBanco()
                                {
                                    NroLote = Convert.ToInt32(dr["NroLote"].ToString()),
                                    FechaLote = Convert.ToDateTime(dr["FechaLote"].ToString()),
                                    CantRegLote = Convert.ToInt32(dr["CantRegLote"].ToString()),
                                    ProcesoLote = Convert.ToDateTime(dr["ProcesoLote"].ToString())
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_LoteBanco>();
                    }
                    return lista;
                }
            }
        }

    }
}
