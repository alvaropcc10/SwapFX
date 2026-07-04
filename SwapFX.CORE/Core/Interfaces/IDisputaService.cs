using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface IDisputaService
{
    Task<RespuestaApi<bool>> CrearAsync(int usuarioId, CrearDisputaDTO dto);
    Task<RespuestaApi<IEnumerable<DisputaListDTO>>> ListarAsync();
    Task<RespuestaApi<bool>> ResolverAsync(int adminId, ResolverDisputaDTO dto);
}
