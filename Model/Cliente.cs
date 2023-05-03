using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CRUD_de_Pedidos.Model
{
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public String Nome { get; set; } = "";

        [Column(TypeName = "date")]
        public DateTime DtNascimento { get; set; }

        [MaxLength(15)]
        public String CPF { get; set; } = "";

        [MaxLength(10)]
        public String CEP { get; set; } = "";

        [MaxLength(100)]
        public String Endereco { get; set; } = "";

        [MaxLength(100)]
        public String Numero { get; set; } = "";

        [MaxLength(100)]
        public String Complemento { get; set; } = "";

        [MaxLength(60)]
        public String Bairro { get; set; } = "";

        [MaxLength(100)]
        public String Cidade { get; set; } = "";

        [MaxLength(2)]
        public String UF { get; set; } = "";

        public DateTime DtCriacao { get; set; }
        public DateTime DtUltimaModificacao { get; set; }

    }
}
