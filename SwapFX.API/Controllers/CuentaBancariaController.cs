using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CuentaBancariaController : ControllerBase
{
    private readonly ICuentaBancariaService _cuentas;
    public CuentaBancariaController(ICuentaBancariaService cuentas) { _cuentas = cuentas; }

    private int GetUsuarioId() => int.Parse(User.FindFirst("UsuarioId")!.Value);

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var result = await _cuentas.ListarAsync(GetUsuarioId());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearCuentaBancariaDTO dto)
    {
        var result = await _cuentas.CrearAsync(GetUsuarioId(), dto);
        return result.Exito ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var result = await _cuentas.EliminarAsync(id);
        return Ok(result);
    }
}
