namespace Metadados.Models;

public record ContaDto(Guid Id, string Nome, decimal ValorOriginal, decimal ValorCorrigido, int DiasAtraso, DateTime DataPagamento);