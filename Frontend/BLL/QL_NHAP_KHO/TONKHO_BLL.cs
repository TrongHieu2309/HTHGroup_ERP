using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class TONKHO_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<List<AvailableStockDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/AvailableStock");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AvailableStockDto>>(json) ?? new List<AvailableStockDto>();
            }

            return new List<AvailableStockDto>();
        }

        public async Task<AvailableStockDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/AvailableStock/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AvailableStockDto>(json);
            }

            return null;
        }

        public async Task<string> CreateAsync(AvailableStockInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/AvailableStock", content);

            if (response.IsSuccessStatusCode)
            {
                // Cập nhật số lượng tồn mới vào bảng SANPHAM
                await UpdateProductStockAsync(input.MaSP, input.SoLuongTon);
                return "Thêm tồn kho thành công và đã cập nhật số lượng sản phẩm!";
            }

            return $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<string> UpdateAsync(int id, AvailableStockInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/AvailableStock/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                // Cập nhật số lượng tồn mới vào bảng SANPHAM
                await UpdateProductStockAsync(input.MaSP, input.SoLuongTon);
                return "Cập nhật tồn kho thành công và đã cập nhật số lượng sản phẩm!";
            }

            return $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/AvailableStock/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa tồn kho thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        private async Task UpdateProductStockAsync(int maSP, int soLuongTon)
        {
            using var client = new HttpClient();

            // Get sản phẩm theo ID
            var getResponse = await client.GetAsync($"{baseUrl}/api/product/{maSP}");
            if (!getResponse.IsSuccessStatusCode) return;

            var json = await getResponse.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(json);
            if (product == null) return;

            // Cập nhật lại số lượng tồn
            var updatedProduct = new ProductInputDto
            {
                TenSanPham = product.TenSanPham,
                MoTa = product.MoTa,
                DonGia = product.DonGia,
                MaNCC = product.MaNCC,
                MaMatHang = product.MaMatHang,
                NgayNhap = product.NgayNhap,
                SoLuongTon = soLuongTon,
                TrangThai = product.TrangThai
            };

            var updateJson = JsonConvert.SerializeObject(updatedProduct);
            var content = new StringContent(updateJson, Encoding.UTF8, "application/json");

            await client.PutAsync($"{baseUrl}/api/product/{maSP}", content);
        }
    }
}
