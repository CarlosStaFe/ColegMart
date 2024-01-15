using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Renglones
    {
        CD_Renglones cD_Renglones = new CD_Renglones();

        //***** REGISTRA LOS RENGLONES DE LOS COBROS VARIOS *****
        public int Registrar(CE_Renglones obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Renglones.Registrar(obj, out mensaje);
            }
        }

        //***** BLANQUEA LA TABLA DE COBROS VARIOS *****
        public int Blanquear()
        {
            return cD_Renglones.Blanquear();
        }

        //***** REGRABA LOS RENGLONES PARA IMPRIMIR *****
        public bool Actualizar(CE_Renglones obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Renglones.Actualizar(obj, out mensaje);
            }
        }

    }
}
