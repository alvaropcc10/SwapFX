using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CalificacionController : ControllerBase
{
    private readonly ICalificacionService _calificaciones;
    public CalificacionController(ICalificacionService calificaciones) { _calificaciones = calificaciones; }

    private int GetUsuarioId() => int.Parse(User.FindFirst("UsuarioId")!.Value);

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearCalificacionDTO dto)
    {
        var result = await _calificaciones.CrearAsync(GetUsuarioId(), dto);
        return result.Exito ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> ListarPorUsuario(int usuarioId)
    {
        var result = await _calificaciones.ListarPorUsuarioAsync(usuarioId);
        return Ok(result);
    }
}
