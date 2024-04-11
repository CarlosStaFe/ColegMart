using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CtasCtesColeg
    {
        CD_CtasCtesColeg cD_CtasCtesColeg = new CD_CtasCtesColeg();

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES DE LOS COLEGIADOS *****
        public int ContarDeuda(int id)
        {
            return cD_CtasCtesColeg.ContarDeuda(id);
        }

        //***** LLAMO AL METODO PARA CALCULAR EL SALDO DE LAS CUENTAS CORIIENTES *****
        public int SaldoColeg(int id)
        {
            return (int)cD_CtasCtesColeg.SaldoColeg(id);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CUENTAS CORRIENTES *****
        public List<CE_CtasCtesColeg> ListaCtaCte(int matri)
        {
            return cD_CtasCtesColeg.ListaCtaCte(matri);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CUOTAS ADEUDADAS *****
        public List<CE_CtasCtesColeg> ListaDeuda(int matri)
        {
            return cD_CtasCtesColeg.ListaDeuda(matri);
        }

        //***** REGISTRA UN MOVIMIENTO DE LA CTA CTE *****
        public int Registrar(CE_CtasCtesColeg obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_CtasCtesColeg.Registrar(obj, out mensaje);
            }
        }

        //***** REGISTRA LOS MOVIMIENTOS DE LA CTA CTE *****
        public bool Actualizar(CE_CtasCtesColeg obj, int id, int matricula, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_CtasCtesColeg.Actualizar(obj, id, matricula, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA LISTAR LOS SALDOS Y PADOS *****
        public List<CE_CtasCtesColeg> ListarSaldoPago(string comando)
        {
            return cD_CtasCtesColeg.ListarSaldoPago(comando);
        }

        //***** LLAMO AL METODO PARA BUSCAR SI EXISTE EL PERIODO PAGADO *****
        public int BuscaPago(int matricula, string periodo)
        {
            return cD_CtasCtesColeg.BuscaPago(matricula,periodo);
        }

    }
}
