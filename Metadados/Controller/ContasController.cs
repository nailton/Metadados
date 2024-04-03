using Metadados.Data;
using Metadados.Exceptions;
using Metadados.Models;
using Metadados.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controller;

[Route("api/[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
    private readonly IContaService _contaService;

    public ContasController(IContaService contaService)
    {
        _contaService = contaService;
    }

    // GET: api/Contas
    [HttpGet]
    public IEnumerable<ContaDto> GetContas()
    {
        return _contaService.Listar().ToList();
    }

    // POST: api/Contas
    [HttpPost]
    public async Task<ActionResult<Conta>> PostConta(Conta conta)
    {
        try
        {
             _contaService.Incluir(conta);

            return CreatedAtAction(nameof(PostConta), new { id = conta.Id }, conta);
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorDetails(400, ex.Message));
        }
    }

    // private bool ContaExists(Guid id)
    // {
    //     return _contaService.C.Any(e => e.Id == id);
    // }
}