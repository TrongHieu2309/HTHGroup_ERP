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
    public class LOAICA_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetShiftTypeDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(lc => lc.MaLoaiCa, lc => $"{lc.CaLamViec}");
        }

        // Lấy tất cả loại ca làm việc
        public async Task<List<ShiftTypeDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/ShiftType");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ShiftTypeDto>>(json) ?? new List<ShiftTypeDto>();
            }
            return new List<ShiftTypeDto>();
        }

        // Lấy loại ca theo ID
        public async Task<ShiftTypeDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/ShiftType/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ShiftTypeDto>(json);
            }
            return null;
        }

        // Thêm loại ca mới
        public async Task<string> CreateAsync(ShiftTypeInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/ShiftType", content);
            return response.IsSuccessStatusCode
                ? "Thêm loại ca thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật loại ca
        public async Task<string> UpdateAsync(int id, ShiftTypeInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/ShiftType/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật loại ca thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa loại ca
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/ShiftType/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa loại ca thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
