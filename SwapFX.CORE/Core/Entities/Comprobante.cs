namespace SwapFX.CORE.Core.Entities;
public partial class Comprobante
{
    public int Id { get; set; }
    public int? TransaccionId { get; set; }
    public int? UsuarioId { get; set; }
    public string? NombreArchivo { get; set; }
    public string? RutaArchivo { get; set; }
    public string? FormatoArchivo { get; set; }
    public long? TamanoBytes { get; set; }
    public string? NumeroOperacion { get; set; }
    public DateTime? FechaTransferencia { get; set; }
    public DateTime? FechaSubida { get; set; }
    public virtual Transaccion? Transaccion { get; set; }
}
