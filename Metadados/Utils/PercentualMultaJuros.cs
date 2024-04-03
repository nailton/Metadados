namespace Metadados.Utils;

public class PercentualMultaJuros
{
    public static RegraMultaJuros ObterRegra(int diasEmAtraso)
    {
        if (diasEmAtraso <= 0)
        {
            return new RegraMultaJuros
            {
                Multa = 0,
                Juros = 0
            };
        }

        if (diasEmAtraso <= 3)
        {
            return new RegraMultaJuros
            {
                Multa = (decimal)0.02,
                Juros = (decimal)0.001
            };
        }
        else if (diasEmAtraso <= 10)
        {
            return new RegraMultaJuros
            {
                Multa = (decimal)0.03,
                Juros = (decimal)0.002
            };
        }
        else
        {
            return new RegraMultaJuros
            {
                Multa = (decimal)0.05,
                Juros = (decimal)0.003
            };
        }
    }
}

public class RegraMultaJuros
{
    public decimal Multa { get; set; }
    public decimal Juros { get; set; }
}