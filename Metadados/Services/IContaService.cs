using Metadados.Models;

namespace Metadados.Services;

public interface IContaService
{
    void Incluir(Conta conta);
     IEnumerable<ContaDto> Listar();
}