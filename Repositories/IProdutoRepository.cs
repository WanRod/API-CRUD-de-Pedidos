using API_CRUD_de_Pedidos.Model;

namespace API_CRUD_de_Pedidos.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Get();

        Task<Produto> Get(int Id);
        Task<Produto> Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(int Id);
    }
}
