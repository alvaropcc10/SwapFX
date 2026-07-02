namespace SwapFX.CORE.Core.Entities;
public partial class Calificacion
{
    public int Id { get; set; }
    public int? TransaccionId { get; set; }
    public int? UsuarioCalificadorId { get; set; }
    public int? UsuarioCalificadoId { get; set; }
    public int? Puntuacion { get; set; }
    public string? Comentario { get; set; }
    public DateTime? FechaCalificacion { get; set; }
    public virtual Transaccion? Transaccion { get; set; }
    public virtual Usuario? UsuarioCalificador { get; set; }
    public virtual Usuario? UsuarioCalificado { get; set; }
}
