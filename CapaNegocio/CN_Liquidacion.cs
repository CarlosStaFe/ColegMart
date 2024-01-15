using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Liquidacion
    {
        CD_Liquidacion cD_Liquidacion = new CD_Liquidacion();

        //***** REGISTRA LA LIQUIDACION DEL COLEGIADO *****
        public int Registrar(CE_Liquidacion obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Liquidacion.Registrar(obj, out mensaje);
            }
        }
    }
}
