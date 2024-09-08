using ControleDeEstoque.Data;
using ControleDeEstoque.Models;
using ControleDeEstoque.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeController.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public async Task<IActionResult> GetAsync([FromServices]AppDbContext context)
        {
            var produtos = await context.Produtos.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices]AppDbContext context,[FromRoute]int id)
        {
            var produto = await context.Produtos.FindAsync(id);
            if(produto is null){ 
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost("/")]
        public async Task<IActionResult> PostAsync([FromServices]AppDbContext context,[FromBody] CreateProdutoViewModel umProduto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

           var produto = new Produto
           {
                Id = umProduto.Id,
                Nome = umProduto.Nome,
                Descricao = umProduto.Descricao,
                Quantidade = umProduto.Quantidade,
                Valor = umProduto.Valor
           };

           await context.Produtos.AddAsync(produto);
           await context.SaveChangesAsync();

           return Created($"/{produto.Id}",produto); 
        }

        [HttpPut("/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices]AppDbContext context,[FromRoute] int id,[FromBody] UpdateProdutoViewModel umProduto)
        {
            var produto = await context.Produtos.FindAsync(id);
            if(produto is null){
                return NotFound();
            }

            produto.Nome = umProduto.Nome;
            produto.Descricao = umProduto.Descricao;
            produto.Quantidade = umProduto.Quantidade;
            produto.Valor = umProduto.Valor;

            await context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpDelete("/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices]AppDbContext context,[FromRoute] int id)
        {
            var produto = await context.Produtos.FindAsync(id);
            if(produto is null){
                return NotFound();
            }

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("/entrada")]
        public async Task<IActionResult> EntradaAsync([FromServices]AppDbContext context,[FromBody] PatchProdutoViewModel transacao)
        {
            var produto = await context.Produtos.FindAsync(transacao.IdProduto);
            if(produto is null){
                return NotFound(); 
            };

            var newTransacao = new Transacao{
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,
                Tipo = "Entrada",
                QuantidadeAntes = produto.Quantidade,
                QuantidadeDepois = produto.Quantidade + transacao.Quantidade,
                QuantidadeTransacao = transacao.Quantidade,
                DataTransacao = DateTime.Now
            };
            await context.Transacoes.AddAsync(newTransacao);

            produto.Quantidade += transacao.Quantidade;
            await context.SaveChangesAsync();
            return Ok(newTransacao);
        }

        [HttpPatch("/saida")]
        public async Task<IActionResult> SaidaAsync([FromServices]AppDbContext context,[FromBody] PatchProdutoViewModel transacao)
        {
            var produto = await context.Produtos.FindAsync(transacao.IdProduto);
            if(produto is null){
                return NotFound(); 
            }

            if(transacao.Quantidade > produto.Quantidade){
                return BadRequest("A quantidade de saída é maior que a quantidade existente");
            }
            
            var newTransacao = new Transacao{
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,
                Tipo = "Saída",
                QuantidadeAntes = produto.Quantidade,
                QuantidadeDepois = produto.Quantidade - transacao.Quantidade,
                QuantidadeTransacao = transacao.Quantidade,
                DataTransacao = DateTime.Now
            };
            await context.Transacoes.AddAsync(newTransacao);

            produto.Quantidade -= transacao.Quantidade;
            await context.SaveChangesAsync();

            return Ok(newTransacao);
        }

        [HttpGet("/transacoes")]
        public async Task<IActionResult> GetTransacoesAsync([FromServices]AppDbContext context)
        {
            var transacoes = await context.Transacoes.ToListAsync();
            return Ok(transacoes);
        }

        [HttpGet("/transacoes/{id:int}")]
        public async Task<IActionResult> GetTransacoesPorIdAsync([FromServices]AppDbContext context,[FromRoute] int id)
        {
            var transacao = await context.Transacoes.FindAsync(id);
            if (transacao is null){
                return NotFound();
            }
            return Ok(transacao);
        }
    
        [HttpDelete("{id:int}/removertransacoes")]
        public async Task<IActionResult> DeleteTransacoesAsync([FromServices]AppDbContext context, [FromRoute] int id)
        {
            var transacao = await context.Transacoes.FindAsync(id);
            if(transacao is null){
                return NotFound();
            }

            context.Transacoes.Remove(transacao);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}