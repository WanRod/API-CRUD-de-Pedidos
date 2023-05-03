using API_CRUD_de_Pedidos.Model;
using API_CRUD_de_Pedidos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_de_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet("Lista de pedidos")]
        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _pedidoRepository.Get();
        }

        [HttpGet("Encontrar (Id)")]
        public async Task<ActionResult<Pedido>> GetPedidos(int id)
        {
            return await _pedidoRepository.Get(id);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<Pedido>> PostPedidos([FromBody] Pedido pedido)
        {
            var novoPedido = await _pedidoRepository.Create(pedido);
            return CreatedAtAction(nameof(GetPedidos), new { id = novoPedido.Id }, novoPedido);
        }

        [HttpDelete("Apagar (Id)")]
        public async Task<ActionResult> Delete(int id)
        {
            var pedidoToDelete = await _pedidoRepository.Get(id);

            if (pedidoToDelete == null)
                return NotFound();

            await _pedidoRepository.Delete(pedidoToDelete.Id);
            return NoContent();
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> PutPedidos(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id)
                return BadRequest();

            await _pedidoRepository.Update(pedido);

            return NoContent();
        }
    }
}
