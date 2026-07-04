using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface ICuentaBancariaService
{
    Task<RespuestaApi<IEnumerable<CuentaBancariaListDTO>>> ListarAsync(int usuarioId);
    Task<RespuestaApi<bool>> CrearAsync(int usuarioId, CrearCuentaBancariaDTO dto);
    Task<RespuestaApi<bool>> EliminarAsync(int id);
}
