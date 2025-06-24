using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IEducationLevelRepository
    {
        Task<IEnumerable<EducationLevel>> GetAllAsync();
        Task<EducationLevel?> GetByIdAsync(int id);
        Task<EducationLevel> AddAsync(EducationLevel entity);
        Task<EducationLevel?> UpdateAsync(int id, EducationLevel entity);
        Task<bool> DeleteAsync(int id);
    }
}
