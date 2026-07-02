using SwapFX.CORE.Core.DTOs;
namespace SwapFX.CORE.Core.Interfaces;
public interface IUsuarioService
{
    Task<UsuarioListDTO?> SignIn(UsuarioSignInDTO dto);
    Task<int> SignUp(UsuarioSignUpDTO dto);
}
