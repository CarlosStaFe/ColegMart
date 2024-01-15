﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Fianzas : Conexion
    {
        //***** METODO PARA LISTAR LAS FIANZAS *****
        public List<CE_Fianzas> ListaFianza()
        {
            List<CE_Fianzas> lista = new List<CE_Fianzas>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Fianzas ORDER BY FecPagoFza DESC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Fianzas()
                                {
                                    id_Fza = Convert.ToInt32(dr["id_Fza"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
                                    ApelNomMatri = dr["ApelNomMatri"].ToString(),
                                    TelMatri = dr["TelMatri"].ToString(),
                                    FecPagoFza = Convert.ToDateTime(dr["FecPagoFza"]),
                                    UserFecPagoFza = dr["UserFecPagoFza"].ToString(),
                                    FecFirmaMat = Convert.ToDateTime(dr["FecFirmaMat"]),
                                    UserFirmaMat = dr["UserFirmaMat"].ToString(),
                                    FecFirmaFiador = Convert.ToDateTime(dr["FecFirmaFiador"]),
                                    UserFirmaFiador = dr["UserFirmaFiador"].ToString(),
                                    FecVtoFianza = Convert.ToDateTime(dr["FecVtoFianza"]),
                                    NroDocFiador = dr["NroDocFiador"].ToString(),
                                    ApelNomFiador = dr["ApelNomFiador"].ToString(),
                                    CalleFiador = dr["CalleFiador"].ToString(),
                                    TelFiador = dr["TelFiador"].ToString(),
                                    EstadoFza = dr["EstadoFza"].ToString(),
                                    Obs = dr["Obs"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Fianzas>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA FIANZA *****
        public int Registrar(CE_Fianzas obj, out string Mensaje)
        {
            int idFza = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarFianza", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("ApelNomMatri", obj.ApelNomMatri);
                        command.Parameters.AddWithValue("TelMatri", obj.TelMatri);
                        command.Parameters.AddWithValue("FecPagoFza", obj.FecPagoFza);
                        command.Parameters.AddWithValue("UserFecPagoFza", obj.UserFecPagoFza);
                        command.Parameters.AddWithValue("FecFirmaMat", obj.FecFirmaMat);
                        command.Parameters.AddWithValue("UserFirmaMat", obj.UserFirmaMat);
                        command.Parameters.AddWithValue("FecFirmaFiador", obj.FecFirmaFiador);
                        command.Parameters.AddWithValue("UserFirmaFiador", obj.UserFirmaFiador);
                        command.Parameters.AddWithValue("FecVtoFianza", obj.FecVtoFianza);
                        command.Parameters.AddWithValue("NroDocFiador", obj.NroDocFiador);
                        command.Parameters.AddWithValue("ApelNomFiador", obj.ApelNomFiador);
                        command.Parameters.AddWithValue("CalleFiador", obj.CalleFiador);
                        command.Parameters.AddWithValue("TelFiador", obj.TelFiador);
                        command.Parameters.AddWithValue("EstadoFza", obj.EstadoFza);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.Add("idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idFza = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idFza = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idFza;
        }

        //***** METODO PARA EDITAR UNA FIANZA *****
        public bool Editar(CE_Fianzas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarFianza", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Fza", obj.id_Fza);
                        //command.Parameters.AddWithValue("Matricula", obj.Matricula);
                        //command.Parameters.AddWithValue("ApelNomMatri", obj.ApelNomMatri);
                        //command.Parameters.AddWithValue("TelMatri", obj.TelMatri);
                        //command.Parameters.AddWithValue("FecPagoFza", obj.FecPagoFza);
                        //command.Parameters.AddWithValue("UserFecPagoFza", obj.UserFecPagoFza);
                        command.Parameters.AddWithValue("FecFirmaMat", obj.FecFirmaMat);
                        command.Parameters.AddWithValue("UserFirmaMat", obj.UserFirmaMat);
                        command.Parameters.AddWithValue("FecFirmaFiador", obj.FecFirmaFiador);
                        command.Parameters.AddWithValue("UserFirmaFiador", obj.UserFirmaFiador);
                        command.Parameters.AddWithValue("FecVtoFianza", obj.FecVtoFianza);
                        command.Parameters.AddWithValue("NroDocFiador", obj.NroDocFiador);
                        command.Parameters.AddWithValue("ApelNomFiador", obj.ApelNomFiador);
                        command.Parameters.AddWithValue("CalleFiador", obj.CalleFiador);
                        command.Parameters.AddWithValue("TelFiador", obj.TelFiador);
                        command.Parameters.AddWithValue("EstadoFza", obj.EstadoFza);
                        //command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        Mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }

        //***** METODO PARA ELIMINAR UNA FIANZA *****
        public bool Eliminar(CE_Fianzas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarFianza", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Fza", obj.id_Fza);
                        command.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        Mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }
    }
}
