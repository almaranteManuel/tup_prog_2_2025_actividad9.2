using System.Globalization;
using System.Text.RegularExpressions;

namespace Ejercicio1.Models.Exportadores;
public class XMLExportador : IExportador
{
    public string Exportar(Multa m)
    {
        return $"<Multa><Patente>{m.Patente}</Patente><Vencimiento>{m.Vencimiento:dd/MM/yyyy}</Vencimiento><Importar>{m.Importar:f2}</Importar></Multa>";
    }

    public bool Importar(string data, Multa m)
    {
        Match match = Regex.Match(data, @"<Patente>([a-z]{3}\d{3})</Patente><Vencimiento>(\d{2}/\d{2}/\d{4})</Vencimiento><Importe>(\d+,\d*)</Importe>", RegexOptions.IgnoreCase);

        if (match.Success)
        {
            m.Patente = match.Groups[1].Value;
            m.Vencimiento = DateOnly.ParseExact(match.Groups[2].Value, "dd/MM/yyyy");
            m.Importe = Convert.ToDouble(match.Groups[3].Value, CultureInfo.InvariantCulture);
            return true;
        }
        return false;
    }
}
