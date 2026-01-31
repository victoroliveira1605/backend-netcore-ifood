namespace iFoodApi.Models;

public class Carrinho
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ClienteId { get; set; } = string.Empty;
    public int RestauranteId { get; set; }
    public string RestauranteNome { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
    public List<ItemCarrinho> Itens { get; set; } = new();
    public decimal ValorTotal => Itens.Sum(i => i.Subtotal);
}

public class ItemCarrinho
{
    public int Id { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public decimal Subtotal => Quantidade * PrecoUnitario;
}
