using SwapFX.CORE.Core.Entities;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Infrastructure.Data;
namespace SwapFX.CORE.Infrastructure.Repositories;
public class DocumentoIdentidadRepository : IDocumentoIdentidadRepository
{
    private readonly SwapFXDbContext _context;
    public DocumentoIdentidadRepository(SwapFXDbContext context) { _context = context; }

    public async Task<DocumentoIdentidad> AddAsync(DocumentoIdentidad documento)
    {
        _context.DocumentoIdentidad.Add(documento);
        await _context.SaveChangesAsync();
        return documento;
    }
}
