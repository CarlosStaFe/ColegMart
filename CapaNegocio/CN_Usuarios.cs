using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios cDUsuarios = new CD_Usuarios();

        //***** LLAMO AL METODO PARA LISTAR LOS USUARIOS *****
        public List<CE_Usuarios> Listar()
        {
            return cDUsuarios.Listar();
        }

        //***** LLAMO AL METODO PARA REGISTRAR UN USUARIO *****
        public int Registrar(CE_Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Apellido == "")
            {
                Mensaje += "* Debe ingresar un Apellido. * ";
            }

            if (obj.Nombres == "")
            {
                Mensaje += "Debe ingresar un Nombre. * ";
            }

            if (obj.Funcion == "")
            {
                Mensaje += "Debe ingresar una Función. * ";
            }

            if (obj.Usuario == "")
            {
                Mensaje += "Debe ingresar un Usuario. * ";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Debe ingresar una Clave. * ";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cDUsuarios.Registrar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN USUARIO *****
        public bool Editar(CE_Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Apellido == "")
            {
                Mensaje += "* Debe ingresar un Apellido. * ";
            }

            if (obj.Nombres == "")
            {
                Mensaje += "Debe ingresar un Nombre. * ";
            }

            if (obj.Funcion == "")
            {
                Mensaje += "Debe ingresar una Función. * ";
            }

            if (obj.Usuario == "")
            {
                Mensaje += "Debe ingresar un Usuario. * ";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Debe ingresar una Clave. * ";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cDUsuarios.Editar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN USUARIO *****
        public bool Eliminar(CE_Usuarios obj, out string Mensaje)
        {
            return cDUsuarios.Eliminar(obj, out Mensaje);
        }
    }
}
