namespace iFoodApi.Models;

public class Pedido
{
    public int Id { get; set; }
    public int RestauranteId { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public string ClienteTelefone { get; set; } = string.Empty;
    public string EnderecoEntrega { get; set; } = string.Empty;
    public decimal ValorTotal { get; set; }
    public string Status { get; set; } = "Pendente"; // Pendente, Confirmado, Em Preparo, Saiu para Entrega, Entregue, Cancelado
    public DateTime DataPedido { get; set; } = DateTime.UtcNow;
    public List<ItemPedido> Itens { get; set; } = new();
}

public class ItemPedido
{
    public int Id { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Subtotal => Quantidade * PrecoUnitario;
}
