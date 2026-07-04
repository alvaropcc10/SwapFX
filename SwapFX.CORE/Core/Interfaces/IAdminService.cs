using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface IAdminService
{
    Task<RespuestaApi<IEnumerable<UsuarioAdminListDTO>>> ListarUsuariosAsync();
    Task<RespuestaApi<bool>> CambiarEstadoUsuarioAsync(CambiarEstadoUsuarioDTO dto);
    Task<RespuestaApi<IEnumerable<TransaccionListDTO>>> ListarTodasTransaccionesAsync();
}
