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
    public class QUYEN_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy danh sách quyền dưới dạng Dictionary
        public async Task<Dictionary<int, string>> GetAuthorisationDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(q => q.MaQuyen, q => q.TenQuyen);
        }

        // Lấy toàn bộ quyền
        public async Task<List<AuthorisationDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Authorisation");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AuthorisationDto>>(json);
            }
            return new List<AuthorisationDto>();
        }

        // Lấy quyền theo ID
        public async Task<AuthorisationDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Authorisation/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthorisationDto>(json);
            }
            return null;
        }

        // Thêm mới quyền
        public async Task<string> AddAsync(AuthorisationInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/Authorisation", content);
            return response.IsSuccessStatusCode
                ? "Thêm quyền thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật quyền
        public async Task<string> UpdateAsync(int id, AuthorisationInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/Authorisation/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật quyền thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa quyền
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Authorisation/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa quyền thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
