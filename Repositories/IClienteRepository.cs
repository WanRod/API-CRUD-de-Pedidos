using API_CRUD_de_Pedidos.Model;

namespace API_CRUD_de_Pedidos.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Get();

        Task<Cliente> Get(int Id);
        Task<Cliente> Create(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int Id);
    }
}
