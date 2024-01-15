using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cajas
    {
        CD_Cajas cD_Cajas = new CD_Cajas();

        //***** REGISTRA UN NUEVO MOVIMIENTO DE CAJA *****
        public int Registrar(CE_Cajas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Cajas.Registrar(obj, out mensaje);
            }
        }

    }
}
