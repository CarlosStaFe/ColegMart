using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Bancos
    {
        CD_Bancos cD_Bancos = new CD_Bancos();

        //***** LLAMO AL METODO PARA LISTAR LOS BANCOS *****
        public List<CE_Bancos> BuscaBancos(int idBanco)
        {
            return cD_Bancos.BuscaBancos(idBanco);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS BANCOS *****
        public List<CE_Bancos> ListaBancos()
        {
            return cD_Bancos.ListaBancos();
        }

        //***** LLAMO AL METODO PARA REGISTRAR UN USUARIO *****
        public int Registrar(CE_Bancos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Cuit == "")
            {
                mensaje += "* Debe ingresar un C.U.I.T. * ";
            }

            if (obj.Nombre == "")
            {
                mensaje += "Debe ingresar un Detalle. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Bancos.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN BANCO *****
        public bool Editar(CE_Bancos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Cuit == "")
            {
                mensaje += "* Debe ingresar un C.U.I.T. * ";
            }

            if (obj.Nombre == "")
            {
                mensaje += "Debe ingresar un Detalle. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Bancos.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN BANCO *****
        public bool Eliminar(CE_Bancos obj, out string mensaje)
        {
            return cD_Bancos.Eliminar(obj, out mensaje);
        }

    }
}
