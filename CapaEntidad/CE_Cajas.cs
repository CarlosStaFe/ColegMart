using System;

namespace CapaEntidad
{
    public class CE_Cajas
    {
        public int id_Caja { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public  string Prefijo { get; set; }
        public string Subfijo { get; set; }
        public int Item { get; set; }
        public  int Numero { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public string Periodo { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Transferencia { get; set; }
        public decimal Tarjeta { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCierre { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
