namespace RestApi.Data.Entities;

public class Venda
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
    public int IdadeCliente { get; set; }
    public string RedeSocial { get; set; }
    public string PaisCliente { get; set; }
    public DateTime DataVenda { get; set; }
}