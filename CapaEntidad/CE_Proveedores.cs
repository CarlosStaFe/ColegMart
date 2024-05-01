using System;

namespace CapaEntidad
{
    public class CE_Proveedores
    {
        public int id_Prov { get; set; }
        public int Numero { get; set; }
        public string RazonSocial { get; set; }
        public string Titular { get; set; }
        public string Domicilio { get; set; }
        public int idCodPos { get; set; }
        public int idLocal { get; set; }
        public int idDepto { get; set; }
        public int idProv { get; set; }
        public string TipoIva { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string IngBrutos { get; set; }
        public string Email { get; set; }
        public double Saldo { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
