using Ejercicio1.Models.Exportadores;

namespace Ejercicio1.Models;

public class Multa:IComparable, IExportable
{

    public string Exportar(IExportador exportador)
    {
        return exportador.Exportar(this);
    }
    public bool Importar(string data, IExportador exportador)
    {
        return exportador.Importar(data, this);
    }

    public string Patente { get; set; }
    public DateOnly Vencimiento { get; set; }
    public double Importe { get; set; }

    public Multa() { }

    public Multa(string patente, DateOnly vencimiento, double importe)
    {
        Patente = patente;
        Vencimiento = vencimiento;
        Importe = importe;
    }

    override public string ToString()
    {
        return $"{Patente} - {Vencimiento} - {Importe}";
    }

    public int CompareTo(object obj)
    {
        Multa? other = obj as Multa;
        if (other != null)
        {
            return Patente.CompareTo(other.Patente);
        }
        return -1;
    }
}
