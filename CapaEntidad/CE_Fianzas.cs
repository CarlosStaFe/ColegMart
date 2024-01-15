using System;

namespace CapaEntidad
{
    public class CE_Fianzas
    {
        public int id_Fza { get; set; }
        public int Matricula { get; set; }
        public string ApelNomMatri { get; set; }
        public string TelMatri { get; set; }
        public DateTime FecPagoFza { get; set; }
        public string UserFecPagoFza { get; set; }
        public DateTime FecFirmaMat { get; set; }
        public string UserFirmaMat { get; set; }
        public DateTime FecFirmaFiador { get; set; }
        public string UserFirmaFiador { get; set; }
        public DateTime FecVtoFianza { get; set; }
        public string NroDocFiador { get; set; }
        public string ApelNomFiador { get; set; }
        public string CalleFiador { get; set; }
        public string TelFiador { get; set; }
        public string EstadoFza { get; set; }
        public string Obs { get; set; }

    }
}
