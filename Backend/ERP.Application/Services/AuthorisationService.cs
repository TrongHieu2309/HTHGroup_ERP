using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class AuthorisationService(IAuthorisationRepository repo) : IAuthorisationService
    {
        public async Task<IEnumerable<AuthorisationDto>> GetAllAsync()
        {
            var list = await repo.GetAllAsync();
            return list.Select(x => new AuthorisationDto
            {
                MaQuyen = x.MaQuyen,
                TenQuyen = x.TenQuyen
            });
        }

        public async Task<AuthorisationDto?> GetByIdAsync(int id)
        {
            var entity = await repo.GetByIdAsync(id);
            return entity is null ? null : new AuthorisationDto
            {
                MaQuyen = entity.MaQuyen,
                TenQuyen = entity.TenQuyen
            };
        }

        public async Task<AuthorisationDto> CreateAsync(AuthorisationInputDto input)
        {
            var entity = new Authorisation
            {
                TenQuyen = input.TenQuyen
            };

            var created = await repo.AddAsync(entity);

            return new AuthorisationDto
            {
                MaQuyen = created.MaQuyen,
                TenQuyen = created.TenQuyen
            };
        }

        public async Task<AuthorisationDto?> UpdateAsync(int id, AuthorisationInputDto input)
        {
            var updated = await repo.UpdateAsync(id, new Authorisation
            {
                TenQuyen = input.TenQuyen
            });

            return updated is null ? null : new AuthorisationDto
            {
                MaQuyen = updated.MaQuyen,
                TenQuyen = updated.TenQuyen
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
    }
}
