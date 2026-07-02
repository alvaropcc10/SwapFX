namespace SwapFX.CORE.Core.Entities;
public partial class Transaccion
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public int? OfertaCompraId { get; set; }
    public int? OfertaVentaId { get; set; }
    public int? CompradorId { get; set; }
    public int? VendedorId { get; set; }
    public decimal? MontoOrigen { get; set; }
    public decimal? MontoDestino { get; set; }
    public decimal? TipoCambioAplicado { get; set; }
    public string? EstadoActual { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFinalizacion { get; set; }
    public bool? IsActive { get; set; }
    public virtual Oferta? OfertaCompra { get; set; }
    public virtual Oferta? OfertaVenta { get; set; }
    public virtual Usuario? Comprador { get; set; }
    public virtual Usuario? Vendedor { get; set; }
    public virtual ICollection<EstadoTransaccion> Estados { get; set; } = new List<EstadoTransaccion>();
    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
    public virtual ICollection<Disputa> Disputas { get; set; } = new List<Disputa>();
    public virtual ICollection<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
}
