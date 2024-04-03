using System.Net;
using System.Text;
using Metadados.Models;
using Metadados.Services;
using Metadados.Utils;
using Newtonsoft.Json;

namespace Test;

public class ContaDuplicadaTest
{
    
    [Fact]
    public async Task Incluir_Conta_Duplicada_BadRequest()
    {
        // Arrange
        var nomeConta = "CONTA - " + RandomString.GetRandomString(10);
        var dataPagamento = DateTime.Now;
        
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5077/api");
        var conta1 = new Conta(new Guid(), nomeConta, 50, 0, DateTime.Now, dataPagamento, 0, 0, 0);
        var conta2 = new Conta(new Guid(), nomeConta, 50, 0, DateTime.Now, dataPagamento, 0, 0, 0);

        // Act
        //Inserir 1x
        await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta1),
                Encoding.UTF8, "application/json"));
        
        //Inserir 2x
        var response = await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta2),
                Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
        
    [Fact]
    public async Task Incluir_Conta_Duplicada_Mensagem()
    {
        // Arrange
        var nomeConta = "CONTA - " + RandomString.GetRandomString(10);
        var dataPagamento = DateTime.Now;
        
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5077/api");
        var conta1 = new Conta(new Guid(), nomeConta, 50, 0, DateTime.Now, dataPagamento, 0, 0, 0);
        var conta2 = new Conta(new Guid(), nomeConta, 50, 0, DateTime.Now, dataPagamento, 0, 0, 0);

        // Act
        //Inserir 1x
        await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta1),
                Encoding.UTF8, "application/json"));
        
        //Inserir 2x
        var response = await httpClient.PostAsync("api/Contas",
            new StringContent(JsonConvert.SerializeObject(conta2),
                Encoding.UTF8, "application/json"));

        var responseContent = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

        var expectedMessage = "Já existe uma conta cadastrada para essa data de pagamento.";
        var actualMessage = responseObject["message"]?.ToString();
        
        // Assert
        Assert.Equal(expectedMessage, actualMessage);
    }
}