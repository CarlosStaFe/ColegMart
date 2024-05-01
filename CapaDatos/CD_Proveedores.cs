using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Proveedores:Conexion
    {
        //***** METODO PARA LISTAR LOS PROVEEDORES *****
        public List<CE_Proveedores> ListaProv()
        {
            List<CE_Proveedores> lista = new List<CE_Proveedores>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Proveedores ORDER BY Numero";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Proveedores()
                                {
                                    id_Prov = Convert.ToInt32(dr["id_Prov"]),
                                    Numero = Convert.ToInt32(dr["Numero"]),
                                    RazonSocial = dr["RazonSocial"].ToString(),
                                    Titular = dr["Titular"].ToString(),
                                    Domicilio = dr["Domicilio"].ToString(),
                                    idCodPos = Convert.ToInt32(dr["idCodPos"]),
                                    idLocal = Convert.ToInt32(dr["idLocal"]),
                                    idDepto = Convert.ToInt32(dr["idDepto"]),
                                    idProv = Convert.ToInt32(dr["idProv"]),
                                    TipoIva = dr["TipoIva"].ToString(),
                                    Cuit = dr["Cuit"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    IngBrutos = dr["IngBrutos"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Saldo = Convert.ToDouble(dr["Saldo"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<CE_Proveedores>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN PROVEEDOR *****
        public int Registrar(CE_Proveedores obj, out string mensaje)
        {
            int idProv = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarProveedor", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_RazonSocial", obj.RazonSocial);
                        command.Parameters.AddWithValue("_Titular", obj.Titular);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_idCodPos", obj.idCodPos);
                        command.Parameters.AddWithValue("_idLocal", obj.idLocal);
                        command.Parameters.AddWithValue("_idDepto", obj.idDepto);
                        command.Parameters.AddWithValue("_idProv", obj.idProv);
                        command.Parameters.AddWithValue("_TipoIva", obj.TipoIva);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_IngBrutos", obj.IngBrutos);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);

                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idProv = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idProv = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idProv;
        }

        //***** METODO PARA EDITAR EL PROVEEDOR *****
        public bool Editar(CE_Proveedores obj, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarProveedor", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Prov", obj.id_Prov);
                        command.Parameters.AddWithValue("_Numero", obj.Numero);
                        command.Parameters.AddWithValue("_RazonSocial", obj.RazonSocial);
                        command.Parameters.AddWithValue("_Titular", obj.Titular);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_idCodPos", obj.idCodPos);
                        command.Parameters.AddWithValue("_idLocal", obj.idLocal);
                        command.Parameters.AddWithValue("_idDepto", obj.idDepto);
                        command.Parameters.AddWithValue("_idProv", obj.idProv);
                        command.Parameters.AddWithValue("_TipoIva", obj.TipoIva);
                        command.Parameters.AddWithValue("_Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_IngBrutos", obj.IngBrutos);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Saldo", obj.Saldo);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);

                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
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

        //***** METODO PARA DARLE UN NUMERO A UN PROVEEDOR *****
        public string AsignarNumero(string nro, out string mensaje)
        {
            mensaje = string.Empty;
            string nroprov = string.Empty;
            int numero = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT MAX(Numero) Numero FROM Proveedores";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nroprov = dr["Numero"].ToString();
                                numero = int.Parse(nroprov) + 1;
                                nroprov = numero.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                    }
                    return nroprov;
                }
            }
        }

        //***** METODO PARA BUSCAR UN PROVEEDOR *****
        public List<CE_Proveedores> ListaBuscado(string nro, out string mensaje)
        {
            List<CE_Proveedores> lista = new List<CE_Proveedores>();

            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@nro", nro);
                        command.CommandText = "SELECT * FROM Proveedores WHERE Numero = @nro";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Proveedores()
                                {
                                    id_Prov = Convert.ToInt32(dr["id_Prov"]),
                                    Numero = Convert.ToInt32(dr["Numero"]),
                                    RazonSocial = dr["RazonSocial"].ToString(),
                                    Titular = dr["Titular"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Proveedores>();
                    }
                    return lista;
                }
            }
        }

        //***** METODO PARA LISTAR LOS PROVEEDORES *****
        public List<CE_Proveedores> ListaPadron(string comando)
        {
            List<CE_Proveedores> lista = new List<CE_Proveedores>();

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
                                lista.Add(new CE_Proveedores()
                                {
                                    id_Prov = Convert.ToInt32(dr["id_Prov"]),
                                    Numero = Convert.ToInt32(dr["Numero"]),
                                    RazonSocial = dr["RazonSocial"].ToString(),
                                    Titular = dr["Titular"].ToString(),
                                    Domicilio = dr["Domicilio"].ToString(),
                                    idCodPos = Convert.ToInt32(dr["idCodPos"]),
                                    idLocal = Convert.ToInt32(dr["idLocal"]),
                                    idDepto = Convert.ToInt32(dr["idDepto"]),
                                    idProv = Convert.ToInt32(dr["idProv"]),
                                    TipoIva = dr["TipoIva"].ToString(),
                                    Cuit = dr["Cuit"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    IngBrutos = dr["IngBrutos"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Saldo = Convert.ToDouble(dr["Saldo"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Proveedores>();
                    }
                }
            }
            return lista;
        }

    }
}
