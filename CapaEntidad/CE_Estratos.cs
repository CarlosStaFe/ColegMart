using System;

namespace CapaEntidad
{
    public class CE_Estratos
    {
        public int id_Estra { get; set; }
        public int NroBanco { get; set; }
        public DateTime Fecha { get; set; }
        public string Causal { get; set; }
        public string Referencia { get; set; }
        public string Concepto { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaConci { get; set; }
        public int Titular { get; set; }
        public int NroCic { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
