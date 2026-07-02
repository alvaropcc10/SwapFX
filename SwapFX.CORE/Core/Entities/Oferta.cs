namespace SwapFX.CORE.Core.Entities;
public partial class Oferta
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public string? Tipo { get; set; }
    public int? MonedaOrigenId { get; set; }
    public int? MonedaDestinoId { get; set; }
    public decimal? Monto { get; set; }
    public decimal? TipoCambio { get; set; }
    public DateTime? FechaPublicacion { get; set; }
    public DateTime? FechaExpiracion { get; set; }
    public string? Estado { get; set; }
    public string? Notas { get; set; }
    public bool? IsActive { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public virtual Moneda? MonedaOrigen { get; set; }
    public virtual Moneda? MonedaDestino { get; set; }
    public virtual ICollection<Transaccion> TransaccionesCompra { get; set; } = new List<Transaccion>();
    public virtual ICollection<Transaccion> TransaccionesVenta { get; set; } = new List<Transaccion>();
}
