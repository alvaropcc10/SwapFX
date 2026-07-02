namespace SwapFX.CORE.Core.DTOs;
public class UsuarioListDTO
{
    public int Id { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Email { get; set; }
    public string? Tipo { get; set; }
    public string Token { get; set; } = string.Empty;
}
public class UsuarioSignInDTO
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class UsuarioSignUpDTO
{
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string? Dni { get; set; }
    public string? Telefono { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
