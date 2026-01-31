using iFoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace iFoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CarrinhoController : ControllerBase
{
    private readonly ICarrinhoService _service;
    private readonly ILogger<CarrinhoController> _logger;

    public CarrinhoController(ICarrinhoService service, ILogger<CarrinhoController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Obtém o carrinho de um cliente
    /// </summary>
    /// <param name="clienteId">ID do cliente</param>
    /// <returns>Carrinho do cliente</returns>
    /// <response code="200">Retorna o carrinho</response>
    /// <response code="404">Carrinho não encontrado</response>
    [HttpGet("{clienteId}")]
    [ProducesResponseType(typeof(DTOs.CarrinhoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DTOs.CarrinhoDto>> ObterCarrinho(string clienteId)
    {
        try
        {
            _logger.LogInformation("Buscando carrinho do cliente: {ClienteId}", clienteId);
            var carrinho = await _service.ObterPorClienteIdAsync(clienteId);

            if (carrinho == null)
            {
                _logger.LogWarning("Carrinho não encontrado para o cliente: {ClienteId}", clienteId);
                return NotFound(new { message = $"Carrinho não encontrado para o cliente {clienteId}" });
            }

            return Ok(carrinho);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar carrinho do cliente: {ClienteId}", clienteId);
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Adiciona um item ao carrinho
    /// </summary>
    /// <param name="itemDto">Dados do item a ser adicionado</param>
    /// <returns>Carrinho atualizado</returns>
    /// <response code="200">Item adicionado com sucesso</response>
    /// <response code="400">Dados inválidos</response>
    [HttpPost("adicionar-item")]
    [ProducesResponseType(typeof(DTOs.CarrinhoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DTOs.CarrinhoDto>> AdicionarItem([FromBody] DTOs.AdicionarItemCarrinhoDto itemDto)
    {
        try
        {
            _logger.LogInformation("Adicionando item ao carrinho do cliente: {ClienteId}", itemDto.ClienteId);
            var carrinho = await _service.AdicionarItemAsync(itemDto);
            return Ok(carrinho);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Erro de validação ao adicionar item");
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Operação inválida ao adicionar item");
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao adicionar item ao carrinho");
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Atualiza a quantidade de um item no carrinho
    /// </summary>
    /// <param name="clienteId">ID do cliente</param>
    /// <param name="itemId">ID do item</param>
    /// <param name="quantidadeDto">Nova quantidade</param>
    /// <returns>Carrinho atualizado</returns>
    /// <response code="200">Quantidade atualizada com sucesso</response>
    /// <response code="400">Dados inválidos</response>
    /// <response code="404">Carrinho ou item não encontrado</response>
    [HttpPut("{clienteId}/itens/{itemId}/quantidade")]
    [ProducesResponseType(typeof(DTOs.CarrinhoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DTOs.CarrinhoDto>> AtualizarQuantidade(
        string clienteId, 
        int itemId, 
        [FromBody] DTOs.AtualizarItemCarrinhoDto quantidadeDto)
    {
        try
        {
            _logger.LogInformation("Atualizando quantidade do item {ItemId} no carrinho do cliente: {ClienteId}", itemId, clienteId);
            var carrinho = await _service.AtualizarQuantidadeItemAsync(clienteId, itemId, quantidadeDto.Quantidade);

            if (carrinho == null)
            {
                _logger.LogWarning("Carrinho ou item não encontrado");
                return NotFound(new { message = "Carrinho ou item não encontrado" });
            }

            return Ok(carrinho);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Erro de validação ao atualizar quantidade");
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar quantidade do item");
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Remove um item do carrinho
    /// </summary>
    /// <param name="clienteId">ID do cliente</param>
    /// <param name="itemId">ID do item</param>
    /// <returns>Carrinho atualizado</returns>
    /// <response code="200">Item removido com sucesso</response>
    /// <response code="404">Carrinho ou item não encontrado</response>
    [HttpDelete("{clienteId}/itens/{itemId}")]
    [ProducesResponseType(typeof(DTOs.CarrinhoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DTOs.CarrinhoDto>> RemoverItem(string clienteId, int itemId)
    {
        try
        {
            _logger.LogInformation("Removendo item {ItemId} do carrinho do cliente: {ClienteId}", itemId, clienteId);
            var carrinho = await _service.RemoverItemAsync(clienteId, itemId);

            if (carrinho == null)
            {
                _logger.LogWarning("Carrinho ou item não encontrado");
                return NotFound(new { message = "Carrinho ou item não encontrado" });
            }

            return Ok(carrinho);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover item do carrinho");
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Limpa todo o carrinho do cliente
    /// </summary>
    /// <param name="clienteId">ID do cliente</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="200">Carrinho limpo com sucesso</response>
    /// <response code="404">Carrinho não encontrado</response>
    [HttpDelete("{clienteId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> LimparCarrinho(string clienteId)
    {
        try
        {
            _logger.LogInformation("Limpando carrinho do cliente: {ClienteId}", clienteId);
            var resultado = await _service.LimparCarrinhoAsync(clienteId);

            if (!resultado)
            {
                _logger.LogWarning("Carrinho não encontrado para o cliente: {ClienteId}", clienteId);
                return NotFound(new { message = $"Carrinho não encontrado para o cliente {clienteId}" });
            }

            return Ok(new { message = "Carrinho limpo com sucesso" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao limpar carrinho");
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }
}
