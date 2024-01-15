using System;

namespace CapaEntidad
{
    public class CE_PadronColeg
    {
        public int id_Coleg { get; set; }
        public int Contador { get; set; }
        public int Matricula { get; set; }
        public string ApelNombres { get; set; }
        public string ApelMaterno { get; set; }
        public DateTime FechaNacim { get; set; }
        public string LugarNacim { get; set; }
        public string Nacionalidad { get; set; }
        public string TipoDoc { get; set; }
        public int NumeroDoc { get; set; }
        public string Cuit { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime Juramento { get; set; }
        public string Tomo { get; set; }
        public string Folio { get; set; }
        public string Categoria { get; set; }
        public string CodigoIapos { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public DateTime FecEstado { get; set; }
        public string DomParti { get; set; }
        public string LocalidadParti { get; set; }
        public int idCodPosParti { get; set; }
        public int idLocalParti { get; set; }
        public int idDeptoParti { get; set; }
        public int idProvParti { get; set; }
        public string FijoParti { get; set; }
        public string CeluParti { get; set; }
        public string DomLabor { get; set; }
        public string LocalidadLabor { get; set; }
        public int idCodPosLabor { get; set; }
        public int idLocalLabor { get; set; }
        public int idDeptoLabor { get; set; }
        public int idProvLabor { get; set; }
        public string FijoLabor { get; set; }
        public string CeluLabor { get; set; }
        public DateTime FecVenceFianza { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public byte[] Foto { get; set; }
    }
}
