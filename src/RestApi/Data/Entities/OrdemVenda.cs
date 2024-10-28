namespace RestApi.Data.Entities;

public class OrdemVenda
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataOrdem { get; set; }

    // Navegação para o produto (opcional)
    public Produto Produto { get; set; }
}
