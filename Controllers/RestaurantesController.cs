using iFoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace iFoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class RestaurantesController : ControllerBase
{
    private readonly IRestauranteService _service;
    private readonly ILogger<RestaurantesController> _logger;

    public RestaurantesController(IRestauranteService service, ILogger<RestaurantesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Obtém todos os restaurantes ativos
    /// </summary>
    /// <returns>Lista de restaurantes</returns>
    /// <response code="200">Retorna a lista de restaurantes</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DTOs.RestauranteDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DTOs.RestauranteDto>>> ObterTodos()
    {
        try
        {
            _logger.LogInformation("Buscando todos os restaurantes");
            var restaurantes = await _service.ObterTodosAsync();
            return Ok(restaurantes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar restaurantes");
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }

    /// <summary>
    /// Obtém um restaurante por ID
    /// </summary>
    /// <param name="id">ID do restaurante</param>
    /// <returns>Restaurante encontrado</returns>
    /// <response code="200">Retorna o restaurante</response>
    /// <response code="404">Restaurante não encontrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DTOs.RestauranteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DTOs.RestauranteDto>> ObterPorId(int id)
    {
        try
        {
            _logger.LogInformation("Buscando restaurante com ID: {Id}", id);
            var restaurante = await _service.ObterPorIdAsync(id);

            if (restaurante == null)
            {
                _logger.LogWarning("Restaurante com ID {Id} não encontrado", id);
                return NotFound(new { message = $"Restaurante com ID {id} não encontrado" });
            }

            return Ok(restaurante);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar restaurante com ID: {Id}", id);
            return StatusCode(500, new { message = "Erro interno do servidor" });
        }
    }
}
