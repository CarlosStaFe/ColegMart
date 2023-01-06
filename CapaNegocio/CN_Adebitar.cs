using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Adebitar
    {
        CD_Adebitar cD_Adebitar = new CD_Adebitar();

        //***** LLAMO AL METODO PARA LISTAR LOS DEBITOS A COLEGIADOS *****
        public List<CE_Adebitar> ListaAdebitar()
        {
            return cD_Adebitar.ListaAdebitar();
        }

        //***** REGISTRA UN NUEVO USUARIO *****
        public int Registrar(CE_Usuarios obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Apellido == "")
            {
                mensaje += "* Debe ingresar un Apellido. * ";
            }

            if (obj.Nombres == "")
            {
                mensaje += "Debe ingresar un Nombre. * ";
            }

            if (obj.Funcion == "")
            {
                mensaje += "Debe ingresar una Función. * ";
            }

            if (obj.Usuario == "")
            {
                mensaje += "Debe ingresar un Usuario. * ";
            }

            if (obj.Clave == "")
            {
                mensaje += "Debe ingresar una Clave. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Adebitar.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN USUARIO *****
        public bool Editar(CE_Usuarios obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Apellido == "")
            {
                mensaje += "* Debe ingresar un Apellido. * ";
            }

            if (obj.Nombres == "")
            {
                mensaje += "Debe ingresar un Nombre. * ";
            }

            if (obj.Funcion == "")
            {
                mensaje += "Debe ingresar una Función. * ";
            }

            if (obj.Usuario == "")
            {
                mensaje += "Debe ingresar un Usuario. * ";
            }

            if (obj.Clave == "")
            {
                mensaje += "Debe ingresar una Clave. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Adebitar.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN USUARIO *****
        public bool Eliminar(CE_Usuarios obj, out string mensaje)
        {
            return cD_Adebitar.Eliminar(obj, out mensaje);
        }

    }
}
