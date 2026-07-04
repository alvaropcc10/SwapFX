namespace SwapFX.CORE.Core.DTOs;
public class CalificacionListDTO
{
    public int Id { get; set; }
    public int? Puntuacion { get; set; }
    public string? Comentario { get; set; }
    public DateTime? FechaCalificacion { get; set; }
    public string? NombreCalificador { get; set; }
}
public class CrearCalificacionDTO
{
    public int TransaccionId { get; set; }
    public int UsuarioCalificadoId { get; set; }
    public int Puntuacion { get; set; }
    public string? Comentario { get; set; }
}
