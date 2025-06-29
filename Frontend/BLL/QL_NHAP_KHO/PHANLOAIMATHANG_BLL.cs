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
    public class PHANLOAIMATHANG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetProductCategoryDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(plmh => plmh.MaMatHang, plmh => $"{plmh.TenMatHang}");
        }

        // Lấy danh sách tất cả mặt hàng
        public async Task<List<ProductCategoryDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/productcategory");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductCategoryDto>>(json) ?? new List<ProductCategoryDto>();
            }

            return new List<ProductCategoryDto>();
        }

        // Lấy mặt hàng theo ID
        public async Task<ProductCategoryDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/productcategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductCategoryDto>(json);
            }

            return null;
        }

        // Tạo mới mặt hàng
        public async Task<string> CreateAsync(ProductCategoryInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/productcategory", content);

            return response.IsSuccessStatusCode
                ? "Thêm mặt hàng thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật mặt hàng
        public async Task<string> UpdateAsync(int id, ProductCategoryInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/productcategory/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật mặt hàng thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa mặt hàng
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/productcategory/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa mặt hàng thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
