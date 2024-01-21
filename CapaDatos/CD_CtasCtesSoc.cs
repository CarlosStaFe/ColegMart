using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_CtasCtesSoc:Conexion
    {
        //***** METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesSoc> ListaCtaCte(int nro)
        {
            List<CE_CtasCtesSoc> lista = new List<CE_CtasCtesSoc>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@nro", nro);
                        command.CommandText = "SELECT * FROM CtasCtesSoc WHERE Numero = @nro ORDER BY Fecha, Item ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CtasCtesSoc()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    Numero = Convert.ToInt32(dr["Matricula"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Prefijo = dr["Prefijo"].ToString(),
                                    Subfijo = dr["Subfijo"].ToString(),
                                    Item = Convert.ToInt32(dr["Item"].ToString()),
                                    fk_idDebito = Convert.ToInt32(dr["fk_idDebito"]),
                                    Detalle = dr["Detalle"].ToString(),
                                    Periodo = dr["Periodo"].ToString(),
                                    Debe = Convert.ToDecimal(dr["Debe"].ToString()),
                                    Pagado = Convert.ToDecimal(dr["Pagado"].ToString()),
                                    FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                                    Saldo = Convert.ToDecimal(dr["Saldo"].ToString()),
                                    Estado = dr["Estado"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CtasCtesSoc>();
                    }
                }
            }
            return lista;
        }


    }
}
