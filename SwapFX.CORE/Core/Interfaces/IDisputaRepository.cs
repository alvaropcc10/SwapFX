using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Core.Interfaces;
public interface IDisputaRepository
{
    Task<Disputa> AddAsync(Disputa disputa);
    Task<Disputa?> GetByIdAsync(int id);
    Task<IEnumerable<Disputa>> GetAllAsync();
    Task UpdateAsync(Disputa disputa);
}
