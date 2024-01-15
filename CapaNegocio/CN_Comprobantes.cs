﻿using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Comprobantes
    {
        CD_Comprobantes cD_Comprobantes = new CD_Comprobantes();

        //***** LLAMO AL METODO PARA BUSCAR EL NÚMERO DE COMPROBANTE COMPROBANTE *****
        public int BuscoCpbte(string tipo)
        {
            return cD_Comprobantes.BuscoCpbte(tipo);
        }

        //***** LLAMO AL METODO PARA REGISTRAR UN USUARIO *****
        public bool GraboCpbte(string tipo, int nrocpbte)
        {
            return cD_Comprobantes.GraboCpbte(tipo, nrocpbte);
        }

    }
}
