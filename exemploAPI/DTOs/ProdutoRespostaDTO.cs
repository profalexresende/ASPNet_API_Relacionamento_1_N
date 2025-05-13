namespace exemploAPI.DTOs
{
    public class ProdutoRespostaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; }
    }
}
