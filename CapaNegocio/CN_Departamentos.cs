using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Departamentos
    {
        CD_Departamentos cD_Departamentos = new CD_Departamentos();

        //***** LLAMO AL METODO PARA LISTAR LOS DEPARTAMENTOS *****
        public List<CE_Departamentos> ListaDeptos()
        {
            return cD_Departamentos.ListaDeptos();
        }
    }
}
