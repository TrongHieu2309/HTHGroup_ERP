using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LOAICONG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086"; // Cập nhật đúng cổng API của bạn

        public async Task<Dictionary<int, string>> GetDayTypeDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(lc => lc.MaLoaiCong, lc => $"{lc.TenLoaiCong}");
        }

        // Lấy tất cả loại công
        public async Task<List<DayTypeDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/DayType");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DayTypeDto>>(json) ?? new List<DayTypeDto>();
            }
            return new List<DayTypeDto>();
        }

        // Lấy loại công theo ID
        public async Task<DayTypeDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/DayType/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DayTypeDto>(json);
            }
            return null;
        }

        // Thêm mới loại công
        public async Task<string> CreateAsync(DayTypeInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/DayType", content);
            return response.IsSuccessStatusCode
                ? "Thêm loại công thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật loại công
        public async Task<string> UpdateAsync(int id, DayTypeInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/DayType/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật loại công thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa loại công
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/DayType/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa loại công thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
