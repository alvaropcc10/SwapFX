using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DocumentoIdentidadController : ControllerBase
{
    private readonly IDocumentoIdentidadService _documentos;
    public DocumentoIdentidadController(IDocumentoIdentidadService documentos) { _documentos = documentos; }

    private int GetUsuarioId() => int.Parse(User.FindFirst("UsuarioId")!.Value);

    [HttpPost]
    public async Task<IActionResult> Subir([FromBody] SubirDocumentoDTO dto)
    {
        var result = await _documentos.SubirAsync(GetUsuarioId(), dto);
        return result.Exito ? Ok(result) : BadRequest(result);
    }
}
