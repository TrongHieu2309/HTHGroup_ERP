using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IAuthoriseRepository
    {
        Task<IEnumerable<Authorise>> GetAllAsync();
        Task<Authorise?> GetByIdAsync(string maVaiTro, int maQuyen);
        Task<Authorise> AddAsync(Authorise entity);
        Task<Authorise?> UpdateAsync(string maVaiTro, int maQuyen, Authorise entity);
        Task<bool> DeleteAsync(string maVaiTro, int maQuyen);
    }
}
