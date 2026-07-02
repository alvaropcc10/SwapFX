using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly SwapFXDbContext _context;
    public UsuarioRepository(SwapFXDbContext context)
    {
        _context = context;
    }
    public async Task<Usuario?> SignIn(string email, string password)
    {
        return await _context.Usuario
            .Where(u => u.Email == email && u.Password == password && u.IsActive == true)
            .FirstOrDefaultAsync();
    }
    public async Task<int> SignUp(Usuario usuario)
    {
        var existe = await _context.Usuario.AnyAsync(u => u.Email == usuario.Email);
        if (existe) return 0;
        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario.Id;
    }
}
