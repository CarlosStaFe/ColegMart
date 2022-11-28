using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Botones
    {
        private CD_Botones cDBotones = new CD_Botones();

        //***** LLAMO AL METODO PARA LISTAR LOS USUARIOS *****
        public List<CE_Botones> Listardor(int idUsuario)
        {
            return cDBotones.Listador(idUsuario);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS BOTONES *****
        public List<CE_Botones> Listar()
        {
            return cDBotones.Listar();
        }

        //***** LLAMO AL METODO PARA REGISTRAR UN USUARIO *****
        public int Registrar(CE_Botones obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "* Debe ingresar un Nombre. * ";
            }

            if (obj.Detalle == "")
            {
                Mensaje += "Debe ingresar un Detalle. * ";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cDBotones.Registrar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN BOTÓN *****
        public bool Editar(CE_Botones obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "* Debe ingresar un Nombre. * ";
            }

            if (obj.Detalle == "")
            {
                Mensaje += "Debe ingresar un Detalle. * ";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cDBotones.Editar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN BOTÓN *****
        public bool Eliminar(CE_Botones obj, out string Mensaje)
        {
            return cDBotones.Eliminar(obj, out Mensaje);
        }

    }
}
