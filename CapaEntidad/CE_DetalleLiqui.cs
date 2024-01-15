using System;

namespace CapaEntidad
{
    public class CE_DetalleLiqui
    {
        public int id_Det { get; set; }
        public string Prefijo { get; set; }
        public string Subfijo { get; set; }
        public int Item { get; set; }
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
