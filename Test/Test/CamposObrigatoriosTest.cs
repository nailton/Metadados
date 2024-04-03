using System.Net;
using System.Text;
using System.Text.Json;
using Metadados.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Test;

public class ContasControllerTests
{
    [Fact]
    public async Task Incluir_NomeVazio_DeveRetornarBadRequest()
    {
        // Arrange
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5077/api");
        var conta = new Conta(new Guid(), "", 0, 0, DateTime.Now, DateTime.Now, 0, 0, 0);

        // Act
        var response = await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta),
                Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    
    [Fact]
    public async Task Incluir_ValorOriginalZero_DeveRetornarBadRequest()
    {
        // Arrange
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5077/api");
        var conta = new Conta(new Guid(), "NETFLIX 4 TELAS", 0, 0, DateTime.Now, DateTime.Now, 0, 0, 0);

        // Act
        var response = await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta),
                Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
      
    // [Fact]
    // public async Task Incluir_DataVencimentoVazia_DeveRetornarBadRequest()
    // {
    //     // Arrange
    //     var httpClient = new HttpClient();
    //     httpClient.BaseAddress = new Uri("http://localhost:5077/api");
    //     var conta = new
    //     {
    //         Nome = "NETFLIX 4 TELAS",
    //         ValorOriginal = 58.90,
    //         ValorCorrigido = 0,
    //         DataVencimento = "",
    //         DataPagamento = DateTime.Now,
    //         DiasAtraso = 0,
    //         Multa = 0,
    //         Juros = 0
    //     };
    //
    //     // Act
    //     var response = await httpClient.PostAsync("api/Contas",
    //         new StringContent(JsonConvert.SerializeObject(conta),
    //             Encoding.UTF8, "application/json"));
    //
    //     // Assert
    //     Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    // }
    //
    
    // [Fact]
    // public async Task Incluir_DataVencimentoVazia_DeveRetornarMensagemApropriada()
    // {
    //     // Arrange
    //     var data = "2000-30-30";
    //     var httpClient = new HttpClient();
    //     httpClient.BaseAddress = new Uri("http://localhost:5077/api");
    //     // var conta = new Conta(new Guid(), "NETFLIX 4 TELAS", (decimal)49.90, 0, DateTime.Now, DateTime.Now, 0, 0, 0);
    //     var conta = new
    //     {
    //         Id = "",
    //         Nome = "NETFLIX 4 TELAS",
    //         ValorOriginal = 58.90,
    //         ValorCorrigido = 0,
    //         // DataVencimento = "",
    //         DataPagamento = DateTime.Now,
    //         DiasAtraso = 0,
    //         Multa = 0,
    //         Juros = 0
    //     };
    //
    //     // var converted = JsonConvert.SerializeObject(conta);
    //     // JArray.Parse(converted).Remove("DataVencimento");
    //     // Act
    //     var response = await httpClient.PostAsync("api/Contas",
    //         new StringContent(JsonSerializer.Serialize(conta),
    //             Encoding.UTF8, "application/json"));
    //
    //     // Assert
    //     Assert.Equal("Data de vencimento da conta é obrigatória.",  response.Content.ReadAsStreamAsync().ToString());
    // }
}