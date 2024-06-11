using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Categoria
    {
        [Key]
        public long? CategoriasId { get; set; }

        [Required]
        public string Nome { get; set; }

        public IList<Produto>? Produtos { get; set; }

    }
}
