using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class DisputaRepository : IDisputaRepository
{
    private readonly SwapFXDbContext _context;
    public DisputaRepository(SwapFXDbContext context) { _context = context; }

    public async Task<Disputa> AddAsync(Disputa disputa)
    {
        _context.Disputa.Add(disputa);
        await _context.SaveChangesAsync();
        return disputa;
    }

    public async Task<Disputa?> GetByIdAsync(int id)
        => await _context.Disputa
            .Include(d => d.Transaccion)
            .FirstOrDefaultAsync(d => d.Id == id);

    public async Task<IEnumerable<Disputa>> GetAllAsync()
        => await _context.Disputa
            .Include(d => d.Transaccion)
            .OrderByDescending(d => d.FechaReporte)
            .ToListAsync();

    public async Task UpdateAsync(Disputa disputa)
    {
        _context.Disputa.Update(disputa);
        await _context.SaveChangesAsync();
    }
}
