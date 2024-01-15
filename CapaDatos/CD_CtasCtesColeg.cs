using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_CtasCtesColeg:Conexion
    {
        //***** METODO PARA CALCULAR LA CANTIDAD DE ITEMS ADEUDADOS DE LOS COLEGIADOS *****
        public int ContarDeuda(int idColeg)
        {
            int cantidad = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idColeg", idColeg);
                    command.CommandText = "SELECT COUNT(DISTINCT Periodo) AS cantidad FROM CtasCtesColeg WHERE fk_idColeg = @idColeg AND Saldo > 0";
                    command.CommandType = CommandType.Text;
                    cantidad = Convert.ToInt32(command.ExecuteScalar());

                    return cantidad;
                }
            }
        }

        //***** METODO PARA CALCULAR EL SALDO ADEUDADO DE LOS COLEGIADOS *****
        public decimal CalcularSaldo(int idColeg)
        {
            decimal saldo = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idColeg", idColeg);
                    command.CommandText = "SELECT SUM(Saldo) AS Saldo FROM CtasCtesColeg WHERE fk_idColeg = @idColeg AND Saldo != 0";
                    command.CommandType = CommandType.Text;
                    //saldo = Convert.ToDecimal(command.ExecuteScalar() is DBNull ? 0 : saldo);
                    saldo = Convert.ToDecimal(command.ExecuteScalar());
                    return saldo;
                }
            }
        }

        //***** METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesColeg> ListaCtaCte(int matri)
        {
            List<CE_CtasCtesColeg> lista = new List<CE_CtasCtesColeg>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@matri", matri);
                        command.CommandText = "SELECT * FROM CtasCtesColeg WHERE Matricula = @matri ORDER BY Fecha, Item ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CtasCtesColeg()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    fk_idColeg= Convert.ToInt32(dr["fk_idColeg"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
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
                        lista = new List<CE_CtasCtesColeg>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA LISTAR LAS CUENTAS CORRIENTES PARA CARGARLOS EN UN ARRAY *****
        public List<CE_CtasCtesColeg> ListaDeuda(int matri)
        {
            List<CE_CtasCtesColeg> lista = new List<CE_CtasCtesColeg>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@matri", matri);
                        command.CommandText = "SELECT * FROM CtasCtesColeg WHERE Matricula = @matri AND saldo != 0 ORDER BY Fecha, Item ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CtasCtesColeg()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    fk_idColeg = Convert.ToInt32(dr["fk_idColeg"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
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
                        lista = new List<CE_CtasCtesColeg>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA GRABAR LA CUENTA CORRIENTE *****
        public int Registrar(CE_CtasCtesColeg obj, out string mensaje)
        {
            int idCtaCte = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spGrabarCtasCtesColeg", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("fk_idColeg", obj.fk_idColeg);
                        command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Prefijo", obj.Prefijo);
                        command.Parameters.AddWithValue("Subfijo", obj.Subfijo);
                        command.Parameters.AddWithValue("Item", obj.Item);
                        command.Parameters.AddWithValue("fk_idDebito", obj.fk_idDebito);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Periodo", obj.Periodo);
                        command.Parameters.AddWithValue("Debe", obj.Debe);
                        command.Parameters.AddWithValue("Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("FechaPago", obj.FechaPago);
                        command.Parameters.AddWithValue("Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCtaCte = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
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

        //***** METODO PARA GRABAR LOS PAGOS EN LOS COMPROBANTES DE CUENTA CORRIENTE *****
        public bool Actualizar(CE_CtasCtesColeg obj, int id, int matricula, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spReGrabarCtasCtesColeg", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id_CtaCte", id);
                        command.Parameters.AddWithValue("@matricula", matricula);
                        command.Parameters.AddWithValue("Pagado", obj.Pagado);
                        command.Parameters.AddWithValue("FechaPago", obj.FechaPago);
                        command.Parameters.AddWithValue("Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
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

        //***** METODO PARA LISTAR LOS SALDOS Y LOS PAGOS *****
        public List<CE_CtasCtesColeg> ListarSaldoPago(string comando)
        {
            List<CE_CtasCtesColeg> lista = new List<CE_CtasCtesColeg>();

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
                                lista.Add(new CE_CtasCtesColeg()
                                {
                                    id_CtaCte = Convert.ToInt32(dr["id_CtaCte"]),
                                    fk_idColeg = Convert.ToInt32(dr["fk_idColeg"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
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
                        lista = new List<CE_CtasCtesColeg>();
                    }
                }
            }
            return lista;
        }
    }
}
