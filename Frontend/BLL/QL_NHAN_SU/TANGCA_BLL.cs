using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TANGCA_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy toàn bộ danh sách tăng ca
        public async Task<List<ExtraShiftDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/ExtraShift");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ExtraShiftDto>>(json);
            }
            return new List<ExtraShiftDto>();
        }

        // Lấy thông tin tăng ca theo ID
        public async Task<ExtraShiftDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/ExtraShift/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ExtraShiftDto>(json);
            }
            return null;
        }

        // Tạo mới một ca tăng ca
        public async Task<string> CreateAsync(ExtraShiftInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/ExtraShift", content);
            return response.IsSuccessStatusCode
                ? "Thêm ca tăng ca thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật ca tăng ca
        public async Task<string> UpdateAsync(int id, ExtraShiftInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/ExtraShift/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật ca tăng ca thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa ca tăng ca
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/ExtraShift/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa ca tăng ca thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
