
namespace Ejercicio1.Models.Exportadores;

public class ExportadorFactory
{
    // 1 CSV ; 2 JSON ; 3 CAMPO FIJO ; 4 XML
    public IExportador GetInstance(int tipo)
    {
        IExportador exportador = null;
        if (tipo == 1)
        {
            return new CSVExportador();
        }
        else if (tipo == 2)
        {
            return new XMLExportador();
        }
        else if (tipo == 3)
        {
            return new CampoFijoExportador();
        }
        else if (tipo == 4)
        {
            return new XMLExportador();
        }
        return null;
    }
}
