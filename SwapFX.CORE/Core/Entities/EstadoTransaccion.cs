namespace SwapFX.CORE.Core.Entities;
public partial class EstadoTransaccion
{
    public int Id { get; set; }
    public int? TransaccionId { get; set; }
    public string? Estado { get; set; }
    public DateTime? FechaCambio { get; set; }
    public int? UsuarioResponsableId { get; set; }
    public string? Comentario { get; set; }
    public virtual Transaccion? Transaccion { get; set; }
}
