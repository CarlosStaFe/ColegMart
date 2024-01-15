using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Fianzas
    {
        CD_Fianzas cD_Fianzas = new CD_Fianzas();

        //***** LLAMO AL METODO PARA LISTAR LAS FIANZAS *****
        public List<CE_Fianzas> ListaFianza()
        {
            return cD_Fianzas.ListaFianza();
        }

        //***** REGISTRA UNA NUEVA FIANZA *****
        public int Registrar(CE_Fianzas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Fianzas.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA FIANZA *****
        public bool Editar(CE_Fianzas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Fianzas.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA FIANZA *****
        public bool Eliminar(CE_Fianzas obj, out string mensaje)
        {
            return cD_Fianzas.Eliminar(obj, out mensaje);
        }

    }
}
