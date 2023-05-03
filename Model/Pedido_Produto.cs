using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CRUD_de_Pedidos.Model
{
    public class Pedido_Produto
    {
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public Decimal VrUnitario { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime DtUltimaModificacao { get; set; }
    }
}
