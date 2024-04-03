namespace Metadados.Utils;

public class PercentualMultaJuros
{
    public static RegraMultaJuros ObterRegra(int diasEmAtraso)
    {
        return diasEmAtraso switch
        {
            _ when diasEmAtraso <= 0 => new RegraMultaJuros
            {
                Multa = 0m,
                Juros = 0m
            },
            _ when diasEmAtraso <= 3 => new RegraMultaJuros
            {
                Multa = 0.02m,
                Juros = 0.001m
            },
            _ when diasEmAtraso <= 10 => new RegraMultaJuros
            {
                Multa = 0.03m,
                Juros = 0.002m
            },
            _ => new RegraMultaJuros
            {
                Multa = 0.05m,
                Juros = 0.003m
            }
        };
    }
}

public class RegraMultaJuros
{
    public decimal Multa { get; set; }
    public decimal Juros { get; set; }
}