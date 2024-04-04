using System.Net;
using System.Text;
using Metadados.Models;
using Newtonsoft.Json;
using Test.Utils;

namespace Test;

public class ContaPagamentoCriadaTest
{
    [Fact]
    public async Task Conta_pagamento_criada_status_code_Created()
    {
        // Arrange
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5077/api");
        var nomeConta = RandomString.GetRandomString(10);
        var conta = new Conta(new Guid(), "CONTA - " + nomeConta, 199, 0, DateTime.Now, DateTime.Now, 0, 0, 0);

        // Act
        var response = await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta),
                Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Conta_pagamento_criada_uri_NotNull()
    {
        // Arrange
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5077/api");
        var nomeConta = RandomString.GetRandomString(10);
        var conta = new Conta(new Guid(), "CONTA - " + nomeConta, 199, 0, DateTime.Now, DateTime.Now, 0, 0, 0);

        // Act
        var response = await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta),
                Encoding.UTF8, "application/json"));

        // Extrair URI da conta do cabeçalho Location
        var locationHeader = response.Headers.GetValues("Location").FirstOrDefault();
        object? uri = "";
        if (locationHeader != null)
        {
            uri = new Uri(locationHeader);
        }

        // Assert
        Assert.NotNull(uri);
    }
}