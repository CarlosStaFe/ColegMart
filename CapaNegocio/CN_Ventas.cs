using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Ventas
    {
        CD_Ventas cD_Ventas = new CD_Ventas();

        //***** REGISTRA UNA NUEVA VENTA *****
        public int Registrar(CE_Ventas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Ventas.Registrar(obj, out mensaje);
            }
        }

    }
}
