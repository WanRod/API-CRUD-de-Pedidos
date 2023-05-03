using API_CRUD_de_Pedidos.Model;
using API_CRUD_de_Pedidos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_de_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("Lista de produtos")]
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _produtoRepository.Get();
        }

        [HttpGet("Encontrar (Id)")]
        public async Task<ActionResult<Produto>> GetProdutos(int id)
        {
            return await _produtoRepository.Get(id);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<Produto>> PostProdutos([FromBody] Produto produto)
        {
            var novoProduto = await _produtoRepository.Create(produto);
            return CreatedAtAction(nameof(GetProdutos), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpDelete("Apagar (Id)")]
        public async Task<ActionResult> Delete(int id)
        {
            var produtoToDelete = await _produtoRepository.Get(id);

            if (produtoToDelete == null)
                return NotFound();

            await _produtoRepository.Delete(produtoToDelete.Id);
            return NoContent();

        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> PutProdutos(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            await _produtoRepository.Update(produto);

            return NoContent();
        }
    }
}
