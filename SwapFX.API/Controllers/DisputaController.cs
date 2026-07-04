using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DisputaController : ControllerBase
{
    private readonly IDisputaService _disputas;
    public DisputaController(IDisputaService disputas) { _disputas = disputas; }

    private int GetUsuarioId() => int.Parse(User.FindFirst("UsuarioId")!.Value);

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearDisputaDTO dto)
    {
        var result = await _disputas.CrearAsync(GetUsuarioId(), dto);
        return result.Exito ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Listar()
    {
        var result = await _disputas.ListarAsync();
        return Ok(result);
    }

    [HttpPut("resolver")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Resolver([FromBody] ResolverDisputaDTO dto)
    {
        var result = await _disputas.ResolverAsync(GetUsuarioId(), dto);
        return result.Exito ? Ok(result) : BadRequest(result);
    }
}
