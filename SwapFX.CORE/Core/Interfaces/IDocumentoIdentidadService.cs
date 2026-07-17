using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface IDocumentoIdentidadService
{
    Task<RespuestaApi<bool>> SubirAsync(int usuarioId, SubirDocumentoDTO dto);
}
