using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class TransaccionRepository : ITransaccionRepository
{
    private readonly SwapFXDbContext _context;
    public TransaccionRepository(SwapFXDbContext context) { _context = context; }

    public async Task<Transaccion?> GetByIdAsync(int id)
        => await _context.Transaccion
            .Include(t => t.OfertaCompra).ThenInclude(o => o!.MonedaOrigen)
            .Include(t => t.OfertaCompra).ThenInclude(o => o!.MonedaDestino)
            .Include(t => t.Comprador)
            .Include(t => t.Vendedor)
            .Include(t => t.Comprobantes)
            .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<IEnumerable<Transaccion>> GetByUsuarioAsync(int usuarioId)
        => await _context.Transaccion
            .Include(t => t.OfertaCompra).ThenInclude(o => o!.MonedaOrigen)
            .Include(t => t.OfertaCompra).ThenInclude(o => o!.MonedaDestino)
            .Include(t => t.Comprador)
            .Include(t => t.Vendedor)
            .Where(t => t.CompradorId == usuarioId || t.VendedorId == usuarioId)
            .OrderByDescending(t => t.FechaInicio)
            .ToListAsync();

    public async Task<Transaccion> AddAsync(Transaccion transaccion)
    {
        _context.Transaccion.Add(transaccion);
        await _context.SaveChangesAsync();
        return transaccion;
    }

    public async Task UpdateAsync(Transaccion transaccion)
    {
        _context.Transaccion.Update(transaccion);
        await _context.SaveChangesAsync();
    }

    public async Task AddBitacoraAsync(BitacoraTransaccion bitacora)
    {
        _context.BitacoraTransaccion.Add(bitacora);
        await _context.SaveChangesAsync();
    }

    public async Task AddComprobanteAsync(Comprobante comprobante)
    {
        _context.Comprobante.Add(comprobante);
        await _context.SaveChangesAsync();
    }
}
