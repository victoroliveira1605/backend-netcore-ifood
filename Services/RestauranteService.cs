using iFoodApi.DTOs;
using iFoodApi.Repositories;

namespace iFoodApi.Services;

public class RestauranteService : IRestauranteService
{
    private readonly IRestauranteRepository _repository;

    public RestauranteService(IRestauranteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RestauranteDto>> ObterTodosAsync()
    {
        var restaurantes = await _repository.ObterTodosAsync();
        return restaurantes.Select(r => new RestauranteDto
        {
            Id = r.Id,
            Nome = r.Nome,
            Categoria = r.Categoria,
            Endereco = r.Endereco,
            Telefone = r.Telefone,
            Avaliacao = r.Avaliacao,
            Banner = r.Banner,
            Ativo = r.Ativo
        });
    }

    public async Task<RestauranteDto?> ObterPorIdAsync(int id)
    {
        var restaurante = await _repository.ObterPorIdAsync(id);
        if (restaurante == null) return null;

        return new RestauranteDto
        {
            Id = restaurante.Id,
            Nome = restaurante.Nome,
            Categoria = restaurante.Categoria,
            Endereco = restaurante.Endereco,
            Telefone = restaurante.Telefone,
            Avaliacao = restaurante.Avaliacao,
            Banner = restaurante.Banner,
            Ativo = restaurante.Ativo
        };
    }
}
