using iFoodApi.DTOs;
using iFoodApi.Repositories;

namespace iFoodApi.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IRestauranteRepository _restauranteRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IRestauranteRepository restauranteRepository)
    {
        _pedidoRepository = pedidoRepository;
        _restauranteRepository = restauranteRepository;
    }

    public async Task<IEnumerable<PedidoDto>> ObterTodosAsync()
    {
        var pedidos = await _pedidoRepository.ObterTodosAsync();
        return await MapearPedidosParaDto(pedidos);
    }

    public async Task<PedidoDto?> ObterPorIdAsync(int id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);
        if (pedido == null) return null;

        var pedidos = new[] { pedido };
        var pedidosDto = await MapearPedidosParaDto(pedidos);
        return pedidosDto.FirstOrDefault();
    }

    public async Task<IEnumerable<PedidoDto>> ObterPorRestauranteIdAsync(int restauranteId)
    {
        var pedidos = await _pedidoRepository.ObterPorRestauranteIdAsync(restauranteId);
        return await MapearPedidosParaDto(pedidos);
    }

    private async Task<IEnumerable<PedidoDto>> MapearPedidosParaDto(IEnumerable<Models.Pedido> pedidos)
    {
        var pedidosList = pedidos.ToList();
        var restaurantesIds = pedidosList.Select(p => p.RestauranteId).Distinct();
        var restaurantes = new Dictionary<int, string>();

        foreach (var restauranteId in restaurantesIds)
        {
            var restaurante = await _restauranteRepository.ObterPorIdAsync(restauranteId);
            if (restaurante != null)
            {
                restaurantes[restauranteId] = restaurante.Nome;
            }
        }

        return pedidosList.Select(p => new PedidoDto
        {
            Id = p.Id,
            RestauranteId = p.RestauranteId,
            RestauranteNome = restaurantes.GetValueOrDefault(p.RestauranteId, "Restaurante não encontrado"),
            ClienteNome = p.ClienteNome,
            ClienteTelefone = p.ClienteTelefone,
            EnderecoEntrega = p.EnderecoEntrega,
            ValorTotal = p.ValorTotal,
            Status = p.Status,
            DataPedido = p.DataPedido,
            Itens = p.Itens.Select(i => new ItemPedidoDto
            {
                Id = i.Id,
                NomeProduto = i.NomeProduto,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario,
                Subtotal = i.Subtotal
            }).ToList()
        });
    }
}
