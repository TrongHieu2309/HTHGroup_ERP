using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAN_SU
{
    public class NHANSU_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetEmployeeDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(bp => bp.MaNV, bp => $"{bp.HoTen}");
        }

        // Lấy danh sách tất cả nhân sự
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Employee");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmployeeDto>>(json) ?? new List<EmployeeDto>();
            }

            return new List<EmployeeDto>();
        }

        // Lấy nhân sự theo mã
        public async Task<EmployeeDto?> GetByIdAsync(int maNV)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Employee/{maNV}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeeDto>(json);
            }

            return null;
        }

        // Thêm mới nhân sự
        public async Task<string> CreateAsync(EmployeeInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/Employee", content);
            return response.IsSuccessStatusCode
                ? "Thêm nhân sự thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật nhân sự
        public async Task<string> UpdateAsync(int maNV, EmployeeInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/Employee/{maNV}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật nhân sự thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa nhân sự
        public async Task<string> DeleteAsync(int maNV)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Employee/{maNV}");
            return response.IsSuccessStatusCode
                ? "Xóa nhân sự thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
