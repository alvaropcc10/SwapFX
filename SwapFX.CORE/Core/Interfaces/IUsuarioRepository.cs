using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface IUsuarioRepository
{
    Task<Usuario?> SignIn(string email, string password);
    Task<int> SignUp(Usuario usuario);
}
