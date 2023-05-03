using API_CRUD_de_Pedidos.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_de_Pedidos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Repositorio _context;

        public ProdutoRepository(Repositorio context)
        {
            _context = context;
        }
        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(int id)
        {
            var produtoToDelete = await _context.Produtos.FindAsync(id);
            if (produtoToDelete != null)
            {
                _context.Produtos.Remove(produtoToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> Get(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
