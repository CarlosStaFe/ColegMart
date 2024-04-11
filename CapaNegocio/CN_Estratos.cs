using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Estratos
    {
        CD_Estratos cD_Estratos = new CD_Estratos();

        //***** LLAMO AL METODO PARA LISTAR LOS ESTRATOS *****
        public List<CE_Estratos> BuscaEstratos(int idEstrato)
        {
            return cD_Estratos.BuscaEstratos(idEstrato);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS ESTRATOS *****
        public List<CE_Estratos> ListaEstrato()
        {
            return cD_Estratos.ListaEstrato();
        }

        //***** LLAMO AL METODO PARA REGISTRAR UN ESTRATO *****
        public int Registrar(CE_Estratos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Estratos.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN ESTRATO *****
        public bool Editar(CE_Estratos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Estratos.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN ESTRATO *****
        public bool Eliminar(CE_Estratos obj, out string mensaje)
        {
            return cD_Estratos.Eliminar(obj, out mensaje);
        }

    }
}
