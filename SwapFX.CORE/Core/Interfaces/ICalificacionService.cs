using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface ICalificacionService
{
    Task<RespuestaApi<bool>> CrearAsync(int calificadorId, CrearCalificacionDTO dto);
    Task<RespuestaApi<IEnumerable<CalificacionListDTO>>> ListarPorUsuarioAsync(int usuarioId);
}
