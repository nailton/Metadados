using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models;

public sealed class Conta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Required(ErrorMessage = "Nome da conta é obrigatório.")]
    [MaxLength(100)]
    public string Nome { get; private set; }

    [Required(ErrorMessage = "Valor original é obrigatório")]
    public decimal ValorOriginal { get; private set; }

    [Required] public decimal ValorCorrigido { get; private set; }

    [Required]
    [Range(typeof(DateTime), "1970-01-01", "2100-12-31", ErrorMessage = "Data de vencimento deve estar entre 01/01/1970 e 31/12/2100")]
    public DateTime DataVencimento { get; private set; }

    [Required(ErrorMessage = "Data de pagamento é obrigatório")]
    public DateTime DataPagamento { get; private set; }

    [Required] public int DiasAtraso { get; private set; }

    [Required] public decimal Multa { get; private set; }

    [Required] public decimal Juros { get; private set; }


    public Conta(Guid id, string nome, decimal valorOriginal, decimal valorCorrigido, DateTime dataVencimento,
        DateTime dataPagamento, int diasAtraso, decimal multa, decimal juros)
    {
        Id = id;
        Nome = nome;
        ValorOriginal = valorOriginal;
        ValorCorrigido = valorCorrigido;
        DataVencimento = dataVencimento;
        DataPagamento = dataPagamento;
        DiasAtraso = diasAtraso;
        Multa = multa;
        Juros = juros;
    }

    public void AtualizaValorCorrigido(decimal valor)
    {
        ValorCorrigido = valor;
    }

    public void AtualizaDiasAtraso(int dias)
    {
        DiasAtraso = dias;
    }

    public void AtualizaDataPagamento(DateTime data)
    {
        DataPagamento = data;
    }

    public void AtualizaMulta(decimal multa)
    {
        Multa = multa;
    }

    public void AtualizaJuros(decimal juros)
    {
        Juros = juros;
    }
}