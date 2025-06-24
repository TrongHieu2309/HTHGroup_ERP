using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Section>> GetAllSectionsAsync();
        Task<Section?> GetSectionByIdAsync(int id);
        Task<Section> AddSectionAsync(Section entity);
        Task<Section?> UpdateSectionAsync(int id, Section entity);
        Task<bool> DeleteSectionAsync(int id);
    }
}
