using System;

namespace CapaEntidad
{
    public class CE_Ventas
    {
        public int id_Venta { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Prefijo { get; set; }
        public string Subfijo { get; set; }
        public int Item { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
