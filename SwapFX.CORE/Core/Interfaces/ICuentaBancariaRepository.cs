using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface ICuentaBancariaRepository
{
    Task<IEnumerable<CuentaBancaria>> GetByUsuarioAsync(int usuarioId);
    Task<CuentaBancaria> AddAsync(CuentaBancaria cuenta);
    Task DeleteAsync(int id);
}
