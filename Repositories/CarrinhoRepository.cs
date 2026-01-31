using iFoodApi.Models;

namespace iFoodApi.Repositories;

public class CarrinhoRepository : ICarrinhoRepository
{
    private readonly Dictionary<string, Carrinho> _carrinhos;

    public CarrinhoRepository()
    {
        _carrinhos = new Dictionary<string, Carrinho>();

        // Dados mockados para demonstração
        var carrinho1 = new Carrinho
        {
            Id = Guid.NewGuid().ToString(),
            ClienteId = "cliente-001",
            RestauranteId = 1,
            RestauranteNome = "Pizzaria Bella Italia",
            DataCriacao = DateTime.UtcNow.AddHours(-2),
            DataAtualizacao = DateTime.UtcNow.AddMinutes(-30),
            Itens = new List<ItemCarrinho>
            {
                new ItemCarrinho
                {
                    Id = 101,
                    NomeProduto = "Pizza Margherita Grande",
                    Descricao = "Pizza com molho de tomate, mussarela e manjericão",
                    Quantidade = 1,
                    PrecoUnitario = 45.90m,
                    ImagemUrl = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=400&h=300&fit=crop"
                },
                new ItemCarrinho
                {
                    Id = 102,
                    NomeProduto = "Coca-Cola 2L",
                    Descricao = "Refrigerante gelado",
                    Quantidade = 2,
                    PrecoUnitario = 12.00m,
                    ImagemUrl = "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=400&h=300&fit=crop"
                }
            }
        };

        var carrinho2 = new Carrinho
        {
            Id = Guid.NewGuid().ToString(),
            ClienteId = "cliente-002",
            RestauranteId = 2,
            RestauranteNome = "Sushi Master",
            DataCriacao = DateTime.UtcNow.AddHours(-1),
            DataAtualizacao = DateTime.UtcNow.AddMinutes(-15),
            Itens = new List<ItemCarrinho>
            {
                new ItemCarrinho
                {
                    Id = 201,
                    NomeProduto = "Combinado Sushi (30 peças)",
                    Descricao = "Variedade de sushis e sashimis frescos",
                    Quantidade = 1,
                    PrecoUnitario = 120.00m,
                    ImagemUrl = "https://images.unsplash.com/photo-1579584425555-c3ce17fd4351?w=400&h=300&fit=crop"
                },
                new ItemCarrinho
                {
                    Id = 202,
                    NomeProduto = "Temaki Salmão",
                    Descricao = "Cone de alga com salmão, arroz e vegetais",
                    Quantidade = 2,
                    PrecoUnitario = 18.25m,
                    ImagemUrl = "https://images.unsplash.com/photo-1579584425555-c3ce17fd4351?w=400&h=300&fit=crop"
                }
            }
        };

        var carrinho3 = new Carrinho
        {
            Id = Guid.NewGuid().ToString(),
            ClienteId = "cliente-003",
            RestauranteId = 3,
            RestauranteNome = "Burger House",
            DataCriacao = DateTime.UtcNow.AddMinutes(-45),
            DataAtualizacao = DateTime.UtcNow.AddMinutes(-10),
            Itens = new List<ItemCarrinho>
            {
                new ItemCarrinho
                {
                    Id = 301,
                    NomeProduto = "X-Burger Completo",
                    Descricao = "Hambúrguer com carne, queijo, bacon, alface, tomate e molho especial",
                    Quantidade = 2,
                    PrecoUnitario = 28.90m,
                    ImagemUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=400&h=300&fit=crop"
                },
                new ItemCarrinho
                {
                    Id = 302,
                    NomeProduto = "Batata Frita Grande",
                    Descricao = "Porção generosa de batatas fritas crocantes",
                    Quantidade = 1,
                    PrecoUnitario = 10.00m,
                    ImagemUrl = "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=400&h=300&fit=crop"
                }
            }
        };

        // Carrinho com ID simples "001"
        var carrinho001 = new Carrinho
        {
            Id = Guid.NewGuid().ToString(),
            ClienteId = "001",
            RestauranteId = 1,
            RestauranteNome = "Pizzaria Bella Italia",
            DataCriacao = DateTime.UtcNow.AddHours(-1),
            DataAtualizacao = DateTime.UtcNow.AddMinutes(-20),
            Itens = new List<ItemCarrinho>
            {
                new ItemCarrinho
                {
                    Id = 101,
                    NomeProduto = "Pizza Quatro Queijos Grande",
                    Descricao = "Pizza com quatro tipos de queijo",
                    Quantidade = 1,
                    PrecoUnitario = 52.90m,
                    ImagemUrl = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=400&h=300&fit=crop"
                },
                new ItemCarrinho
                {
                    Id = 102,
                    NomeProduto = "Refrigerante 1.5L",
                    Descricao = "Refrigerante gelado",
                    Quantidade = 1,
                    PrecoUnitario = 8.50m,
                    ImagemUrl = "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=400&h=300&fit=crop"
                }
            }
        };

        // Carrinho com ID simples "0001"
        var carrinho0001 = new Carrinho
        {
            Id = Guid.NewGuid().ToString(),
            ClienteId = "0001",
            RestauranteId = 2,
            RestauranteNome = "Sushi Master",
            DataCriacao = DateTime.UtcNow.AddMinutes(-30),
            DataAtualizacao = DateTime.UtcNow.AddMinutes(-5),
            Itens = new List<ItemCarrinho>
            {
                new ItemCarrinho
                {
                    Id = 201,
                    NomeProduto = "Combinado Sushi (30 peças)",
                    Descricao = "Variedade de sushis e sashimis frescos",
                    Quantidade = 1,
                    PrecoUnitario = 120.00m,
                    ImagemUrl = "https://images.unsplash.com/photo-1579584425555-c3ce17fd4351?w=400&h=300&fit=crop"
                }
            }
        };

        _carrinhos[carrinho1.Id] = carrinho1;
        _carrinhos[carrinho2.Id] = carrinho2;
        _carrinhos[carrinho3.Id] = carrinho3;
        _carrinhos[carrinho001.Id] = carrinho001;
        _carrinhos[carrinho0001.Id] = carrinho0001;
    }

    public Task<Carrinho?> ObterPorClienteIdAsync(string clienteId)
    {
        var carrinho = _carrinhos.Values.FirstOrDefault(c => c.ClienteId == clienteId);
        return Task.FromResult(carrinho);
    }

    public Task<Carrinho?> ObterPorIdAsync(string carrinhoId)
    {
        _carrinhos.TryGetValue(carrinhoId, out var carrinho);
        return Task.FromResult(carrinho);
    }

    public Task<Carrinho> CriarAsync(Carrinho carrinho)
    {
        _carrinhos[carrinho.Id] = carrinho;
        return Task.FromResult(carrinho);
    }

    public Task<Carrinho> AtualizarAsync(Carrinho carrinho)
    {
        carrinho.DataAtualizacao = DateTime.UtcNow;
        _carrinhos[carrinho.Id] = carrinho;
        return Task.FromResult(carrinho);
    }

    public Task<bool> RemoverAsync(string carrinhoId)
    {
        return Task.FromResult(_carrinhos.Remove(carrinhoId));
    }

    public Task<bool> LimparCarrinhoAsync(string clienteId)
    {
        var carrinho = _carrinhos.Values.FirstOrDefault(c => c.ClienteId == clienteId);
        if (carrinho != null)
        {
            return RemoverAsync(carrinho.Id);
        }
        return Task.FromResult(false);
    }
}
