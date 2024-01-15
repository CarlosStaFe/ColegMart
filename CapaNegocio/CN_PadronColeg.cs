using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_PadronColeg
    {
        CD_PadronColeg cD_PadronColeg = new CD_PadronColeg();

        //***** REGISTRA UN NUEVO COLEGIADO *****
        public int Registrar(CE_PadronColeg obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_PadronColeg.Registrar(obj, out mensaje);
            }
        }

        //***** BLANQUEA LA TABLA DE PADRONES *****
        public int Blanquear()
        {
            return cD_PadronColeg.Blanquear();
        }

    }
}
