
namespace Ejercicio1.Models.Exportadores;

public class ExportadorFactory
{
    public IExportador GetInstance(int tipo)
    {
        IExportador exportador = null;
        if (tipo == 1)
        {
            exportador = new CSVExportador();
        }
        else if (tipo == 2)
        {
             
        }
    }
}
