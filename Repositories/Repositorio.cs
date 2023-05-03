using API_CRUD_de_Pedidos.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_de_Pedidos.Repositories
{
    public class Repositorio : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pedido_Produto> Pedido_Produtos { get; set; }


        //Create if not exist
        public Repositorio(DbContextOptions<Repositorio> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}