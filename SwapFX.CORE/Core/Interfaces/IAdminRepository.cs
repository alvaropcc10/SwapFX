using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface IAdminRepository
{
    Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    Task<Usuario?> GetUsuarioByIdAsync(int id);
    Task UpdateUsuarioAsync(Usuario usuario);
    Task<IEnumerable<Transaccion>> GetAllTransaccionesAsync();
}
