using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface INotificacionService
{
    Task<RespuestaApi<IEnumerable<NotificacionListDTO>>> ListarAsync(int usuarioId);
    Task<RespuestaApi<bool>> MarcarLeidaAsync(int notificacionId);
}
