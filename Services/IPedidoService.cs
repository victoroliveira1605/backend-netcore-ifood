using iFoodApi.DTOs;

namespace iFoodApi.Services;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDto>> ObterTodosAsync();
    Task<PedidoDto?> ObterPorIdAsync(int id);
    Task<IEnumerable<PedidoDto>> ObterPorRestauranteIdAsync(int restauranteId);
}
