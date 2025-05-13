namespace exemploAPI.DTOs
{
    public class FornecedorRespostaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<ProdutoResumoDTO> Produtos { get; set; }
    }
}
