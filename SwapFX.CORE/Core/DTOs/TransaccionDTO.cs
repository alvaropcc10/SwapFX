using SwapFX.CORE.Core.Common;
namespace SwapFX.CORE.Core.DTOs;
public class TransaccionListDTO
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? EstadoActual { get; set; }
    public decimal? MontoOrigen { get; set; }
    public decimal? MontoDestino { get; set; }
    public decimal? TipoCambioAplicado { get; set; }
    public DateTime? FechaInicio { get; set; }
    public string? MonedaOrigen { get; set; }
    public string? MonedaDestino { get; set; }
    public string? NombreComprador { get; set; }
    public string? NombreVendedor { get; set; }
    public int? CompradorId { get; set; }
    public int? VendedorId { get; set; }
}
public class IniciarTransaccionDTO
{
    public int OfertaId { get; set; }
}
public class BitacoraTransaccionDTO
{
    public string EstadoAnterior { get; set; } = null!;
    public string EstadoNuevo { get; set; } = null!;
    public string? Comentario { get; set; }
    public DateTime FechaCambio { get; set; }
}
public class TransaccionDetalleDTO : TransaccionListDTO
{
    public List<BitacoraTransaccionDTO> Bitacora { get; set; } = new();
    public List<ComprobanteListDTO> Comprobantes { get; set; } = new();
}
public class ReportarComprobanteDTO
{
    public int TransaccionId { get; set; }
    public string NombreArchivo { get; set; } = null!;
    public string RutaArchivo { get; set; } = null!;
    public string FormatoArchivo { get; set; } = null!;
    public string? NumeroOperacion { get; set; }
    public DateTime FechaTransferencia { get; set; }
}
public class ComprobanteListDTO
{
    public int Id { get; set; }
    public string? NombreArchivo { get; set; }
    public string? RutaArchivo { get; set; }
    public string? FormatoArchivo { get; set; }
    public string? NumeroOperacion { get; set; }
    public DateTime? FechaTransferencia { get; set; }
    public DateTime? FechaSubida { get; set; }
}
