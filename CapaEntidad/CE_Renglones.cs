namespace CapaEntidad
{
    public class CE_Renglones
    {
        public int id_Renglon { get; set; }
        public int Matricula { get; set; }
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Pagado { get; set; }
        public decimal Saldo { get; set; }
    }
}
