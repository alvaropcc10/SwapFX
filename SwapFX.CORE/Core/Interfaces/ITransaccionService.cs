using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface ITransaccionService
{
    Task<RespuestaApi<TransaccionDetalleDTO>> IniciarAsync(int usuarioId, IniciarTransaccionDTO dto);
    Task<RespuestaApi<IEnumerable<TransaccionListDTO>>> ListarPorUsuarioAsync(int usuarioId);
    Task<RespuestaApi<TransaccionDetalleDTO>> ObtenerDetalleAsync(int transaccionId, int usuarioId);
    Task<RespuestaApi<bool>> ReportarComprobanteAsync(int usuarioId, ReportarComprobanteDTO dto);
    Task<RespuestaApi<bool>> ConfirmarPagoAsync(int transaccionId, int usuarioId);
    Task<RespuestaApi<bool>> CancelarAsync(int transaccionId, int usuarioId, string motivo);
}
