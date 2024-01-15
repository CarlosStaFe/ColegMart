using System;

namespace CapaEntidad
{
    public class CE_SaldosPagos
    {
        public int id_SP { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public string Periodo { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Saldo { get; set; }

    }
}
