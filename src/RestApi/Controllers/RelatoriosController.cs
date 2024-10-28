using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Data.Entities;
using RestApi.Models;

namespace RestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatoriosController : Controller
{
    private readonly VendasContext _context;

        public RelatoriosController(VendasContext context)
        {
            _context = context;
        }

        // GET: api/relatorios/vendas/por-idade
        [HttpGet("vendas/por-idade")]
        public async Task<ActionResult<IEnumerable<VendaPorIdade>>> GetVendasPorIdade()
        {
            var vendas = await _context.Vendas
                .GroupBy(v => v.IdadeCliente)
                .Select(g => new VendaPorIdade
                {
                    Idade = g.Key,
                    TotalVendas = g.Sum(v => v.ValorTotal)
                })
                .ToListAsync();

            return Ok(vendas);
        }

        // GET: api/relatorios/vendas/por-rede-social
        [HttpGet("vendas/por-rede-social")]
        public async Task<ActionResult<IEnumerable<VendaPorRedeSocial>>> GetVendasPorRedeSocial()
        {
            var vendas = await _context.Vendas
                .GroupBy(v => v.RedeSocial)
                .Select(g => new VendaPorRedeSocial
                {
                    RedeSocial = g.Key,
                    TotalVendas = g.Sum(v => v.ValorTotal)
                })
                .ToListAsync();

            return Ok(vendas);
        }

        // GET: api/relatorios/vendas/por-pais
        [HttpGet("vendas/por-pais")]
        public async Task<ActionResult<IEnumerable<VendaPorPais>>> GetVendasPorPais()
        {
            var vendas = await _context.Vendas
                .GroupBy(v => v.PaisCliente)
                .Select(g => new VendaPorPais
                {
                    Pais = g.Key,
                    TotalVendas = g.Sum(v => v.ValorTotal)
                })
                .ToListAsync();

            return Ok(vendas);
        }

        // GET: api/relatorios/ordens
        [HttpGet("ordens")]
        public async Task<ActionResult<IEnumerable<OrdemVenda>>> GetOrdensVenda()
        {
            var ordens = await _context.OrdensVenda.ToListAsync();
            return Ok(ordens);
        }
}