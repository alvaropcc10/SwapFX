using SwapFX.CORE.Core.Common;
using SwapFX.CORE.Core.DTOs;
using SwapFX.CORE.Core.Interfaces;
namespace SwapFX.CORE.Core.Services;
public class AdminService : IAdminService
{
    private readonly IAdminRepository _admin;
    public AdminService(IAdminRepository admin) { _admin = admin; }

    public async Task<RespuestaApi<IEnumerable<UsuarioAdminListDTO>>> ListarUsuariosAsync()
    {
        var lista = await _admin.GetAllUsuariosAsync();
        return RespuestaApi<IEnumerable<UsuarioAdminListDTO>>.Ok(lista.Select(u => new UsuarioAdminListDTO {
            Id = u.Id, Nombres = u.Nombres, Apellidos = u.Apellidos, Email = u.Email,
            Tipo = u.Tipo, IsActive = u.IsActive, IdentidadValidada = u.IdentidadValidada,
            FechaRegistro = u.FechaRegistro
        }));
    }

    public async Task<RespuestaApi<bool>> CambiarEstadoUsuarioAsync(CambiarEstadoUsuarioDTO dto)
    {
        var u = await _admin.GetUsuarioByIdAsync(dto.UsuarioId);
        if (u == null) return RespuestaApi<bool>.Error("Usuario no encontrado.");
        u.IsActive = dto.IsActive;
        await _admin.UpdateUsuarioAsync(u);
        return RespuestaApi<bool>.Ok(true, dto.IsActive ? "Usuario habilitado." : "Usuario bloqueado.");
    }

    public async Task<RespuestaApi<bool>> ValidarIdentidadAsync(int usuarioId)
    {
        var u = await _admin.GetUsuarioByIdAsync(usuarioId);
        if (u == null) return RespuestaApi<bool>.Error("Usuario no encontrado.");
        u.IdentidadValidada = true;
        await _admin.UpdateUsuarioAsync(u);
        return RespuestaApi<bool>.Ok(true, "Identidad validada.");
    }

    public async Task<RespuestaApi<IEnumerable<TransaccionListDTO>>> ListarTodasTransaccionesAsync()
    {
        var lista = await _admin.GetAllTransaccionesAsync();
        return RespuestaApi<IEnumerable<TransaccionListDTO>>.Ok(lista.Select(t => new TransaccionListDTO {
            Id = t.Id, Codigo = t.Codigo, EstadoActual = t.EstadoActual,
            MontoOrigen = t.MontoOrigen, MontoDestino = t.MontoDestino,
            TipoCambioAplicado = t.TipoCambioAplicado, FechaInicio = t.FechaInicio,
            MonedaOrigen = t.OfertaCompra?.MonedaOrigen?.Codigo,
            NombreComprador = t.Comprador?.Nombres + " " + t.Comprador?.Apellidos,
            NombreVendedor = t.Vendedor?.Nombres + " " + t.Vendedor?.Apellidos,
            CompradorId = t.CompradorId, VendedorId = t.VendedorId
        }));
    }
}
