using Metadados.Utils;

namespace Test;

public class CalculaValorCorrigidoMultaJurosTest
{
    [Fact]
    public void Multa_juros_nao_devido_vencimento_mesmo_pagamento()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now).Days;
        var valorOriginal = (decimal)10.0; 

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
        var total = valorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros);
        

        //Assert
        Assert.Equal(10, total, 2);
    }
    
    [Fact]
    public void Multa_juros_nao_devido_vencimento_menor_que_pagamento()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(2)).Days;
        var valorOriginal = (decimal)10.0; 

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
        var total = valorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros);
        

        //Assert
        Assert.Equal(10, total, 2);
    }
    
    [Fact]
    public void Valor_Corrigido_ate_tres_dias_atraso()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-3)).Days;
        var valorOriginal = (decimal)10.0; 

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
        var total = valorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros);
        

        //Assert
        Assert.Equal((decimal)10.21, total, 2);
    }
       
    [Fact]
    public void Valor_Corrigido_tres_dias_atraso()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-4)).Days;
        var valorOriginal = (decimal)10.0; 

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
        var total = valorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros);
        

        //Assert
        Assert.Equal((decimal)10.21, total, 2);
    }
    
    [Fact]
    public void Valor_Corrigido_superior_a_tres_dias_atraso()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-6)).Days;
        var valorOriginal = (decimal)10.0; 

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
        var total = valorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros);
        

        //Assert
        Assert.Equal((decimal)10.32, total, 2);
    }
    
    [Fact]
    public void Valor_Corrigido_superior_a_dez_dias_atraso()
    {
        //Arrange
        var diasEmAtraso = (DateTime.Now - DateTime.Now.AddDays(-12)).Days;
        var valorOriginal = (decimal)10.0; 

        //Act
        var regraMultaJuros = PercentualMultaJuros.ObterRegra(diasEmAtraso);
        var total = valorOriginal * (1 + regraMultaJuros.Multa + regraMultaJuros.Juros);
        

        //Assert
        Assert.Equal((decimal)10.53, total, 2);
    }
}