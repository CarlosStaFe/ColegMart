using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_CtasCtesSoc:Conexion
    {
        //***** METODO PARA CALCULAR LA CANTIDAD DE ITEMS ADEUDADOS DE LAS SOCIEDADES *****
        public int ContarDeuda(int numerosoc)
        {
            int cantidad = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@nro", numerosoc);
                    command.CommandText = "SELECT COUNT(DISTINCT Periodo) AS cantidad FROM ctasctessoc WHERE Numero = @nro AND Saldo > 0";
                    command.CommandType = CommandType.Text;
                    cantidad = Convert.ToInt32(command.ExecuteScalar());

                    return cantidad;
                }
            }
        }

        //***** METODO PARA CALCULAR EL SALDO ADEUDADO DE LAS SOCIEDADES *****
        public decimal CalcularSaldo(int numerosoc)
        {
            decimal saldo = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@nro", numerosoc);
                    command.CommandText = "SELECT SUM(Saldo) AS Saldo FROM CtasCtesSoc WHERE Numero = @nro AND Saldo != 0";
                    command.CommandType = CommandType.Text;
                    //saldo = Convert.ToDecimal(command.ExecuteScalar() is DBNull ? 0 : saldo);
                    saldo = Convert.ToDecimal(command.ExecuteScalar());
                    return saldo;
                }
            }
        }

        //***** METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesSoc> ListaCtaCte(int numerosoc)
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
                        command.Parameters.AddWithValue("@nro", numerosoc);
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
                                    Numero = Convert.ToInt32(dr["Numero"]),
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

        //***** METODO PARA LISTAR LAS CUENTAS CORRIENTES PARA CARGARLOS EN UN ARRAY *****
        public List<CE_CtasCtesSoc> ListaDeuda(int numerosoc)
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
                        command.Parameters.AddWithValue("@numero", numerosoc);
                        command.CommandText = "SELECT * FROM ctasctessoc WHERE Numero = @numero AND saldo != 0 ORDER BY Fecha, Item ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CtasCtesSoc()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    Numero = Convert.ToInt32(dr["Numero"]),
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
                    catch (Exception ex)
                    {
                        lista = new List<CE_CtasCtesSoc>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA GRABAR LA CUENTA CORRIENTE *****
        public int Registrar(CE_CtasCtesSoc obj, out string mensaje)
        {
            int idCtaCte = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarCtasCtesSoc", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("_Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("_Item", obj.Item);
                        command.Parameters.AddWithValue("_fk_idDebito", obj.fk_idDebito);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("_Debe", obj.Debe);
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

    }
}
