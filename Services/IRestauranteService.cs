using iFoodApi.DTOs;

namespace iFoodApi.Services;

public interface IRestauranteService
{
    Task<IEnumerable<RestauranteDto>> ObterTodosAsync();
    Task<RestauranteDto?> ObterPorIdAsync(int id);
}
