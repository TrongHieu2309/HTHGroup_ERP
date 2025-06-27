using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PHUCAP_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetAllowanceDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(pc => pc.MaPC, pc => $"{pc.TenPhuCap}");
        }

        // Lấy danh sách phụ cấp
        public async Task<List<AllowanceDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Allowance");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AllowanceDto>>(json) ?? new List<AllowanceDto>();
            }
            return new List<AllowanceDto>();
        }

        // Lấy phụ cấp theo ID
        public async Task<AllowanceDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Allowance/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AllowanceDto>(json);
            }
            return null;
        }

        // Thêm phụ cấp
        public async Task<string> CreateAsync(AllowanceInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/Allowance", content);
            return response.IsSuccessStatusCode
                ? "Thêm phụ cấp thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật phụ cấp
        public async Task<string> UpdateAsync(int id, AllowanceInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/Allowance/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật phụ cấp thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa phụ cấp
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Allowance/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa phụ cấp thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
