using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TAI_CHINH_BLL
{
    public class KHOANTHU_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy danh sách toàn bộ khoản thu
        public async Task<List<RevenueDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/revenue");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RevenueDto>>(json) ?? new List<RevenueDto>();
            }

            return new List<RevenueDto>();
        }

        // Lấy khoản thu theo ID
        public async Task<RevenueDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/revenue/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RevenueDto>(json);
            }

            return null;
        }

        // Tạo mới khoản thu
        public async Task<string> CreateAsync(RevenueInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/revenue", content);

            return response.IsSuccessStatusCode
                ? "Thêm khoản thu thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật khoản thu
        public async Task<string> UpdateAsync(int id, RevenueInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/revenue/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật khoản thu thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa khoản thu
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/revenue/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa khoản thu thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
