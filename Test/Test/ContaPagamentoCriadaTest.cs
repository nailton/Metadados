using System.Net;
using System.Text;
using Metadados.Models;
using Metadados.Utils;
using Newtonsoft.Json;

namespace Test;

public class ContaPagamentoCriadaTest
{
    // [Fact]
    // public async Task Conta_pagamento_criada_banco()
    // {
    //     // Arrange
    //     using (var contexto = new AppDbContext(_context))
    //     {
    //         var httpClient = new HttpClient();
    //         httpClient.BaseAddress = new Uri("http://localhost:5077/api");
    //         var nomeConta = RandomString.GetRandomString(10);
    //         var conta = new Conta(new Guid(), "CONTA - " + nomeConta, 199, 0, DateTime.Now, DateTime.Now, 0, 0, 0);
    //
    //         // Act
    //         var response = await httpClient.PostAsync("api/Contas",
    //             new StringContent(JsonConvert.SerializeObject(conta),
    //                 Encoding.UTF8, "application/json"));
    //
    //         // Assert
    //         var contaBd = await contexto.Contas.FindAsync(conta.Id);
    //
    //         Assert.NotNull(contaBd); // Verifica se a conta foi criada no banco
    //         Assert.Equal(conta.Nome, contaBd.Nome); // Verifica se os dados da conta estão corretos
    //     }
    // }

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