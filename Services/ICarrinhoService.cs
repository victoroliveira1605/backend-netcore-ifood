using iFoodApi.DTOs;

namespace iFoodApi.Services;

public interface ICarrinhoService
{
    Task<CarrinhoDto?> ObterPorClienteIdAsync(string clienteId);
    Task<CarrinhoDto> AdicionarItemAsync(AdicionarItemCarrinhoDto itemDto);
    Task<CarrinhoDto?> AtualizarQuantidadeItemAsync(string clienteId, int itemId, int quantidade);
    Task<CarrinhoDto?> RemoverItemAsync(string clienteId, int itemId);
    Task<bool> LimparCarrinhoAsync(string clienteId);
}
