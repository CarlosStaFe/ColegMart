using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_LoteBanco
    {
        //***** BUSQUEDA DEL LOTE DE BANCO *****
        CD_LoteBanco cD_Lote = new CD_LoteBanco();

        //***** LLAMO AL METODO PARA LISTAR LOS LOTES DE BANCOS *****
        public List<CE_LoteBanco> BuscaLote(int lote)
        {
            return cD_Lote.BuscaLote(lote);
        }
    }
}
