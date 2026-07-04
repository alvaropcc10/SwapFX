namespace SwapFX.CORE.Core.DTOs;
public class CuentaBancariaListDTO
{
    public int Id { get; set; }
    public string? Banco { get; set; }
    public string? Titular { get; set; }
    public string? TipoCuenta { get; set; }
    public string? NumeroCuenta { get; set; }
    public string? Cci { get; set; }
    public string? Moneda { get; set; }
    public bool? EsPrincipal { get; set; }
}
public class CrearCuentaBancariaDTO
{
    public string Banco { get; set; } = null!;
    public string Titular { get; set; } = null!;
    public string TipoCuenta { get; set; } = null!;
    public string NumeroCuenta { get; set; } = null!;
    public string? Cci { get; set; }
    public string Moneda { get; set; } = null!;
    public bool EsPrincipal { get; set; }
}
