using Fiap.Cloud.Games.Api.Models.Jogo;
using Fiap.Cloud.Games.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class JogoController : ControllerBase
  {
    readonly BaseLogger<UsuarioController> _logger;

    public JogoController(BaseLogger<UsuarioController> logger)
    {
      _logger = logger;
    }

    /// <summary>
    /// Retorna lista de Jogos
    /// </summary>
    /// <returns>Lista de Jogos</returns>
    /// <remarks></remarks>
    /// <response code="200">Lista de Todos os Jogos Encontrados</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(string), 200)]
    public IActionResult Get(
      [FromQuery] bool? ativado,
      [FromQuery] int offSet = 0,
      [FromQuery] int limit = 50)
    {
      _logger.LogInformation("Buscando Jogos");
      return Ok("Lista de Jogos Encontrados Com Sucesso");
    }

    /// <summary>
    /// Retorna Um  
    /// </summary>
    /// <returns>Jogos</returns>
    /// <remarks></remarks>
    /// <response code="200">Jogo Encontrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(string), 200)]
    public IActionResult GetById([FromRoute] int id)
    {
      _logger.LogInformation("Buscando Jogo por ID");
      return Ok("Jogo Encontrado Com Sucesso");
    }

    /// <summary>
    /// Inclui um Jogo
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns></returns>
    /// <response code="200"></response>
    [HttpPost("")]
    [ProducesResponseType(typeof(string), 200)]
    [Authorize(Roles = "Administrador")]
    public IActionResult Post([FromBody] PostJogoRequestDto dto)
    {
      _logger.LogInformation("Cadastrando Novo Jogo");
      return Ok("Jogo Cadastrado Com Sucesso.");
    }

    /// <summary>
    /// Altera um Jogo
    /// </summary>
    /// <param name="id">Identificador do Jogo</param>
    /// <param name="put">Corpo com dados a serem modificados</param>
    /// <returns></returns>
    /// <response code="200"></response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(string), 200)]
    [Authorize(Roles = "Administrador")]
    public IActionResult Put([FromRoute] int id, PutJogoRequestDto put)
    {
      _logger.LogInformation("Alterando Jogo");
      return Ok("Jogo Atualizado Com Sucesso.");
    }
  }
}