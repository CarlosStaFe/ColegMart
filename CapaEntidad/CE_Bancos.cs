using System;

namespace CapaEntidad
{
    public class CE_Bancos
    {
        public int id_Bco { get; set; }
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
