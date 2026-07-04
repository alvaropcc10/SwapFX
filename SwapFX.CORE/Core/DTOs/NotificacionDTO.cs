namespace SwapFX.CORE.Core.DTOs;
public class NotificacionListDTO
{
    public int Id { get; set; }
    public string? Tipo { get; set; }
    public string? Mensaje { get; set; }
    public bool? Leida { get; set; }
    public DateTime? FechaCreacion { get; set; }
}
