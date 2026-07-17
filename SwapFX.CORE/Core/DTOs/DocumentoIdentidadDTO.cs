namespace SwapFX.CORE.Core.DTOs;
public class SubirDocumentoDTO
{
    public string TipoDoc { get; set; } = null!;
    public string NumeroDoc { get; set; } = null!;
    public string RutaArchivo { get; set; } = null!;
    public string Estado { get; set; } = "Pendiente";
}
