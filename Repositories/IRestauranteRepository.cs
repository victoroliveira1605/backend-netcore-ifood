using iFoodApi.Models;

namespace iFoodApi.Repositories;

public interface IRestauranteRepository
{
    Task<IEnumerable<Restaurante>> ObterTodosAsync();
    Task<Restaurante?> ObterPorIdAsync(int id);
}
