using API_CRUD_de_Pedidos.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_de_Pedidos.Repositories
{
    public class Pedido_ProdutoRepository : IPedido_ProdutoRepository
    {
        private readonly Repositorio _context;

        public Pedido_ProdutoRepository(Repositorio context)
        {
            _context = context;
        }

        public async Task<Pedido_Produto> Create(Pedido_Produto pedido_Produto)
        {
            _context.Pedido_Produtos.Add(pedido_Produto);
            await _context.SaveChangesAsync();
            return pedido_Produto;
        }

        public async Task Delete(int id)
        {
            var pedido_ProdutoToDelete = await _context.Pedido_Produtos.FindAsync(id);
            if (pedido_ProdutoToDelete != null)
            {
                _context.Pedido_Produtos.Remove(pedido_ProdutoToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pedido_Produto>> Get()
        {
            return await _context.Pedido_Produtos.ToListAsync();
        }

        public async Task<Pedido_Produto> Get(int id)
        {
            return await _context.Pedido_Produtos.FindAsync(id);
        }

        public async Task Update(Pedido_Produto pedido_Produto)
        {
            _context.Entry(pedido_Produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
