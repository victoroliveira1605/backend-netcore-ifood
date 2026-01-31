using iFoodApi.Models;

namespace iFoodApi.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly List<Pedido> _pedidos;

    public PedidoRepository()
    {
        // Dados mockados para demonstração
        _pedidos = new List<Pedido>
        {
            new Pedido
            {
                Id = 1,
                RestauranteId = 1,
                ClienteNome = "João Silva",
                ClienteTelefone = "(11) 98765-4321",
                EnderecoEntrega = "Rua das Acácias, 456 - Vila Nova",
                ValorTotal = 89.90m,
                Status = "Em Preparo",
                DataPedido = DateTime.UtcNow.AddHours(-2),
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { Id = 1, NomeProduto = "Pizza Margherita Grande", Quantidade = 1, PrecoUnitario = 45.90m },
                    new ItemPedido { Id = 2, NomeProduto = "Coca-Cola 2L", Quantidade = 2, PrecoUnitario = 22.00m }
                }
            },
            new Pedido
            {
                Id = 2,
                RestauranteId = 2,
                ClienteNome = "Maria Santos",
                ClienteTelefone = "(11) 97654-3210",
                EnderecoEntrega = "Av. Brasil, 789 - Jardim América",
                ValorTotal = 156.50m,
                Status = "Saiu para Entrega",
                DataPedido = DateTime.UtcNow.AddHours(-1),
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { Id = 3, NomeProduto = "Combinado Sushi (30 peças)", Quantidade = 1, PrecoUnitario = 120.00m },
                    new ItemPedido { Id = 4, NomeProduto = "Temaki Salmão", Quantidade = 2, PrecoUnitario = 18.25m }
                }
            },
            new Pedido
            {
                Id = 3,
                RestauranteId = 3,
                ClienteNome = "Pedro Oliveira",
                ClienteTelefone = "(11) 96543-2109",
                EnderecoEntrega = "Rua dos Pinheiros, 321 - Pinheiros",
                ValorTotal = 67.80m,
                Status = "Entregue",
                DataPedido = DateTime.UtcNow.AddHours(-4),
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { Id = 5, NomeProduto = "X-Burger Completo", Quantidade = 2, PrecoUnitario = 28.90m },
                    new ItemPedido { Id = 6, NomeProduto = "Batata Frita Grande", Quantidade = 1, PrecoUnitario = 10.00m }
                }
            },
            new Pedido
            {
                Id = 4,
                RestauranteId = 1,
                ClienteNome = "Ana Costa",
                ClienteTelefone = "(11) 95432-1098",
                EnderecoEntrega = "Rua das Palmeiras, 654 - Alto da Boa Vista",
                ValorTotal = 125.70m,
                Status = "Confirmado",
                DataPedido = DateTime.UtcNow.AddMinutes(-30),
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { Id = 7, NomeProduto = "Pizza Quatro Queijos Grande", Quantidade = 1, PrecoUnitario = 52.90m },
                    new ItemPedido { Id = 8, NomeProduto = "Pizza Calabresa Média", Quantidade = 1, PrecoUnitario = 38.80m },
                    new ItemPedido { Id = 9, NomeProduto = "Refrigerante 1.5L", Quantidade = 2, PrecoUnitario = 17.00m }
                }
            },
            new Pedido
            {
                Id = 5,
                RestauranteId = 4,
                ClienteNome = "Carlos Mendes",
                ClienteTelefone = "(11) 94321-0987",
                EnderecoEntrega = "Av. Rebouças, 987 - Cerqueira César",
                ValorTotal = 98.50m,
                Status = "Pendente",
                DataPedido = DateTime.UtcNow.AddMinutes(-10),
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { Id = 10, NomeProduto = "Lasanha à Bolonhesa", Quantidade = 2, PrecoUnitario = 42.50m },
                    new ItemPedido { Id = 11, NomeProduto = "Salada Caesar", Quantidade = 1, PrecoUnitario = 13.50m }
                }
            }
        };
    }

    public Task<IEnumerable<Pedido>> ObterTodosAsync()
    {
        return Task.FromResult(_pedidos.AsEnumerable());
    }

    public Task<Pedido?> ObterPorIdAsync(int id)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(pedido);
    }

    public Task<IEnumerable<Pedido>> ObterPorRestauranteIdAsync(int restauranteId)
    {
        var pedidos = _pedidos.Where(p => p.RestauranteId == restauranteId);
        return Task.FromResult(pedidos);
    }
}
