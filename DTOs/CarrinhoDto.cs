namespace iFoodApi.DTOs;

public class CarrinhoDto
{
    public string Id { get; set; } = string.Empty;
    public string ClienteId { get; set; } = string.Empty;
    public int RestauranteId { get; set; }
    public string RestauranteNome { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public decimal ValorTotal { get; set; }
    public List<ItemCarrinhoDto> Itens { get; set; } = new();
}

public class ItemCarrinhoDto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public decimal Subtotal { get; set; }
}

public class AdicionarItemCarrinhoDto
{
    public string ClienteId { get; set; } = string.Empty;
    public int RestauranteId { get; set; }
    public int ProdutoId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
}

public class AtualizarItemCarrinhoDto
{
    public int Quantidade { get; set; }
}
