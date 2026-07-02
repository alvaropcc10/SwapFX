using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface IOfertaRepository
{
    Task<IEnumerable<Oferta>> GetOfertas(string? tipo, int? monedaOrigenId, int? monedaDestinoId);
    Task<Oferta?> GetOfertaById(int id);
    Task<int> CreateOferta(Oferta oferta);
    Task UpdateOferta(Oferta oferta);
    Task DeleteOferta(int id);
}
