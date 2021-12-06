using System.ComponentModel.DataAnnotations;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ApiExercicio3.Produtos.Requests
{
    public class ProdutoAtualizarRequests
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(2000)]
        public string Descricao { get; set; }

        [Range(0, int.MaxValue)] 
        public decimal Valor { get; set; }
    }
}