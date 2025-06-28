using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TAI_CHINH_BLL
{
    public class LUONG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy tất cả bản ghi lương
        public async Task<List<SalaryDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Salary");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SalaryDto>>(json) ?? new List<SalaryDto>();
            }

            return new List<SalaryDto>();
        }

        // Lấy chi tiết theo ID
        public async Task<SalaryDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Salary/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SalaryDto>(json);
            }

            return null;
        }

        // Tạo mới
        public async Task<string> CreateAsync(SalaryInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/Salary", content);

            return response.IsSuccessStatusCode
                ? "Thêm lương nhân viên thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật
        public async Task<string> UpdateAsync(int id, SalaryInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/Salary/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật lương nhân viên thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Salary/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa lương nhân viên thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
