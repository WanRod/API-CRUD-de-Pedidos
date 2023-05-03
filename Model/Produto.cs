using System.ComponentModel.DataAnnotations;

namespace API_CRUD_de_Pedidos.Model
{
    public class Produto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public String Descricao { get; set; } = "";

        public DateTime DtCriacao { get; set; }
        public DateTime DtUltimaModificacao { get; set; }

    }
}
