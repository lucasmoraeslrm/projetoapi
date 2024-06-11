using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Produto
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Preco { get; set; }

        [Required]
        public int QntEstoque { get; set; }

        [ForeignKey("Categorias")]
        public long? FK_CategoriaId { get; set; }

        public Categoria? Categorias { get; set; }
    }
}
