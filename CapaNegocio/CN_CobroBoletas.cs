using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_CobroBoletas
    {
        CD_CobroBoletas cD_CobroBoletas = new CD_CobroBoletas();

        //***** LLAMO AL METODO PARA REGISTRAR LOS COBROS DE BOLETAS *****
        public int Registrar(CE_CobroBoletas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_CobroBoletas.Registrar(obj, out mensaje);
            }
        }

    }
}
