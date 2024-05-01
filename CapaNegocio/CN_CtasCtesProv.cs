using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CtasCtesProv
    {
        CD_CtasCtesProv cD_CtasCtesProv = new CD_CtasCtesProv();

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesProv> ListaCtaCte(int numerosoc)
        {
            return cD_CtasCtesProv.ListaCtaCte(numerosoc);
        }

        //***** REGISTRA UN MOVIMIENTO DE LA CTA CTE *****
        public int Registrar(CE_CtasCtesProv obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_CtasCtesProv.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA LISTAR LOS SALDOS Y PADOS *****
        public List<CE_CtasCtesProv> ListarSaldoPago(string comando)
        {
            return cD_CtasCtesProv.ListarSaldoPago(comando);
        }
    }
}
