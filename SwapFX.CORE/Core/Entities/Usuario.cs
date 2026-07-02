namespace SwapFX.CORE.Core.Entities;
public partial class Usuario
{
    public int Id { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Dni { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool? IsActive { get; set; }
    public string? Tipo { get; set; }
    public DateOnly? FechaRegistro { get; set; }
    public bool? IdentidadValidada { get; set; }
    public virtual ICollection<Oferta> Ofertas { get; set; } = new List<Oferta>();
    public virtual ICollection<CuentaBancaria> CuentasBancarias { get; set; } = new List<CuentaBancaria>();
    public virtual ICollection<Calificacion> CalificacionesDadas { get; set; } = new List<Calificacion>();
    public virtual ICollection<Calificacion> CalificacionesRecibidas { get; set; } = new List<Calificacion>();
}
