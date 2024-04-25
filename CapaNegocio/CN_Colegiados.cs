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

            if (obj.Sexo == "")
            {
                mensaje += "Debe ingresar el sexo. * ";
            }

            if (obj.EstadoCivil == "")
            {
                mensaje += "Debe ingresar estado civil. * ";
            }

            if (obj.Categoria == "")
            {
                mensaje += "Debe ingresar la categoría. * ";
            }

            if (obj.Email == "")
            {
                mensaje += "Debe ingresar un email. * ";
            }

            if (obj.Estado == "")
            {
                mensaje += "Debe ingresar un estado. * ";
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

            if (obj.Sexo == "")
            {
                mensaje += "Debe ingresar el sexo. * ";
            }

            if (obj.EstadoCivil == "")
            {
                mensaje += "Debe ingresar estado civil. * ";
            }

            if (obj.Tomo == "")
            {
                if (obj.Matricula < 50000)
                {
                    mensaje += "Debe ingresar el tomo. * ";
                }
            }

            if (obj.Folio == "")
            {
                if (obj.Matricula < 50000)
                {
                    mensaje += "Debe ingresar el folio. * ";
                }
            }

            if (obj.Categoria == "")
            {
                mensaje += "Debe ingresar la categoría. * ";
            }

            if (obj.Email == "")
            {
                mensaje += "Debe ingresar un email. * ";
            }

            if (obj.Estado == "")
            {
                mensaje += "Debe ingresar un estado. * ";
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

        //***** LLAMO AL METODO PARA LISTAR UN COLEGIADO BUSCADO *****
        public List<CE_Colegiados> ListaBuscado(string matri, out string mensaje)
        {
            return cD_Colegiados.ListaBuscado(matri, out mensaje);
        }

        //***** ACTUALIZO EL ESTADO DE LOS COLEGIADOS *****
        public bool ActualizarEstado(int matri, string estado)
        {
            return cD_Colegiados.ActualizarEstado(matri, estado);
        }

        //***** LLAMO AL METODO PARA LISTAR EL PADRON DE LOS COLEGIADOS *****
        public List<CE_Colegiados> ListaPadron(string comando)
        {
            return cD_Colegiados.ListaPadron(comando);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS COLEGIADOS A LIQUIDAR *****
        public List<CE_Colegiados> LiquidaColeg(string desde, string hasta)
        {
            return cD_Colegiados.LiquidaColeg(desde, hasta);
        }

        //***** ACTUALIZO LA FIANZA DE LOS COLEGIADOS *****
        public bool ActualizarFianza(string matri, string estado, string fecha)
        {
            return cD_Colegiados.ActualizarFianza(matri, estado, fecha);
        }

    }
}
