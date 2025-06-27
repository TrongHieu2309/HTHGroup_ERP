using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAN_SU
{
    public class CHUCVU_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetJobTitleDictionaryAsync() 
        {
            var list = await GetAllAsync();
            return list.ToDictionary(cv => cv.MaChucVu, cv => $"{cv.TenChucVu}");
        }

        public async Task<List<JobTitleDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/JobTitle");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<JobTitleDto>>(json) ?? new List<JobTitleDto>();
            }

            return new List<JobTitleDto>();
        }

        public async Task<JobTitleDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/JobTitle/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JobTitleDto>(json);
            }

            return null;
        }

        public async Task<string> CreateAsync(JobTitleInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/JobTitle", content);
            return response.IsSuccessStatusCode
                ? "Thêm chức vụ thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<string> UpdateAsync(int id, JobTitleInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/JobTitle/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật chức vụ thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/JobTitle/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa chức vụ thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
