using System.ComponentModel.DataAnnotations;

namespace exemploAPI.DTOs
{
    public class ProdutosDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O ID do fornecedor é obrigatório.")]
        public int FornecedorId { get; set; }
    }
}
