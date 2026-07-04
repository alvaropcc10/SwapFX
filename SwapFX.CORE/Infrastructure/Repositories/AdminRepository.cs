using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class AdminRepository : IAdminRepository
{
    private readonly SwapFXDbContext _context;
    public AdminRepository(SwapFXDbContext context) { _context = context; }

    public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        => await _context.Usuario.OrderBy(u => u.Apellidos).ToListAsync();

    public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        => await _context.Usuario.FindAsync(id);

    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        _context.Usuario.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaccion>> GetAllTransaccionesAsync()
        => await _context.Transaccion
            .Include(t => t.Comprador)
            .Include(t => t.Vendedor)
            .Include(t => t.OfertaCompra).ThenInclude(o => o!.MonedaOrigen)
            .OrderByDescending(t => t.FechaInicio)
            .ToListAsync();
}
