using System;

namespace CapaEntidad
{
    public class CE_Adebitar
    {
        public int id_Debitar { get; set; }
        public int fk_idColeg { get; set; }
        public int fk_idDebito { get; set; }
        public bool Activo { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Matricula { get; set; }
        public string Nombres { get; set; }
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }
    }
}
