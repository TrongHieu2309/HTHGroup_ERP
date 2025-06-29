using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO
{
    public class KHOHANG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetInventoryDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(kho => kho.MaKho, kho => $"{kho.TenKho}");
        }

        // Lấy danh sách tất cả kho hàng
        public async Task<List<InventoryDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/inventory");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<InventoryDto>>(json) ?? new List<InventoryDto>();
            }

            return new List<InventoryDto>();
        }

        // Lấy kho hàng theo ID
        public async Task<InventoryDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/inventory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InventoryDto>(json);
            }

            return null;
        }

        // Tạo mới kho hàng
        public async Task<string> CreateAsync(InventoryInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/inventory", content);

            return response.IsSuccessStatusCode
                ? "Thêm kho hàng thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật kho hàng
        public async Task<string> UpdateAsync(int id, InventoryInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/inventory/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật kho hàng thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa kho hàng
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/inventory/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa kho hàng thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
