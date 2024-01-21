using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CtasCtesSoc
    {
        CD_CtasCtesSoc cD_CtasCtesSoc = new CD_CtasCtesSoc();

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesSoc> ListaCtaCte(int nro)
        {
            return cD_CtasCtesSoc.ListaCtaCte(nro);
        }

    }
}
