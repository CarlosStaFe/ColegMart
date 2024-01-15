using System;
using System.Diagnostics.CodeAnalysis;

namespace CapaPresentacion.Utiles
{
    public static class PasarLetras
    {
        public static string NumeroALetras(this decimal numero)
        {
            string dec;

            var entero = Convert.ToInt64(Math.Truncate(numero));
            var decimales = Convert.ToInt32(Math.Round((numero - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " PESOS CON " + decimales.ToString() + "/100";
                //dec = $" PESOS {decimales:0,0} /100";
            }
            //Código agregado por mí
            else
            {
                dec = " PESOS CON " + decimales.ToString() + "/100";
                //dec = $" PESOS {decimales:0,0} /100";
            }
            var res = NumeroALetras(Convert.ToDouble(entero)) + dec;
            return res;
        }
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        private static string NumeroALetras(double value)
        {
            string letras; value = Math.Truncate(value);
            if (value == 0) letras = "CERO";
            else if (value == 1) letras = "UNO";
            else if (value == 2) letras = "DOS";
            else if (value == 3) letras = "TRES";
            else if (value == 4) letras = "CUATRO";
            else if (value == 5) letras = "CINCO";
            else if (value == 6) letras = "SEIS";
            else if (value == 7) letras = "SIETE";
            else if (value == 8) letras = "OCHO";
            else if (value == 9) letras = "NUEVE";
            else if (value == 10) letras = "DIEZ";
            else if (value == 11) letras = "ONCE";
            else if (value == 12) letras = "DOCE";
            else if (value == 13) letras = "TRECE";
            else if (value == 14) letras = "CATORCE";
            else if (value == 15) letras = "QUINCE";
            else if (value < 20) letras = "DIECI" + NumeroALetras(value - 10);
            else if (value == 20) letras = "VEINTE";
            else if (value < 30) letras = "VEINTI" + NumeroALetras(value - 20);
            else if (value == 30) letras = "TREINTA";
            else if (value == 40) letras = "CUARENTA";
            else if (value == 50) letras = "CINCUENTA";
            else if (value == 60) letras = "SESENTA";
            else if (value == 70) letras = "SETENTA";
            else if (value == 80) letras = "OCHENTA";
            else if (value == 90) letras = "NOVENTA";
            else if (value < 100) letras = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) letras = "CIEN";
            else if (value < 200) letras = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) letras = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) letras = "QUINIENTOS";
            else if (value == 700) letras = "SETECIENTOS";
            else if (value == 900) letras = "NOVECIENTOS";
            else if (value < 1000) letras = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) letras = "MIL";
            else if (value < 2000) letras = "MIL " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                letras = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                {
                    letras = letras + " " + NumeroALetras(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                letras = "UN MILLON";
            }
            else if (value < 2000000)
            {
                letras = "UN MILLON " + NumeroALetras(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                letras = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    letras = letras + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) letras = "UN BILLON";
            else if (value < 2000000000000) letras = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                letras = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    letras = letras + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return letras;
        }
    }
}
