using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAN_SU
{
    public class BOPHAN_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetSectionDictionaryAsync() // lấy dữ liệu lên comboBox
        {
            var list = await GetAllSectionsAsync();
            return list.ToDictionary(bp => bp.MaBoPhan, bp => $"{bp.TenBoPhan}");
        }

        // Lấy tất cả bộ phận
        public async Task<List<SectionDto>> GetAllSectionsAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Section");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SectionDto>>(json);
            }

            return new List<SectionDto>();
        }

        // Lấy 1 bộ phận theo ID
        public async Task<SectionDto?> GetSectionByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Section/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SectionDto>(json);
            }

            return null;
        }

        // Tạo mới bộ phận
        public async Task<string> CreateSectionAsync(SectionInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/Section", content);
            return response.IsSuccessStatusCode
                ? "Thêm bộ phận thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật bộ phận
        public async Task<string> UpdateSectionAsync(int id, SectionInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/Section/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật bộ phận thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa bộ phận
        public async Task<string> DeleteSectionAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Section/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa bộ phận thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

    }
}
