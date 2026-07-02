namespace SwapFX.CORE.Core.Entities;
public partial class Moneda
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre { get; set; }
    public string? Simbolo { get; set; }
    public bool? IsActive { get; set; }
    public virtual ICollection<Oferta> OfertasOrigen { get; set; } = new List<Oferta>();
    public virtual ICollection<Oferta> OfertasDestino { get; set; } = new List<Oferta>();
}
