namespace SwapFX.CORE.Core.DTOs;
public class OfertaListDTO
{
    public int Id { get; set; }
    public string? Tipo { get; set; }
    public string? MonedaOrigen { get; set; }
    public string? MonedaDestino { get; set; }
    public decimal? Monto { get; set; }
    public decimal? TipoCambio { get; set; }
    public string? Estado { get; set; }
    public string? Notas { get; set; }
    public DateTime? FechaPublicacion { get; set; }
    public DateTime? FechaExpiracion { get; set; }
    public string? UsuarioNombre { get; set; }
    public int? UsuarioId { get; set; }
}
public class CreateOfertaDTO
{
    public string Tipo { get; set; } = string.Empty;
    public int MonedaOrigenId { get; set; }
    public int MonedaDestinoId { get; set; }
    public decimal Monto { get; set; }
    public decimal TipoCambio { get; set; }
    public int ValidezHoras { get; set; } = 24;
    public string? Notas { get; set; }
}
public class UpdateOfertaDTO
{
    public int Id { get; set; }
    public decimal Monto { get; set; }
    public decimal TipoCambio { get; set; }
    public string? Notas { get; set; }
}
