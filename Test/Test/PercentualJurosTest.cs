using Metadados.Utils;

namespace Test;

public class PercentualJurosTest
{
    [Fact]
    public void Juros_igual_a_zero_a_vencer()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now.AddDays(2) - DateTime.Now.AddDays(1)).Days;

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);

        //Assert
        Assert.Equal(0, regraMultaJuros.Multa, 2);
    }

    [Fact]
    public void Juros_igual_a_zero()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now).Days;

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);

        //Assert
        Assert.Equal(0, regraMultaJuros.Juros, 2);
    }

    [Fact]
    public void Juros_igual_a_tres_dias()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-3)).Days;

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);

        //Assert
        Assert.Equal(0.001m, regraMultaJuros.Juros, 2);
    }

    [Fact]
    public void Juros_superior_a_tres_dias()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-6)).Days;

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);

        //Assert
        Assert.Equal(0.002m, regraMultaJuros.Juros, 2);
    }

    [Fact]
    public void Juros_superior_a_dez_dias()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-12)).Days;

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);

        //Assert
        Assert.Equal(0.002m, regraMultaJuros.Juros, 2);
    }
}