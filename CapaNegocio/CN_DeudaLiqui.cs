using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_DeudaLiqui
    {
        CD_DeudaLiqui cD_DeudaLiqui = new CD_DeudaLiqui();

        //***** LLAMO AL METODO PARA REGISTRAR LA DEUDA PARA LA LIQUIDACION *****
        public int Registrar(CE_DeudaLiqui obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_DeudaLiqui.Registrar(obj, out mensaje);
            }
        }


    }
}
