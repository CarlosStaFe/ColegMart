namespace CapaEntidad
{
    public class CE_Permisos
    {
        public int id_Permiso { get; set; }
        public CE_Usuarios OUsuario { get; set; }
        public CE_Botones OBoton { get; set; }
        public string UserRegistro { get; set; }
        public string FechaRegistro { get; set; }
    }
}
