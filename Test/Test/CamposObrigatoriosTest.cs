using System.Net;
using System.Text;
using Metadados.Models;
using Newtonsoft.Json;

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
}