using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_SaldosPagos
    {
        CD_SaldosPagos cD_SaldosPagos = new CD_SaldosPagos();

        //***** REGISTRA LOS MOVIMIENTOS DE SALDOS O PAGOS *****
        public int Registrar(CE_SaldosPagos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_SaldosPagos.Registrar(obj, out mensaje);
            }
        }

        //***** BLANQUEA LA TABLA DE SALDOS Y PAGOS *****
        public int Blanquear()
        {
            return cD_SaldosPagos.Blanquear();
        }


    }
}
