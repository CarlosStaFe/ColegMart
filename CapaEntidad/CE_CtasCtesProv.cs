using System;

namespace CapaEntidad
{
    public class CE_CtasCtesProv
    {
        public int id_CtaCte { get; set; }
        public int NroProv { get; set; }
        public int idCpra { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Prefijo { get; set; }
        public string Subfijo { get; set; }
        public int Item { get; set; }
        public string Detalle { get; set; }
        public decimal Haber { get; set; }
        public decimal Pagado { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Saldo { get; set; }
        public string Estado { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
