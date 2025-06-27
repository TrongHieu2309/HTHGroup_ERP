using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TAI_CHINH_BLL
{
    public class PHUCAP_NV_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy danh sách toàn bộ phụ cấp nhân viên
        public async Task<List<EmployeeAllowanceDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/EmployeeAllowance");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmployeeAllowanceDto>>(json) ?? new List<EmployeeAllowanceDto>();
            }

            return new List<EmployeeAllowanceDto>();
        }

        // Lấy phụ cấp nhân viên theo ID
        public async Task<EmployeeAllowanceDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/EmployeeAllowance/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeeAllowanceDto>(json);
            }

            return null;
        }

        // Tạo mới phụ cấp nhân viên
        public async Task<string> CreateAsync(EmployeeAllowanceInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/EmployeeAllowance", content);

            return response.IsSuccessStatusCode
                ? "Thêm phụ cấp nhân viên thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật phụ cấp nhân viên
        public async Task<string> UpdateAsync(int id, EmployeeAllowanceInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/EmployeeAllowance/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật phụ cấp nhân viên thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa phụ cấp nhân viên
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/EmployeeAllowance/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa phụ cấp nhân viên thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
