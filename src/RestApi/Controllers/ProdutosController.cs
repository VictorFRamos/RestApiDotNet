using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Data.Entities;

namespace RestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly VendasContext _context;

    public ProdutosController(VendasContext context)
    {
        _context = context;
    }

    // GET: api/produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    // POST: api/produtos
    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
    }

    // PUT: api/produtos/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest("ID do produto não corresponde.");
        }

        _context.Entry(produto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ProdutoExists(id))
            {
                return NotFound("Produto não encontrado.");
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // Retorna 204 No Content em caso de sucesso
    }

    // DELETE: api/produtos/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204 No Content em caso de sucesso
    }

    private async Task<bool> ProdutoExists(int id)
    {
        return await _context.Produtos.AnyAsync(e => e.Id == id);
    }
}