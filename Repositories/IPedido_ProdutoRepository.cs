using API_CRUD_de_Pedidos.Model;

namespace API_CRUD_de_Pedidos.Repositories
{
    public interface IPedido_ProdutoRepository
    {
        Task<IEnumerable<Pedido_Produto>> Get();

        Task<Pedido_Produto> Get(int Id);
        Task<Pedido_Produto> Create(Pedido_Produto pedido_Produto);
        Task Update(Pedido_Produto pedido_Produto);
        Task Delete(int Id);
    }
}