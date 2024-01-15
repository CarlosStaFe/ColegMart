namespace CapaPresentacion.Utiles
{
    public class ProcesarFecha
    {
        public string Proceso(string fechajob)
        {
            int pos1 = fechajob.IndexOf("/");
            int pos2 = fechajob.IndexOf('/',pos1 + 1);

            string dd = fechajob.Substring(0,pos1);
            dd = new PonerCeros().Proceso(dd, 2);

            string mm = fechajob.Substring(pos1 + 1,pos2 - (pos1 + 1));
            mm = new PonerCeros().Proceso(mm, 2);

            string yyyy = fechajob.Substring(pos2 + 1, 4);

            fechajob = dd + "/" + mm + "/" + yyyy;

            return fechajob;
        }
    }
}
