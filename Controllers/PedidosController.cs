using iFoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace iFoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _service;
    private readonly ILogger<PedidosController> _logger;

    public PedidosController(IPedidoService service, ILogger<PedidosController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Obtém todos os pedidos
    /// </summary>
    /// <returns>Lista de pedidos</returns>
    /// <response code="200">Retorna a lista de pedidos</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DTOs.PedidoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DTOs.PedidoDto>>> ObterTodos()
    {
        try
        {
            _logger.LogInformation("Buscando todos os pedidos");
            var pedidos = await _service.ObterTodosAsync();
            return Ok(pedidos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar pedidos");
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Obtém um pedido por ID
    /// </summary>
    /// <param name="id">ID do pedido</param>
    /// <returns>Pedido encontrado</returns>
    /// <response code="200">Retorna o pedido</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DTOs.PedidoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DTOs.PedidoDto>> ObterPorId(int id)
    {
        try
        {
            _logger.LogInformation("Buscando pedido com ID: {Id}", id);
            var pedido = await _service.ObterPorIdAsync(id);

            if (pedido == null)
            {
                _logger.LogWarning("Pedido com ID {Id} não encontrado", id);
                return NotFound(new { message = $"Pedido com ID {id} não encontrado" });
            }

            return Ok(pedido);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar pedido com ID: {Id}", id);
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Obtém todos os pedidos de um restaurante específico
    /// </summary>
    /// <param name="restauranteId">ID do restaurante</param>
    /// <returns>Lista de pedidos do restaurante</returns>
    /// <response code="200">Retorna a lista de pedidos</response>
    [HttpGet("restaurante/{restauranteId}")]
    [ProducesResponseType(typeof(IEnumerable<DTOs.PedidoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DTOs.PedidoDto>>> ObterPorRestaurante(int restauranteId)
    {
        try
        {
            _logger.LogInformation("Buscando pedidos do restaurante com ID: {RestauranteId}", restauranteId);
            var pedidos = await _service.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(pedidos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar pedidos do restaurante com ID: {RestauranteId}", restauranteId);
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }
}
