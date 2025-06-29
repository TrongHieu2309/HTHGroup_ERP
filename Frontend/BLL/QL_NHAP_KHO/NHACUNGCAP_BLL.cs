using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class NHACUNGCAP_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetProviderDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(ncc => ncc.MaNCC, ncc => $"{ncc.TenNCC}");
        }

        // Lấy danh sách tất cả nhà cung cấp
        public async Task<List<ProviderDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/providers");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProviderDto>>(json) ?? new List<ProviderDto>();
            }

            return new List<ProviderDto>();
        }

        // Lấy nhà cung cấp theo ID
        public async Task<ProviderDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/providers/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProviderDto>(json);
            }

            return null;
        }

        // Tạo mới nhà cung cấp
        public async Task<string> CreateAsync(ProviderInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/providers", content);

            return response.IsSuccessStatusCode
                ? "Thêm nhà cung cấp thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật nhà cung cấp
        public async Task<string> UpdateAsync(int id, ProviderInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/providers/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật nhà cung cấp thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa nhà cung cấp
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/providers/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa nhà cung cấp thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
