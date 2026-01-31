using iFoodApi.DTOs;
using iFoodApi.Models;
using iFoodApi.Repositories;

namespace iFoodApi.Services;

public class CarrinhoService : ICarrinhoService
{
    private readonly ICarrinhoRepository _carrinhoRepository;
    private readonly IRestauranteRepository _restauranteRepository;

    public CarrinhoService(ICarrinhoRepository carrinhoRepository, IRestauranteRepository restauranteRepository)
    {
        _carrinhoRepository = carrinhoRepository;
        _restauranteRepository = restauranteRepository;
    }

    public async Task<CarrinhoDto?> ObterPorClienteIdAsync(string clienteId)
    {
        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(clienteId);
        if (carrinho == null) return null;

        return MapearParaDto(carrinho);
    }

    public async Task<CarrinhoDto> AdicionarItemAsync(AdicionarItemCarrinhoDto itemDto)
    {
        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(itemDto.ClienteId);

        if (carrinho == null)
        {
            // Criar novo carrinho
            var restaurante = await _restauranteRepository.ObterPorIdAsync(itemDto.RestauranteId);
            if (restaurante == null)
            {
                throw new ArgumentException($"Restaurante com ID {itemDto.RestauranteId} não encontrado");
            }

            carrinho = new Carrinho
            {
                ClienteId = itemDto.ClienteId,
                RestauranteId = itemDto.RestauranteId,
                RestauranteNome = restaurante.Nome,
                DataCriacao = DateTime.UtcNow,
                DataAtualizacao = DateTime.UtcNow,
                Itens = new List<ItemCarrinho>()
            };

            carrinho = await _carrinhoRepository.CriarAsync(carrinho);
        }
        else
        {
            // Verificar se o carrinho é do mesmo restaurante
            if (carrinho.RestauranteId != itemDto.RestauranteId)
            {
                throw new InvalidOperationException("Não é possível adicionar itens de restaurantes diferentes no mesmo carrinho");
            }
        }

        // Verificar se o item já existe no carrinho
        var itemExistente = carrinho.Itens.FirstOrDefault(i => i.Id == itemDto.ProdutoId);
        if (itemExistente != null)
        {
            // Atualizar quantidade
            itemExistente.Quantidade += itemDto.Quantidade;
        }
        else
        {
            // Adicionar novo item
            var novoItem = new ItemCarrinho
            {
                Id = itemDto.ProdutoId,
                NomeProduto = itemDto.NomeProduto,
                Descricao = itemDto.Descricao,
                Quantidade = itemDto.Quantidade,
                PrecoUnitario = itemDto.PrecoUnitario,
                ImagemUrl = itemDto.ImagemUrl
            };
            carrinho.Itens.Add(novoItem);
        }

        carrinho = await _carrinhoRepository.AtualizarAsync(carrinho);
        return MapearParaDto(carrinho);
    }

    public async Task<CarrinhoDto?> AtualizarQuantidadeItemAsync(string clienteId, int itemId, int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero");
        }

        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(clienteId);
        if (carrinho == null) return null;

        var item = carrinho.Itens.FirstOrDefault(i => i.Id == itemId);
        if (item == null) return null;

        item.Quantidade = quantidade;
        carrinho = await _carrinhoRepository.AtualizarAsync(carrinho);

        return MapearParaDto(carrinho);
    }

    public async Task<CarrinhoDto?> RemoverItemAsync(string clienteId, int itemId)
    {
        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(clienteId);
        if (carrinho == null) return null;

        var item = carrinho.Itens.FirstOrDefault(i => i.Id == itemId);
        if (item == null) return null;

        carrinho.Itens.Remove(item);
        carrinho = await _carrinhoRepository.AtualizarAsync(carrinho);

        return MapearParaDto(carrinho);
    }

    public async Task<bool> LimparCarrinhoAsync(string clienteId)
    {
        return await _carrinhoRepository.LimparCarrinhoAsync(clienteId);
    }

    private CarrinhoDto MapearParaDto(Carrinho carrinho)
    {
        return new CarrinhoDto
        {
            Id = carrinho.Id,
            ClienteId = carrinho.ClienteId,
            RestauranteId = carrinho.RestauranteId,
            RestauranteNome = carrinho.RestauranteNome,
            DataCriacao = carrinho.DataCriacao,
            DataAtualizacao = carrinho.DataAtualizacao,
            ValorTotal = carrinho.ValorTotal,
            Itens = carrinho.Itens.Select(i => new ItemCarrinhoDto
            {
                Id = i.Id,
                NomeProduto = i.NomeProduto,
                Descricao = i.Descricao,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario,
                ImagemUrl = i.ImagemUrl,
                Subtotal = i.Subtotal
            }).ToList()
        };
    }
}
