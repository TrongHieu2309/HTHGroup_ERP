using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Core.Entities;
using ERP.Core.Interfaces;

namespace ERP.Application.Services
{
    public class AuthoriseService(IAuthoriseRepository repository) : IAuthoriseService
    {
        public async Task<IEnumerable<AuthoriseDto>> GetAllAsync()
        {
            var list = await repository.GetAllAsync();
            return list.Select(a => new AuthoriseDto
            {
                MaVaiTro = a.MaVaiTro,
                MaQuyen = a.MaQuyen,
                TenQuyen = a.Authorisation?.TenQuyen,
                HanhDong = a.HanhDong
            });
        }

        public async Task<AuthoriseDto?> GetByIdAsync(string maVaiTro, int maQuyen)
        {
            var a = await repository.GetByIdAsync(maVaiTro, maQuyen);
            return a == null ? null : new AuthoriseDto
            {
                MaVaiTro = a.MaVaiTro,
                MaQuyen = a.MaQuyen,
                TenQuyen = a.Authorisation?.TenQuyen,
                HanhDong = a.HanhDong
            };
        }

        public async Task<AuthoriseDto> CreateAsync(AuthoriseInputDto input)
        {
            var entity = new Authorise
            {
                MaVaiTro = input.MaVaiTro,
                MaQuyen = input.MaQuyen,
                HanhDong = input.HanhDong
            };

            var created = await repository.AddAsync(entity);

            return new AuthoriseDto
            {
                MaVaiTro = created.MaVaiTro,
                MaQuyen = created.MaQuyen,
                HanhDong = created.HanhDong
            };
        }

        public async Task<AuthoriseDto?> UpdateAsync(string maVaiTro, int maQuyen, AuthoriseInputDto input)
        {
            var entity = new Authorise
            {
                MaVaiTro = input.MaVaiTro,
                MaQuyen = input.MaQuyen,
                HanhDong = input.HanhDong
            };

            var updated = await repository.UpdateAsync(maVaiTro, maQuyen, entity);
            if (updated == null) return null;

            return new AuthoriseDto
            {
                MaVaiTro = updated.MaVaiTro,
                MaQuyen = updated.MaQuyen,
                HanhDong = updated.HanhDong
            };
        }

        public async Task<bool> DeleteAsync(string maVaiTro, int maQuyen)
        {
            return await repository.DeleteAsync(maVaiTro, maQuyen);
        }
    }
}
