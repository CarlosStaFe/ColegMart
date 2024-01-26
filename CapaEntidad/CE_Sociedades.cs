using System;

namespace CapaEntidad
{
    public class CE_Sociedades
    {
        public int id_Soc { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string TipoDoc { get; set; }
        public int Cuit { get; set; }
        public string Domicilio { get; set; }
        public int idCodPostal { get; set; }
        public int idLocal { get; set; }
        public int idDepto { get; set; }
        public int idProv { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEstado { get; set; }
        public int Inscripcion { get; set; }
        public int Semestral { get; set; }
        public int Martillero1 { get; set; }
        public int Martillero2 { get; set; }
        public int Martillero3 { get; set; }
        public int Martillero4 { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
