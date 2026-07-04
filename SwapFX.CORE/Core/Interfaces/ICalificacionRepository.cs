using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface ICalificacionRepository
{
    Task<bool> ExisteCalificacionAsync(int transaccionId, int calificadorId);
    Task AddAsync(Calificacion calificacion);
    Task<IEnumerable<Calificacion>> GetByUsuarioCalificadoAsync(int usuarioId);
    Task<double> GetPromedioAsync(int usuarioId);
}
