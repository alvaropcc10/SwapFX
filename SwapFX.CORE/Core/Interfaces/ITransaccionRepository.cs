using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface ITransaccionRepository
{
    Task<Transaccion?> GetByIdAsync(int id);
    Task<IEnumerable<Transaccion>> GetByUsuarioAsync(int usuarioId);
    Task<Transaccion> AddAsync(Transaccion transaccion);
    Task UpdateAsync(Transaccion transaccion);
    Task AddBitacoraAsync(BitacoraTransaccion bitacora);
    Task AddComprobanteAsync(Comprobante comprobante);
}
