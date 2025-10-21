namespace Ejercicio1.Models.Exportadores
{
    public class CSVExportador : IExportable
    {
        public string Exportar(IExportador exportador)
        {
            throw new NotImplementedException();
        }

        public bool Importar(string data, Multa multa)
        {
            string[] campos = data.Split(';');
            string patente = campos[0];
            DateOnly vencimiento = DateOnly.ParseExact(campos[1], "dd/MM/yy");
            double importe = Convert.ToDouble(campos[2]);

            multa.Patente = patente;
            multa.Importe = importe;
            multa.Vencimiento = vencimiento;

        }
    }
}
