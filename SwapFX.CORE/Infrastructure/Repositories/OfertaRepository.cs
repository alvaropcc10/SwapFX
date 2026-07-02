using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class OfertaRepository : IOfertaRepository
{
    private readonly SwapFXDbContext _context;
    public OfertaRepository(SwapFXDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Oferta>> GetOfertas(string? tipo, int? monedaOrigenId, int? monedaDestinoId)
    {
        var query = _context.Oferta
            .Include(o => o.Usuario)
            .Include(o => o.MonedaOrigen)
            .Include(o => o.MonedaDestino)
            .Where(o => o.IsActive == true && o.Estado == "PUBLICADA");
        if (!string.IsNullOrEmpty(tipo)) query = query.Where(o => o.Tipo == tipo);
        if (monedaOrigenId.HasValue) query = query.Where(o => o.MonedaOrigenId == monedaOrigenId);
        if (monedaDestinoId.HasValue) query = query.Where(o => o.MonedaDestinoId == monedaDestinoId);
        return await query.OrderByDescending(o => o.TipoCambio).ToListAsync();
    }
    public async Task<Oferta?> GetOfertaById(int id)
    {
        return await _context.Oferta
            .Include(o => o.Usuario)
            .Include(o => o.MonedaOrigen)
            .Include(o => o.MonedaDestino)
            .FirstOrDefaultAsync(o => o.Id == id && o.IsActive == true);
    }
    public async Task<int> CreateOferta(Oferta oferta)
    {
        _context.Oferta.Add(oferta);
        await _context.SaveChangesAsync();
        return oferta.Id;
    }
    public async Task UpdateOferta(Oferta oferta)
    {
        _context.Oferta.Update(oferta);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteOferta(int id)
    {
        var oferta = await _context.Oferta.FindAsync(id);
        if (oferta != null) {
            oferta.IsActive = false;
            oferta.Estado = "ELIMINADA";
            await _context.SaveChangesAsync();
        }
    }
}
