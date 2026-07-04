namespace SwapFX.CORE.Core.DTOs;
public class UsuarioAdminListDTO
{
    public int Id { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Email { get; set; }
    public string? Tipo { get; set; }
    public bool? IsActive { get; set; }
    public bool? IdentidadValidada { get; set; }
    public DateOnly? FechaRegistro { get; set; }
}
public class CambiarEstadoUsuarioDTO
{
    public int UsuarioId { get; set; }
    public bool IsActive { get; set; }
    public string? Motivo { get; set; }
}
