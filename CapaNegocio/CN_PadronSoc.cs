using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_PadronSoc
    {
        CD_PadronSoc cD_PadronSoc = new CD_PadronSoc();

        //***** REGISTRA UNA NUEVA SOCIEDAD *****
        public int Registrar(CE_PadronSoc obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_PadronSoc.Registrar(obj, out mensaje);
            }
        }

        //***** BLANQUEA LA TABLA DE PADRONES *****
        public int Blanquear()
        {
            return cD_PadronSoc.Blanquear();
        }

    }
}
