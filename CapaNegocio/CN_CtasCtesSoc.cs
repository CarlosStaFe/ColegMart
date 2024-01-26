using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CtasCtesSoc
    {
        CD_CtasCtesSoc cD_CtasCtesSoc = new CD_CtasCtesSoc();

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES DE LAS SOCIEDADES *****
        public int ContarDeuda(int numero)
        {
            return cD_CtasCtesSoc.ContarDeuda(numero);
        }

        //***** LLAMO AL METODO PARA CALCULAR EL SALDO DE LAS CUENTAS CORIIENTES *****
        public int CalcularSaldo(int numero)
        {
            return (int)cD_CtasCtesSoc.CalcularSaldo(numero);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesSoc> ListaCtaCte(int numero)
        {
            return cD_CtasCtesSoc.ListaCtaCte(numero);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CUOTAS ADEUDADAS *****
        public List<CE_CtasCtesSoc> ListaDeuda(int numero)
        {
            return cD_CtasCtesSoc.ListaDeuda(numero);
        }

        //***** REGISTRA UN MOVIMIENTO DE LA CTA CTE *****
        public int Registrar(CE_CtasCtesSoc obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_CtasCtesSoc.Registrar(obj, out mensaje);
            }
        }

    }
}
