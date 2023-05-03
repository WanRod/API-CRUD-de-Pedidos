using API_CRUD_de_Pedidos.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_de_Pedidos.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Repositorio _context;

        public ClienteRepository(Repositorio context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var clienteToDelete = await _context.Clientes.FindAsync(id);
            if (clienteToDelete != null)
            {
                _context.Clientes.Remove(clienteToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
