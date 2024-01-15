using System;

namespace CapaPresentacion.Utiles
{
    public class FormatoMoneda
    {
        public string Proceso(string importe)
        {
            if (importe == String.Empty)
            {
                decimal valor;
                valor = Convert.ToDecimal("0.00");
                importe = valor.ToString("#####0.00");
            }
            else
            {
                decimal valor;
                valor = Convert.ToDecimal(importe);
                importe = valor.ToString("#####0.00");
            }
            return importe;
        }
    }
}
