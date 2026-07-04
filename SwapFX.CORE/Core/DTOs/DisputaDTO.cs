namespace SwapFX.CORE.Core.DTOs;
public class DisputaListDTO
{
    public int Id { get; set; }
    public int? TransaccionId { get; set; }
    public string? Motivo { get; set; }
    public string? Descripcion { get; set; }
    public string? Estado { get; set; }
    public string? Resolucion { get; set; }
    public DateTime? FechaReporte { get; set; }
    public string? NombreReportante { get; set; }
}
public class CrearDisputaDTO
{
    public int TransaccionId { get; set; }
    public string Motivo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
}
public class ResolverDisputaDTO
{
    public int DisputaId { get; set; }
    public string Resolucion { get; set; } = null!;
    public string EstadoFinal { get; set; } = null!;
}
