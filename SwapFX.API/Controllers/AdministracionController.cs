using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdministracionController : ControllerBase
{
    private readonly IAdminService _admin;
    public AdministracionController(IAdminService admin) { _admin = admin; }

    private int GetUsuarioId() => int.Parse(User.FindFirst("UsuarioId")!.Value);

    [HttpGet("usuarios")]
    public async Task<IActionResult> ListarUsuarios()
    {
        var result = await _admin.ListarUsuariosAsync();
        return Ok(result);
    }

    [HttpPut("usuarios/estado")]
    public async Task<IActionResult> CambiarEstado([FromBody] CambiarEstadoUsuarioDTO dto)
    {
        var result = await _admin.CambiarEstadoUsuarioAsync(dto);
        return result.Exito ? Ok(result) : BadRequest(result);
    }

    [HttpPut("usuarios/validar-identidad")]
    public async Task<IActionResult> ValidarIdentidad([FromBody] ValidarIdentidadDTO dto)
    {
        var result = await _admin.ValidarIdentidadAsync(dto.UsuarioId);
        return result.Exito ? Ok(result) : BadRequest(result);
    }

    [HttpGet("transacciones")]
    public async Task<IActionResult> ListarTransacciones()
    {
        var result = await _admin.ListarTodasTransaccionesAsync();
        return Ok(result);
    }
}
