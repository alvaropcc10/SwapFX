using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface INotificacionRepository
{
    Task<IEnumerable<Notificacion>> GetByUsuarioAsync(int usuarioId);
    Task MarcarLeidaAsync(int notificacionId);
    Task CrearAsync(int usuarioId, string tipo, string mensaje);
}
