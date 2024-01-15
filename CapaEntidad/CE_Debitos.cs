using System;

namespace CapaEntidad
{
    public class CE_Debitos
    {
        public int id_Debito { get; set; }
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }
        public int Kilos { get; set; }
        public string Categoria { get; set; }
        public string TipoDebito { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public bool Activo { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
