using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CtasCtesSoc
    {
        CD_CtasCtesSoc cD_CtasCtesSoc = new CD_CtasCtesSoc();

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES DE LAS SOCIEDADES *****
        public int ContarDeuda(int numerosoc)
        {
            return cD_CtasCtesSoc.ContarDeuda(numerosoc);
        }

        //***** LLAMO AL METODO PARA CALCULAR EL SALDO DE LAS CUENTAS CORRIENTES *****
        public int SaldoSoc(int numerosoc)
        {
            return (int)cD_CtasCtesSoc.SaldoSoc(numerosoc);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesSoc> ListaCtaCte(int numerosoc)
        {
            return cD_CtasCtesSoc.ListaCtaCte(numerosoc);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CUOTAS ADEUDADAS *****
        public List<CE_CtasCtesSoc> ListaDeuda(int numerosoc)
        {
            return cD_CtasCtesSoc.ListaDeuda(numerosoc);
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

        //***** LLAMO AL METODO PARA LISTAR LOS SALDOS Y PADOS *****
        public List<CE_CtasCtesSoc> ListarSaldoPago(string comando)
        {
            return cD_CtasCtesSoc.ListarSaldoPago(comando);
        }

    }
}
