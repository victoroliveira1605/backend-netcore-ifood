using iFoodApi.Models;

namespace iFoodApi.Repositories;

public interface ICarrinhoRepository
{
    Task<Carrinho?> ObterPorClienteIdAsync(string clienteId);
    Task<Carrinho?> ObterPorIdAsync(string carrinhoId);
    Task<Carrinho> CriarAsync(Carrinho carrinho);
    Task<Carrinho> AtualizarAsync(Carrinho carrinho);
    Task<bool> RemoverAsync(string carrinhoId);
    Task<bool> LimparCarrinhoAsync(string clienteId);
}
