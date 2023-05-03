using API_CRUD_de_Pedidos.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_de_Pedidos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly Repositorio _context;

        public PedidoRepository(Repositorio context)
        {
            _context = context;
        }

        public async Task<Pedido> Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task Delete(int id)
        {
            var pedidoToDelete = await _context.Pedidos.FindAsync(id);
            if (pedidoToDelete != null)
            {
                _context.Pedidos.Remove(pedidoToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pedido>> Get()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> Get(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task Update(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}