using System.Data.SqlClient;
using System.Net;

namespace CapaDatos
{
    public abstract class Conexion
    {
        static string nombre_servidor = Dns.GetHostName();
        //public static string cadena = "Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBColegMart;Persist Security Info=True;User ID=sa;Password=soporte";

        private readonly string connectionString;

        public Conexion()
        {
            connectionString = "Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBColegMart;Persist Security Info=True;User ID=sa;Password=soporte";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        //static string nombre_servidor = Dns.GetHostName();
        //static private string cadena = "Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBColegMart;Persist Security Info=True;User ID=sa;Password=soporte";
        //public SqlConnection conexion = new SqlConnection(cadena);

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
