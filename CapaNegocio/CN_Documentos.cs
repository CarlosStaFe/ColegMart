using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Documentos
    {
        CD_Documentos cD_Documentos = new CD_Documentos();

        //***** LLAMO AL METODO PARA LISTAR LOS DOCUMENTOS *****
        public List<CE_Documentos> ListaDocum()
        {
            return cD_Documentos.ListaDocum();
        }
    }
}
