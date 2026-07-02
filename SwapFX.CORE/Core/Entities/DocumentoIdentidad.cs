namespace SwapFX.CORE.Core.Entities;
public partial class DocumentoIdentidad
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public string? TipoDoc { get; set; }
    public string? NumeroDoc { get; set; }
    public string? RutaArchivo { get; set; }
    public string? Estado { get; set; }
    public string? Observacion { get; set; }
    public DateTime? FechaSubida { get; set; }
    public DateTime? FechaRevision { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
