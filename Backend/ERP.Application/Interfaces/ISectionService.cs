using ERP.Application.DTOs;

namespace ERP.Application.Interfaces
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionDto>> GetAllSectionsAsync();
        Task<SectionDto?> GetSectionByIdAsync(int id);
        Task<SectionDto> CreateSectionAsync(SectionInputDto input);
        Task<SectionDto?> UpdateSectionAsync(int id, SectionInputDto input);
        Task<bool> DeleteSectionAsync(int id);
    }
}
