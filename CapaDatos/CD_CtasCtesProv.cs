using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_CtasCtesProv:Conexion
    {
        //***** METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesProv> ListaCtaCte(int numeroprov)
        {
            List<CE_CtasCtesProv> lista = new List<CE_CtasCtesProv>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@nro", numeroprov);
                        command.CommandText = "SELECT * FROM CtasCtesProv WHERE NroProv = @nro ORDER BY Fecha, Item ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CtasCtesProv()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    idCpra = Convert.ToInt32(dr["idCpra"]),
                                    NroProv = Convert.ToInt32(dr["NroProv"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Prefijo = dr["Prefijo"].ToString(),
                                    Subfijo = dr["Subfijo"].ToString(),
                                    Item = Convert.ToInt32(dr["Item"].ToString()),
                                    Detalle = dr["Detalle"].ToString(),
                                    Haber = Convert.ToDecimal(dr["Haber"].ToString()),
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
                        lista = new List<CE_CtasCtesProv>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA GRABAR LA CUENTA CORRIENTE *****
        public int Registrar(CE_CtasCtesProv obj, out string mensaje)
        {
            int idCtaCte = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarCtasCtesProv", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_idCpra", obj.idCpra);
                        command.Parameters.AddWithValue("_NroProv", obj.NroProv);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("_Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("_Item", obj.Item);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Haber", obj.Haber);
                        command.Parameters.AddWithValue("_Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("_FechaPago", obj.FechaPago);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCtaCte = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idCtaCte = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idCtaCte;
        }

        //***** METODO PARA LISTAR LOS SALDOS Y LOS PAGOS *****
        public List<CE_CtasCtesProv> ListarSaldoPago(string comando)
        {
            List<CE_CtasCtesProv> lista = new List<CE_CtasCtesProv>();

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
                                lista.Add(new CE_CtasCtesProv()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    idCpra = Convert.ToInt32(dr["idCpra"]),
                                    NroProv = Convert.ToInt32(dr["NroProv"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Prefijo = dr["Prefijo"].ToString(),
                                    Subfijo = dr["Subfijo"].ToString(),
                                    Item = Convert.ToInt32(dr["Item"].ToString()),
                                    Detalle = dr["Detalle"].ToString(),
                                    Haber = Convert.ToDecimal(dr["Haber"].ToString()),
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
                        lista = new List<CE_CtasCtesProv>();
                    }
                }
            }
            return lista;
        }

    }
}
