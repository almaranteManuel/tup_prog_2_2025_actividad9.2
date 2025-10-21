using Ejercicio1.Models.Exportadores;

namespace Ejercicio1.Models;

[Serializable]
public class Multa:IComparable, IExportable
{
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

    public int CompareTo(object otherObject)
    {
        Multa other = otherObject as Multa;
        if (other != null)
            return this.Patente.CompareTo(other.Patente);
        return -1;
    }

    public string Exportar(IExportador exportador)
    {
        return exportador.Exportar(this);
    }
    public bool Importar(string data, IExportador exportador)
    {
        return exportador.Importar(data, this);
    }
    override public string ToString()
    {
        return $"{Patente} - {Vencimiento} - {Importe}";
    }

}
