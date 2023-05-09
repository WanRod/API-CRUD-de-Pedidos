using API_CRUD_de_Pedidos.Model;
using API_CRUD_de_Pedidos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_de_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pedido_ProdutoController : ControllerBase
    {
        private readonly IPedido_ProdutoRepository _pedido_ProdutoRepository;
        public Pedido_ProdutoController(IPedido_ProdutoRepository pedido_ProdutoRepository)
        {
            _pedido_ProdutoRepository = pedido_ProdutoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pedido_Produto>> GetPedidos_Produtos()
        {
            return await _pedido_ProdutoRepository.Get();
        }

        [HttpGet("Id")]
        public async Task<ActionResult<Pedido_Produto>> GetPedidos_Produtos(int id)
        {
            return await _pedido_ProdutoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido_Produto>> PostPedidos_Produtos([FromBody] Pedido_Produto pedido_Produto)
        {
            var novoPedido_Produto = await _pedido_ProdutoRepository.Create(pedido_Produto);
            return CreatedAtAction(nameof(GetPedidos_Produtos), new { id = novoPedido_Produto.Id }, novoPedido_Produto);
        }

        [HttpDelete("Id")]
        public async Task<ActionResult> Delete(int id)
        {
            var pedido_ProdutoToDelete = await _pedido_ProdutoRepository.Get(id);

            if (pedido_ProdutoToDelete == null)
                return NotFound();

            await _pedido_ProdutoRepository.Delete(pedido_ProdutoToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutPedidos_Produtos(int id, [FromBody] Pedido_Produto pedido_Produto)
        {
            if (id != pedido_Produto.Id)
                return BadRequest();

            await _pedido_ProdutoRepository.Update(pedido_Produto);

            return NoContent();
        }
    }
}
