using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface IEducationLevelService
    {
        Task<IEnumerable<EducationLevelDto>> GetAllAsync();
        Task<EducationLevelDto?> GetByIdAsync(int id);
        Task<EducationLevelDto> AddAsync(EducationLevelInputDto dto);
        Task<EducationLevelDto?> UpdateAsync(int id, EducationLevelInputDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
