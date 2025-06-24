using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface IAuthorisationRepository
    {
        Task<IEnumerable<Authorisation>> GetAllAsync();
        Task<Authorisation?> GetByIdAsync(int id);
        Task<Authorisation> AddAsync(Authorisation entity);
        Task<Authorisation?> UpdateAsync(int id, Authorisation entity);
        Task<bool> DeleteAsync(int id);
    }
}
