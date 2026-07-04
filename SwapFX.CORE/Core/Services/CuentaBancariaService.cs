using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.CORE.Core.Services;
public class CuentaBancariaService : ICuentaBancariaService
{
    private readonly ICuentaBancariaRepository _cuentas;
    public CuentaBancariaService(ICuentaBancariaRepository cuentas) { _cuentas = cuentas; }

    public async Task<RespuestaApi<IEnumerable<CuentaBancariaListDTO>>> ListarAsync(int usuarioId)
    {
        var lista = await _cuentas.GetByUsuarioAsync(usuarioId);
        return RespuestaApi<IEnumerable<CuentaBancariaListDTO>>.Ok(lista.Select(c => new CuentaBancariaListDTO {
            Id = c.Id, Banco = c.Banco, Titular = c.Titular, TipoCuenta = c.TipoCuenta,
            NumeroCuenta = c.NumeroCuenta, Cci = c.Cci, Moneda = c.Moneda, EsPrincipal = c.EsPrincipal
        }));
    }

    public async Task<RespuestaApi<bool>> CrearAsync(int usuarioId, CrearCuentaBancariaDTO dto)
    {
        await _cuentas.AddAsync(new CuentaBancaria {
            UsuarioId = usuarioId, Banco = dto.Banco, Titular = dto.Titular,
            TipoCuenta = dto.TipoCuenta, NumeroCuenta = dto.NumeroCuenta,
            Cci = dto.Cci, Moneda = dto.Moneda, EsPrincipal = dto.EsPrincipal, IsActive = true
        });
        return RespuestaApi<bool>.Ok(true, "Cuenta bancaria registrada.");
    }

    public async Task<RespuestaApi<bool>> EliminarAsync(int id)
    {
        await _cuentas.DeleteAsync(id);
        return RespuestaApi<bool>.Ok(true, "Cuenta bancaria eliminada.");
    }
}
