using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class VAITRO_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy danh sách vai trò dưới dạng Dictionary
        public async Task<Dictionary<string, string>> GetRolesDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(r => r.MaVaiTro, r => r.TenVaiTro);
        }

        // Lấy tất cả vai trò
        public async Task<List<RolesDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Roles");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RolesDto>>(json);
            }
            return new List<RolesDto>();
        }

        // Lấy vai trò theo mã
        public async Task<RolesDto?> GetByIdAsync(string maVaiTro)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Roles/{maVaiTro}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RolesDto>(json);
            }
            return null;
        }

        // Thêm mới vai trò
        public async Task<string> AddAsync(RolesInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/Roles", content);
            return response.IsSuccessStatusCode
                ? "Thêm vai trò thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật vai trò
        public async Task<string> UpdateAsync(string maVaiTro, RolesInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/Roles/{maVaiTro}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật vai trò thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa vai trò
        public async Task<string> DeleteAsync(string maVaiTro)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Roles/{maVaiTro}");
            return response.IsSuccessStatusCode
                ? "Xóa vai trò thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
