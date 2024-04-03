using Metadados.Models;
using Microsoft.AspNetCore.Mvc;

namespace Metadados.Services;

public interface IContaService
{
    void Incluir(Conta conta);
     IEnumerable<ContaDto> Listar();
}