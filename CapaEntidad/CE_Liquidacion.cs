using System;

namespace CapaEntidad
{
    public class CE_Liquidacion
    {
        public int id_Liq { get; set; }
        public int Matricula { get; set; }
        public string ApelNombres { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Prefijo { get; set; }
        public string Subfijo { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Periodo { get; set; }
        public decimal Total { get; set; }
        public string CodigoBarra { get; set; }
        public string NumeroPago { get; set; }
        public string Email { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
