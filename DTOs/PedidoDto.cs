namespace iFoodApi.DTOs;

public class PedidoDto
{
    public int Id { get; set; }
    public int RestauranteId { get; set; }
    public string RestauranteNome { get; set; } = string.Empty;
    public string ClienteNome { get; set; } = string.Empty;
    public string ClienteTelefone { get; set; } = string.Empty;
    public string EnderecoEntrega { get; set; } = string.Empty;
    public decimal ValorTotal { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime DataPedido { get; set; }
    public List<ItemPedidoDto> Itens { get; set; } = new();
}

public class ItemPedidoDto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Subtotal { get; set; }
}
