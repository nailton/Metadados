using Metadados.Data;
using Metadados.Models;
using Metadados.Utils;

namespace Metadados.Services;

public class ContaService : IContaService
{
    private readonly AppDbContext _contexto;

    public ContaService(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public void Incluir(Conta conta)
    {
        // Validação dos campos obrigatórios

        if (string.IsNullOrEmpty(conta.Nome))
            throw new ApplicationException("Nome da conta é obrigatório.");
        
        if (conta.ValorOriginal <= 0)
            throw new ApplicationException("Valor original da conta deve ser maior que zero.");
        
        if (string.IsNullOrEmpty(conta.DataVencimento.ToString()))
        {
            throw new ApplicationException("Data de vencimento da conta é obrigatória.");
        }
        
        // Verificação de conta duplicada por data de pagamento

        var contaExistente =
            _contexto.Contas.FirstOrDefault(c => c.Nome == conta.Nome && c.DataPagamento == conta.DataPagamento);
        if (contaExistente != null)
            throw new ApplicationException("Já existe uma conta cadastrada para essa data de pagamento.");

        // Cálculo de multa e juros

        if (DateTime.Now > conta.DataVencimento)
        {
            var diasEmAtraso = (DateTime.Now - conta.DataVencimento).Days;
            var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
            conta.AtualizaValorCorrigido(conta.ValorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros));
            conta.AtualizaMulta(regraMultaJuros.Multa);
            conta.AtualizaJuros(regraMultaJuros.Juros);
            conta.AtualizaDiasAtraso(diasEmAtraso);
        }

        conta.AtualizaDataPagamento(conta.DataPagamento);

        // Persistência da conta

        _contexto.Contas.Add(conta);
        _contexto.SaveChanges();
    }

    public IEnumerable<ContaDto> Listar()
    {
        return _contexto.Contas.Select(c => new ContaDto(
            c.Id, c.Nome,
            c.ValorOriginal,
            c.ValorCorrigido,
            c.DiasAtraso,
            c.DataPagamento)).ToList();
    }
}