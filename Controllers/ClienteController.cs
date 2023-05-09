using API_CRUD_de_Pedidos.Model;
using API_CRUD_de_Pedidos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_de_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteRepository.Get();
        }

        [HttpGet("Id")]
        public async Task<ActionResult<Cliente>> GetClientes(int id)
        {
            return await _clienteRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostClientes([FromBody] Cliente cliente)
        {
            var novoCliente = await _clienteRepository.Create(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpDelete("Id")]
        public async Task<ActionResult> Delete(int id)
        {
            var clienteToDelete = await _clienteRepository.Get(id);

            if (clienteToDelete == null)
                return NotFound();

            await _clienteRepository.Delete(clienteToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutClientes(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            await _clienteRepository.Update(cliente);

            return NoContent();
        }

    }
}
