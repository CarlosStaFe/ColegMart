using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Debitos
    {
        CD_Debitos cD_Debitos = new CD_Debitos();

        //***** LLAMO AL METODO PARA LISTAR LOS DEBITOS *****
        public List<CE_Debitos> ListaDebito()
        {
            return cD_Debitos.ListaDebito();
        }

        //***** LLAMO AL METODO PARA LISTAR LOS DEBITOS ACTIVOS Y DE BOLETAS *****
        public List<CE_Debitos> ListaDebitoBol()
        {
            return cD_Debitos.ListaDebitoBol();
        }

        //***** LLAMO AL METODO PARA LISTAR LOS DEBITOS ACTIVOS Y DE RECIBOS *****
        public List<CE_Debitos> ListaDebitoRec()
        {
            return cD_Debitos.ListaDebitoRec();
        }

        //***** BUSQUEDA EL DEBITO PARA LIQUIDAR *****
        public List<CE_Debitos> BuscoDebito(string debitoAB, string debitoI)
        {
            return cD_Debitos.BuscoDebito(debitoAB,debitoI);
        }

        //***** REGISTRA UN NUEVO DEBITO *****
        public int Registrar(CE_Debitos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Codigo == 0)
            {
                mensaje += "* Debe ingresar un Código. * ";
            }

            if (obj.Detalle == "")
            {
                mensaje += "Debe ingresar un Detalle. * ";
            }

            if (obj.Categoria == "")
            {
                mensaje += "Debe ingresar una Categoría. * ";
            }

            if (obj.TipoDebito == "")
            {
                mensaje += "Debe ingresar un Tipo de Débito. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Debitos.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN DÉBITO *****
        public bool Editar(CE_Debitos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Codigo == 0)
            {
                mensaje += "* Debe ingresar un Código. * ";
            }

            if (obj.Detalle == "")
            {
                mensaje += "Debe ingresar un Detalle. * ";
            }

            if (obj.Categoria == "")
            {
                mensaje += "Debe ingresar una Categoría. * ";
            }

            if (obj.TipoDebito == "")
            {
                mensaje += "Debe ingresar un Tipo de Débito. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Debitos.Editar(obj, out mensaje);
            }
        }





    }
}
