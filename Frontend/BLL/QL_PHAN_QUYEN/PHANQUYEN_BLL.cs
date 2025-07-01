using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class PHANQUYEN_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy tất cả phân quyền
        public async Task<List<AuthoriseDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Authorise");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AuthoriseDto>>(json) ?? new List<AuthoriseDto>();
            }

            return new List<AuthoriseDto>();
        }

        // Lấy phân quyền theo composite key (maVaiTro + maQuyen)
        public async Task<AuthoriseDto?> GetByIdAsync(string maVaiTro, int maQuyen)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Authorise/{maVaiTro}/{maQuyen}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthoriseDto>(json);
            }

            return null;
        }

        // Tạo mới phân quyền
        public async Task<string> CreateAsync(AuthoriseInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/Authorise", content);
            return response.IsSuccessStatusCode
                ? "Thêm phân quyền thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật phân quyền
        public async Task<string> UpdateAsync(string maVaiTro, int maQuyen, AuthoriseInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/Authorise/{maVaiTro}/{maQuyen}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật phân quyền thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa phân quyền
        public async Task<string> DeleteAsync(string maVaiTro, int maQuyen)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Authorise/{maVaiTro}/{maQuyen}");

            return response.IsSuccessStatusCode
                ? "Xóa phân quyền thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
