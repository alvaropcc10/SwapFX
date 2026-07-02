namespace SwapFX.CORE.Core.Entities;
public partial class CuentaBancaria
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public string? Banco { get; set; }
    public string? Titular { get; set; }
    public string? TipoCuenta { get; set; }
    public string? NumeroCuenta { get; set; }
    public string? Cci { get; set; }
    public string? Moneda { get; set; }
    public bool? EsPrincipal { get; set; }
    public bool? IsActive { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
