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
        public int Registrar(CE_Colegiados obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.ApelNombres == "")
            {
                mensaje += "* Debe ingresar un Apellido y Nombres. * ";
            }

            if (obj.LugarNacim == "")
            {
                mensaje += "Debe ingresar el lugar de nacimiento. * ";
            }

            if (obj.Nacionalidad == "")
            {
                mensaje += "Debe ingresar la nacionalidad. * ";
            }

            if (obj.TipoDoc == "")
            {
                mensaje += "Debe ingresar un tipo de documento. * ";
            }

            if (obj.NumeroDoc == 0)
            {
                mensaje += "Debe ingresar el número de documento. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Colegiados.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN COLEGIADO *****
        public bool Editar(CE_Colegiados obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.ApelNombres == "")
            {
                mensaje += "* Debe ingresar un Apellido y Nombres. * ";
            }

            if (obj.LugarNacim == "")
            {
                mensaje += "Debe ingresar el lugar de nacimiento. * ";
            }

            if (obj.Nacionalidad == "")
            {
                mensaje += "Debe ingresar la nacionalidad. * ";
            }

            if (obj.TipoDoc == "")
            {
                mensaje += "Debe ingresar un tipo de documento. * ";
            }

            if (obj.NumeroDoc == 0)
            {
                mensaje += "Debe ingresar el número de documento. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Colegiados.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA OBTENER LA FOTO *****
        public byte[] ObtenerFoto(int id,out bool obtenido)
        {
            return cD_Colegiados.ObtenerFoto(id, out obtenido);
        }

        //***** LLAMO AL METODO PARA ACTUALIZAR LA FOTO *****
        public bool ActualizarFoto(int id, byte[] imagen, out string mensaje)
        {
            return cD_Colegiados.ActualizarFoto(id, imagen, out mensaje);
        }

        //***** LLAMO AL METODO PARA BUSCAR UNA MATRICULA MAYOR A 80000 *****
        public string SinMatricula(string nromatri, out string mensaje)
        {
            return cD_Colegiados.SinMatricula(nromatri, out mensaje);
        }

        //***** LLAMO AL METODO PARA BUSCAR UNA MATRICULA DESPUES DE JURAR *****
        public string AsignarMatricula(string nromatri, out string mensaje)
        {
            return cD_Colegiados.AsignarMatricula(nromatri, out mensaje);
        }

    }
}
