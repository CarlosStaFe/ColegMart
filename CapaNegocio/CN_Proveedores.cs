using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Proveedores
    {
        CD_Proveedores cD_Proveedores = new CD_Proveedores();

        //***** LLAMO AL METODO PARA LISTAR LOS PROVEEDORES *****
        public List<CE_Proveedores> ListaProv()
        {
            return cD_Proveedores.ListaProv();
        }

        //***** REGISTRA UN NUEVO PROVEEDOR *****
        public int Registrar(CE_Proveedores obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.RazonSocial == "")
            {
                mensaje += "* Debe ingresar una Razón Social. * ";
            }

            if (obj.Titular == "")
            {
                mensaje += "* Debe ingresar un Titular. * ";
            }

            if (obj.Domicilio == "")
            {
                mensaje += "Debe ingresar un domicilio. * ";
            }

            if (obj.TipoIva == "")
            {
                mensaje += "Debe ingresar un tipo de I.V.A. * ";
            }

            if (obj.Cuit == "")
            {
                mensaje += "Debe ingresar una C.U.I.T. * ";
            }

            if (obj.Telefono == "")
            {
                mensaje += "Debe ingresar un teléfono. * ";
            }

            if (obj.IngBrutos == "")
            {
                mensaje += "Debe ingresar el número de Ingresos Brutos. * ";
            }

            if (obj.Email == "")
            {
                mensaje += "Debe ingresar el Email. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Proveedores.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN PROVEEDOR *****
        public bool Editar(CE_Proveedores obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.RazonSocial == "")
            {
                mensaje += "* Debe ingresar una Razón Social. * ";
            }

            if (obj.Titular == "")
            {
                mensaje += "* Debe ingresar un Titular. * ";
            }

            if (obj.Domicilio == "")
            {
                mensaje += "Debe ingresar un domicilio. * ";
            }

            if (obj.TipoIva == "")
            {
                mensaje += "Debe ingresar un tipo de I.V.A. * ";
            }

            if (obj.Cuit == "")
            {
                mensaje += "Debe ingresar una C.U.I.T. * ";
            }

            if (obj.Telefono == "")
            {
                mensaje += "Debe ingresar un teléfono. * ";
            }

            if (obj.IngBrutos == "")
            {
                mensaje += "Debe ingresar el número de Ingresos Brutos. * ";
            }

            if (obj.Email == "")
            {
                mensaje += "Debe ingresar el Email. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Proveedores.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA BUSCAR UN NUMERO PARA UN PROVEEDOR *****
        public string AsignarNumero(string numero, out string mensaje)
        {
            return cD_Proveedores.AsignarNumero(numero, out mensaje);
        }

        //***** LLAMO AL METODO PARA LISTAR UN PROVEEDOR BUSCADO *****
        public List<CE_Proveedores> ListaBuscado(string nro, out string mensaje)
        {
            return cD_Proveedores.ListaBuscado(nro, out mensaje);
        }

        //***** LLAMO AL METODO PARA LISTAR EL PADRON DE PROVEEDORES *****
        public List<CE_Proveedores> ListaPadron(string comando)
        {
            return cD_Proveedores.ListaPadron(comando);
        }

    }
}
