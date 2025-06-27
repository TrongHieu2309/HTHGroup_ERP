using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TRINH_DO
{
    public class TRINHDO_BLL
    {
        private readonly string baseUrl = "https://localhost:7086"; // Thay đổi nếu backend bạn chạy port khác

        public async Task<Dictionary<int, string>> GetDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(td => td.MaTDHV, td => $"{td.TrinhDoHocVan}");
        }

        // GET: /api/EducationLevel
        public async Task<List<EducationLevelDto>> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/EducationLevel");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<EducationLevelDto>>(json);
                }
                return new List<EducationLevelDto>();
            }
        }

        // GET: /api/EducationLevel/{id}
        public async Task<EducationLevelDto?> GetByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/EducationLevel/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EducationLevelDto>(json);
                }
                return null;
            }
        }

        // POST: /api/EducationLevel
        public async Task<string> CreateAsync(EducationLevelInputDto dto)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{baseUrl}/api/EducationLevel", content);
                return response.IsSuccessStatusCode ? "Thêm trình độ học vấn thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
            }
        }

        // PUT: /api/EducationLevel/{id}
        public async Task<string> UpdateAsync(int id, EducationLevelInputDto dto)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{baseUrl}/api/EducationLevel/{id}", content);
                return response.IsSuccessStatusCode ? "Cập nhật trình độ học vấn thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
            }
        }

        // DELETE: /api/EducationLevel/{id}
        public async Task<string> DeleteAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}/api/EducationLevel/{id}");
                return response.IsSuccessStatusCode ? "Xóa trình độ học vấn thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
            }
        }
    }
}
