using API_CRUD_de_Pedidos.Model;

namespace API_CRUD_de_Pedidos.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> Get();

        Task<Pedido> Get(int Id);
        Task<Pedido> Create(Pedido pedido);
        Task Update(Pedido pedido);
        Task Delete(int Id);
    }
}
