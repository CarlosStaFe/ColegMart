using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    //***** BUSQUEDA DEL BOTÓN DEL USUARIO *****
    public class CN_Botones
    {
        CD_Botones cD_Botones = new CD_Botones();

        //***** LLAMO AL METODO PARA LISTAR LOS USUARIOS Y SUS BOTONES *****
        public List<CE_Botones> BuscaBotones(int idUsuario)
        {
            return cD_Botones.BuscaBotones(idUsuario);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS BOTONES *****
        public List<CE_Botones> ListaBoton()
        {
            return cD_Botones.ListaBoton();
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
                return cD_Botones.Registrar(obj, out Mensaje);
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
                return cD_Botones.Editar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN BOTÓN *****
        public bool Eliminar(CE_Botones obj, out string Mensaje)
        {
            return cD_Botones.Eliminar(obj, out Mensaje);
        }

    }
}
