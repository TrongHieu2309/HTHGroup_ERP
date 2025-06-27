using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAN_SU
{
    public class BAOHIEM_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy tất cả bảo hiểm
        public async Task<List<InsuranceDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/insurance");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<InsuranceDto>>(json) ?? new List<InsuranceDto>();
            }

            return new List<InsuranceDto>();
        }

        // Lấy bảo hiểm theo mã
        public async Task<InsuranceDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/insurance/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InsuranceDto>(json);
            }

            return null;
        }

        // Tạo bảo hiểm mới
        public async Task<string> CreateAsync(InsuranceInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/insurance", content);
            return response.IsSuccessStatusCode
                ? "Thêm bảo hiểm thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật bảo hiểm
        public async Task<string> UpdateAsync(int id, InsuranceInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/insurance/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật bảo hiểm thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa bảo hiểm
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/insurance/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa bảo hiểm thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
