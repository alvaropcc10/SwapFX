using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.CORE.Core.Services;
public class NotificacionService : INotificacionService
{
    private readonly INotificacionRepository _notificaciones;
    public NotificacionService(INotificacionRepository notificaciones) { _notificaciones = notificaciones; }

    public async Task<RespuestaApi<IEnumerable<NotificacionListDTO>>> ListarAsync(int usuarioId)
    {
        var lista = await _notificaciones.GetByUsuarioAsync(usuarioId);
        return RespuestaApi<IEnumerable<NotificacionListDTO>>.Ok(lista.Select(n => new NotificacionListDTO {
            Id = n.Id, Tipo = n.Tipo, Mensaje = n.Mensaje, Leida = n.Leida, FechaCreacion = n.FechaCreacion
        }));
    }

    public async Task<RespuestaApi<bool>> MarcarLeidaAsync(int notificacionId)
    {
        await _notificaciones.MarcarLeidaAsync(notificacionId);
        return RespuestaApi<bool>.Ok(true, "Notificación marcada como leída.");
    }
}
