using iFoodApi.Models;

namespace iFoodApi.Repositories;

public class RestauranteRepository : IRestauranteRepository
{
    private readonly List<Restaurante> _restaurantes;

    public RestauranteRepository()
    {
        // Dados mockados para demonstração
        _restaurantes = new List<Restaurante>
        {
            new Restaurante
            {
                Id = 1,
                Nome = "Pizzaria Bella Italia",
                Categoria = "Pizza",
                Endereco = "Rua das Flores, 123 - Centro",
                Telefone = "(11) 3456-7890",
                Avaliacao = 4.8m,
                Banner = "https://images.unsplash.com/photo-1513104890138-7c749659a591?w=800&h=400&fit=crop",
                Ativo = true,
                DataCadastro = DateTime.UtcNow.AddDays(-30)
            },
            new Restaurante
            {
                Id = 2,
                Nome = "Sushi Master",
                Categoria = "Japonesa",
                Endereco = "Av. Paulista, 1000 - Bela Vista",
                Telefone = "(11) 3123-4567",
                Avaliacao = 4.9m,
                Banner = "https://images.unsplash.com/photo-1579584425555-c3ce17fd4351?w=800&h=400&fit=crop",
                Ativo = true,
                DataCadastro = DateTime.UtcNow.AddDays(-25)
            },
            new Restaurante
            {
                Id = 3,
                Nome = "Burger House",
                Categoria = "Hamburgueria",
                Endereco = "Rua Augusta, 500 - Consolação",
                Telefone = "(11) 3234-5678",
                Avaliacao = 4.6m,
                Banner = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800&h=400&fit=crop",
                Ativo = true,
                DataCadastro = DateTime.UtcNow.AddDays(-20)
            },
            new Restaurante
            {
                Id = 4,
                Nome = "Cantina Toscana",
                Categoria = "Italiana",
                Endereco = "Rua Oscar Freire, 200 - Jardins",
                Telefone = "(11) 3345-6789",
                Avaliacao = 4.7m,
                Banner = "https://images.unsplash.com/photo-1555939594-58d7cb561ad1?w=800&h=400&fit=crop",
                Ativo = true,
                DataCadastro = DateTime.UtcNow.AddDays(-15)
            },
            new Restaurante
            {
                Id = 5,
                Nome = "Churrascaria Gaúcha",
                Categoria = "Brasileira",
                Endereco = "Av. Faria Lima, 1500 - Itaim Bibi",
                Telefone = "(11) 3456-7891",
                Avaliacao = 4.5m,
                Banner = "https://images.unsplash.com/photo-1558030006-450675393462?w=800&h=400&fit=crop",
                Ativo = true,
                DataCadastro = DateTime.UtcNow.AddDays(-10)
            }
        };
    }

    public Task<IEnumerable<Restaurante>> ObterTodosAsync()
    {
        return Task.FromResult(_restaurantes.Where(r => r.Ativo).AsEnumerable());
    }

    public Task<Restaurante?> ObterPorIdAsync(int id)
    {
        var restaurante = _restaurantes.FirstOrDefault(r => r.Id == id && r.Ativo);
        return Task.FromResult(restaurante);
    }
}
