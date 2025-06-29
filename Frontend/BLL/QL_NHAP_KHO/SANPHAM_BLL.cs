using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class SANPHAM_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<Dictionary<int, string>> GetProductDictionaryAsync()
        {
            var list = await GetAllAsync();
            return list.ToDictionary(sp => sp.MaSP, sp => $"{sp.TenSanPham}");
        }

        // Lấy danh sách tất cả sản phẩm
        public async Task<List<ProductDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/product");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductDto>>(json) ?? new List<ProductDto>();
            }

            return new List<ProductDto>();
        }

        // Lấy sản phẩm theo ID
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDto>(json);
            }

            return null;
        }

        // Tạo mới sản phẩm
        public async Task<string> CreateAsync(ProductInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/product", content);

            return response.IsSuccessStatusCode
                ? "Thêm sản phẩm thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật sản phẩm
        public async Task<string> UpdateAsync(int id, ProductInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/product/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật sản phẩm thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa sản phẩm
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/product/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa sản phẩm thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
