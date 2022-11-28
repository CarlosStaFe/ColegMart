using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        static string nombre_servidor = Dns.GetHostName();
        public static string cadena = "Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBColegMart;Persist Security Info=True;User ID=sa;Password=soporte";

        //static string nombre_servidor = Dns.GetHostName();
        //static private string cadena = "Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBColegMart;Persist Security Info=True;User ID=sa;Password=soporte";
        //private SqlConnection conexion = new SqlConnection(cadena);

        //public SqlConnection AbrirConexion()
        //{
        //    if (conexion.State == ConnectionState.Closed)
        //        conexion.Open();
        //    return conexion;
        //}

        //public SqlConnection CerrarConexion()
        //{
        //    if (conexion.State == ConnectionState.Open)
        //        conexion.Close();
        //    return conexion;
        //}
    }
}
