using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface IOfertaService
{
    Task<IEnumerable<OfertaListDTO>> GetOfertas(string? tipo, int? monedaOrigenId, int? monedaDestinoId);
    Task<OfertaListDTO?> GetOfertaById(int id);
    Task<int> CreateOferta(CreateOfertaDTO dto, int usuarioId);
    Task UpdateOferta(UpdateOfertaDTO dto);
    Task DeleteOferta(int id);
}
