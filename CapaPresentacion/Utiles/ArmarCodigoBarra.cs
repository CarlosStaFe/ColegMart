using System;

namespace CapaPresentacion.Utiles
{
    public class ArmarCodigoBarra
    {
        public object ArmaCodigoBarra(string matricula, string MMperiodo, string YYperiodo, decimal importe, string dd, string mm, string yy)
        {
            object CodigoArmado;
            string CodigoBarra, DataToPrint, StrImporte, DigitoVerifica,  cto, vencimiento, periodo, CodigoAux;
            char StartCode, StopCode;
            string conceros;
            int j, factor, suma, numero, StringLength, CurrentCharNum;
            double calculo;

            CodigoArmado = "";
            CodigoBarra = "";
            CodigoAux = "";
            conceros = "";
            DataToPrint = "";

            conceros = new PonerCeros().Proceso(matricula, 5);
            matricula = conceros;

            cto = "03";

            conceros = new PonerCeros().Proceso(MMperiodo, 2);
            MMperiodo = conceros;

            periodo = YYperiodo + MMperiodo;

            vencimiento = dd + mm + yy;

            StrImporte = Convert.ToString(importe * 100);

            int pos1 = StrImporte.IndexOf(",");
            StrImporte = StrImporte.Substring(0, pos1);
            conceros = new PonerCeros().Proceso(StrImporte, 10);
            StrImporte = conceros;

            // ***** Calculo digito verificador
            CodigoBarra = "00004241" + "0000000" + matricula + cto + periodo + "0" + vencimiento + StrImporte;
            factor = 1;
            suma = 0;

            for (j = 0; j < CodigoBarra.Length; j++)
            {
                numero = Convert.ToInt32(CodigoBarra.Substring( j, 1));
                suma = suma + numero * factor;
                if (factor == 9)
                    factor = 3;
                else
                    factor = factor + 2;
            }

            calculo = suma / 2;
            suma = Convert.ToInt32(calculo) % 10;
            DigitoVerifica = Convert.ToString(suma);
            CodigoBarra = "00004241" + "0000000" + matricula + cto + periodo + "0" + vencimiento + StrImporte + DigitoVerifica;

            // ***** Assign start and stop codes
            StartCode = (char)40;
            StopCode = (char)41;
            StringLength = CodigoBarra.Length;

            for (j = 0; j < StringLength; j += 2)
            {
                // ***** Get the value of each number pair
                CurrentCharNum = Convert.ToInt32(CodigoBarra.Substring(j, 2));
                // ***** Get the ASCII value of CurrentChar
                if (CurrentCharNum <= 49)
                    DataToPrint = DataToPrint + (char)(CurrentCharNum + 48 );

                if (CurrentCharNum >= 50)
                    DataToPrint = DataToPrint + (char)(CurrentCharNum + 142);
            }

            CodigoAux = CodigoBarra;
            CodigoBarra = StartCode + CodigoBarra + StopCode;
            // ***** Get Printable String
            CodigoArmado = StartCode + DataToPrint + StopCode + "*" + CodigoAux;

            return CodigoArmado;
        }
    }
}
