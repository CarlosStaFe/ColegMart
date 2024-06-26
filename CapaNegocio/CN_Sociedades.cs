﻿using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Sociedades
    {
        CD_Sociedades cD_Sociedades = new CD_Sociedades();

        //***** LLAMO AL METODO PARA LISTAR LAS SOCIEDADES *****
        public List<CE_Sociedades> ListaSoc()
        {
            return cD_Sociedades.ListaSoc();
        }

        //***** REGISTRA UNA NUEVA SOCIEDAD *****
        public int Registrar(CE_Sociedades obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                mensaje += "* Debe ingresar un Nombre. * ";
            }

            if (obj.Cuit == "")
            {
                mensaje += "Debe ingresar una C.U.I.T. * ";
            }

            if (obj.Domicilio == "")
            {
                mensaje += "Debe ingresar un domicilio. * ";
            }

            if (obj.Telefono == "")
            {
                mensaje += "Debe ingresar un teléfono. * ";
            }

            if (obj.Tipo == "")
            {
                mensaje += "Debe ingresar el tipo de sociedad. * ";
            }

            if (obj.Estado == "")
            {
                mensaje += "Debe ingresar el estado. * ";
            }

            if (obj.Inscripcion == 0)
            {
                mensaje += "Debe ingresar un código de inscripción. * ";
            }

            if (obj.Semestral == 0)
            {
                mensaje += "Debe ingresar un código de liquidación semestral. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Sociedades.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA SOCIEDAD *****
        public bool Editar(CE_Sociedades obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                mensaje += "* Debe ingresar un Nombre. * ";
            }

            if (obj.Cuit == "")
            {
                mensaje += "Debe ingresar una C.U.I.T. * ";
            }

            if (obj.Domicilio == "")
            {
                mensaje += "Debe ingresar un domicilio. * ";
            }

            if (obj.Telefono == "")
            {
                mensaje += "Debe ingresar un teléfono. * ";
            }

            if (obj.Tipo == "")
            {
                mensaje += "Debe ingresar el tipo de sociedad. * ";
            }

            if (obj.Estado == "")
            {
                mensaje += "Debe ingresar el estado. * ";
            }

            if (obj.Inscripcion == 0)
            {
                mensaje += "Debe ingresar un código de inscripción. * ";
            }

            if (obj.Semestral == 0)
            {
                mensaje += "Debe ingresar un código de liquidación semestral. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Sociedades.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA BUSCAR UN NUMERO PARA UNA SOCIEDAD *****
        public string AsignarNumero(string numero, out string mensaje)
        {
            return cD_Sociedades.AsignarNumero(numero, out mensaje);
        }

        //***** LLAMO AL METODO PARA LISTAR UNA SOCIEDAD BUSCADA *****
        public List<CE_Sociedades> ListaBuscado(string nro, out string mensaje)
        {
            return cD_Sociedades.ListaBuscado(nro, out mensaje);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS SOCIEDADES A LIQUIDAR *****
        public List<CE_Sociedades> LiquidaSoc(string desde, string hasta)
        {
            return cD_Sociedades.LiquidaSoc(desde, hasta);
        }

        //***** ACTUALIZO EL ESTADO DE LAS SOCIEDADES *****
        public bool ActualizarEstado(int nro, string estado)
        {
            return cD_Sociedades.ActualizarEstado(nro, estado);
        }

        //***** LLAMO AL METODO PARA LISTAR EL PADRON DE LAS SOCIEDADES *****
        public List<CE_Sociedades> ListaPadron(string comando)
        {
            return cD_Sociedades.ListaPadron(comando);
        }

    }
}
