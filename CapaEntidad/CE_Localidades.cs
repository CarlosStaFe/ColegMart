namespace CapaEntidad
{
    public class CE_Localidades
    {
        public int id_Local { get; set; }
        public int fk_Deptos { get; set; }
        public int fk_Prov { get; set; }
        public int CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string UserRegistro { get; set; }
    }
}
