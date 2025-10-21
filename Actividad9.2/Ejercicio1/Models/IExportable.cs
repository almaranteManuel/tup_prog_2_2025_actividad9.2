using Ejercicio1.Models.Exportadores;

namespace Ejercicio1.Models;

public interface IExportable
{
    bool Importar(string data, IExportador exportador);

    string Exportar(IExportador exportador);
}
