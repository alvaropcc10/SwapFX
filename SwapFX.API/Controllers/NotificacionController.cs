using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NotificacionController : ControllerBase
{
    private readonly INotificacionService _notificaciones;
    public NotificacionController(INotificacionService notificaciones) { _notificaciones = notificaciones; }

    private int GetUsuarioId() => int.Parse(User.FindFirst("UsuarioId")!.Value);

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var result = await _notificaciones.ListarAsync(GetUsuarioId());
        return Ok(result);
    }

    [HttpPut("{id}/leida")]
    public async Task<IActionResult> MarcarLeida(int id)
    {
        var result = await _notificaciones.MarcarLeidaAsync(id);
        return Ok(result);
    }
}
