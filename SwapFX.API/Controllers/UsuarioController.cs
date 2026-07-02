using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] UsuarioSignInDTO dto)
    {
        var usuario = await _usuarioService.SignIn(dto);
        if (usuario == null) return Unauthorized();
        return Ok(usuario);
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] UsuarioSignUpDTO dto)
    {
        var usuarioId = await _usuarioService.SignUp(dto);
        if (usuarioId == 0) return BadRequest("El correo ya esta registrado.");
        return Ok(usuarioId);
    }
}
