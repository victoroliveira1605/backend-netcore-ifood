using iFoodApi.Models;

namespace iFoodApi.Repositories;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> ObterTodosAsync();
    Task<Pedido?> ObterPorIdAsync(int id);
    Task<IEnumerable<Pedido>> ObterPorRestauranteIdAsync(int restauranteId);
}
