namespace AulaWebDev.Dominio.DTOs
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string? Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
