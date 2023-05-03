using System.ComponentModel.DataAnnotations.Schema;

namespace API_CRUD_de_Pedidos.Model
{
    public class Pedido
    {
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DtPedido { get; set; }

        public DateTime DtCriacao { get; set; }
        public DateTime DtUltimaModificação { get; set; }

    }
}
