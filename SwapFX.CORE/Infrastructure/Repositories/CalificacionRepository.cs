using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class CalificacionRepository : ICalificacionRepository
{
    private readonly SwapFXDbContext _context;
    public CalificacionRepository(SwapFXDbContext context) { _context = context; }

    public async Task<bool> ExisteCalificacionAsync(int transaccionId, int calificadorId)
        => await _context.Calificacion.AnyAsync(c => c.TransaccionId == transaccionId && c.UsuarioCalificadorId == calificadorId);

    public async Task AddAsync(Calificacion calificacion)
    {
        _context.Calificacion.Add(calificacion);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Calificacion>> GetByUsuarioCalificadoAsync(int usuarioId)
        => await _context.Calificacion
            .Include(c => c.UsuarioCalificador)
            .Where(c => c.UsuarioCalificadoId == usuarioId)
            .OrderByDescending(c => c.FechaCalificacion)
            .ToListAsync();

    public async Task<double> GetPromedioAsync(int usuarioId)
    {
        var calificaciones = await _context.Calificacion
            .Where(c => c.UsuarioCalificadoId == usuarioId && c.Puntuacion.HasValue)
            .ToListAsync();
        return calificaciones.Any() ? calificaciones.Average(c => c.Puntuacion!.Value) : 0;
    }
}
