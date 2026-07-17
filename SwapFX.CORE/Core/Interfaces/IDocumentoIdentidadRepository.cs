using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface IDocumentoIdentidadRepository
{
    Task<DocumentoIdentidad> AddAsync(DocumentoIdentidad documento);
}
