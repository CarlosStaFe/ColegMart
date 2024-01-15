using System;

namespace CapaEntidad
{
    public class CE_DeudaLiqui
    {
        public int id_Deuda { get; set; }
        public string Prefijo { get; set; }
        public string Subfijo { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Comprobante { get; set; }
        public int Item { get; set; }
        public string Detalle { get; set; }
        public string Periodo { get; set; }
        public decimal Importe { get; set; }
        public decimal Pagado { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Saldo { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
