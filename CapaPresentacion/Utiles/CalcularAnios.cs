using System;

namespace CapaPresentacion.Utiles
{
    public static class CalcularAnios
    {
        public static int TraerAnios(DateTime fecha)
        {
            var anios = DateTime.Now - fecha;
            return (int)(anios.TotalDays / 365.255);
        }
    }
}
