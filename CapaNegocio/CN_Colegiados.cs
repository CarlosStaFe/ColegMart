using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Colegiados
    {
        CD_Colegiados cD_Colegiados = new CD_Colegiados();

        //***** LLAMO AL METODO PARA LISTAR LOS COLEGIADOS *****
        public List<CE_Colegiados> ListaColeg()
        {
            return cD_Colegiados.ListaColeg();
        }

        //***** REGISTRA UN NUEVO COLEGIADO *****
        public int Registrar(CE_Colegiados obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.ApelNombres == "")
            {
                Mensaje += "* Debe ingresar un Apellido y Nombres. * ";
            }

            if (obj.LugarNacim == "")
            {
                Mensaje += "Debe ingresar el lugar de nacimiento. * ";
            }

            if (obj.Nacionalidad == "")
            {
                Mensaje += "Debe ingresar la nacionalidad. * ";
            }

            if (obj.TipoDoc == "")
            {
                Mensaje += "Debe ingresar un tipo de documento. * ";
            }

            if (obj.NumeroDoc == 0)
            {
                Mensaje += "Debe ingresar el número de documento. * ";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Colegiados.Registrar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN COLEGIADO *****
        public bool Editar(CE_Colegiados obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.ApelNombres == "")
            {
                Mensaje += "* Debe ingresar un Apellido y Nombres. * ";
            }

            if (obj.LugarNacim == "")
            {
                Mensaje += "Debe ingresar el lugar de nacimiento. * ";
            }

            if (obj.Nacionalidad == "")
            {
                Mensaje += "Debe ingresar la nacionalidad. * ";
            }

            if (obj.TipoDoc == "")
            {
                Mensaje += "Debe ingresar un tipo de documento. * ";
            }

            if (obj.NumeroDoc == 0)
            {
                Mensaje += "Debe ingresar el número de documento. * ";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Colegiados.Editar(obj, out Mensaje);
            }
        }

        //***** LLAMO AL METODO PARA OBTENER LA FOTO *****
        public byte[] ObtenerFoto(string id,out bool obtenido)
        {
            return cD_Colegiados.ObtenerFoto(id, out obtenido);
        }

        //***** LLAMO AL METODO PARA ACTUALIZAR LA FOTO *****
        public bool ActualizarFoto(string id, byte[] imagen, out string Mensaje)
        {
            return cD_Colegiados.ActualizarFoto(id, imagen, out Mensaje);
        }

    }
}
