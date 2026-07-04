using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class CuentaBancariaRepository : ICuentaBancariaRepository
{
    private readonly SwapFXDbContext _context;
    public CuentaBancariaRepository(SwapFXDbContext context) { _context = context; }

    public async Task<IEnumerable<CuentaBancaria>> GetByUsuarioAsync(int usuarioId)
        => await _context.CuentaBancaria
            .Where(c => c.UsuarioId == usuarioId && c.IsActive == true)
            .ToListAsync();

    public async Task<CuentaBancaria> AddAsync(CuentaBancaria cuenta)
    {
        _context.CuentaBancaria.Add(cuenta);
        await _context.SaveChangesAsync();
        return cuenta;
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _context.CuentaBancaria.FindAsync(id);
        if (c != null) { c.IsActive = false; await _context.SaveChangesAsync(); }
    }
}
