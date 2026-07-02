namespace SwapFX.CORE.Core.Entities;
public partial class Disputa
{
    public int Id { get; set; }
    public int? TransaccionId { get; set; }
    public int? UsuarioReportanteId { get; set; }
    public string? Motivo { get; set; }
    public string? Descripcion { get; set; }
    public string? Estado { get; set; }
    public string? Resolucion { get; set; }
    public DateTime? FechaReporte { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public int? AdminResolutorId { get; set; }
    public virtual Transaccion? Transaccion { get; set; }
}
