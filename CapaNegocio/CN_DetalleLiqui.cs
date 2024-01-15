using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_DetalleLiqui
    {
        CD_DetalleLiqui cD_DetalleLiqui = new CD_DetalleLiqui();

        //***** LLAMO AL METODO PARA REGISTRAR EL DETALLE DE LA LIQUIDACION *****
        public int Registrar(CE_DetalleLiqui obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_DetalleLiqui.Registrar(obj, out mensaje);
            }
        }

    }
}
