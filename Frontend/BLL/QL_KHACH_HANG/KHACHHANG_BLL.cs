using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_KHACH_HANG
{
    public class KHACHHANG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086"; // Đúng với port backend

        public async Task<Dictionary<int, string>> GetCustomerDictionaryAsync() // lấy dữ liệu lên comboBox
        {
            var list = await GetAllCustomersAsync();
            return list.ToDictionary(kh => kh.MaKH, kh => $"{kh.TenKhachHang}");
        }

        // POST: /api/Customer
        public async Task<string> CreateCustomerAsync(CustomerDto dto)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{baseUrl}/api/Customer", content);
                return response.IsSuccessStatusCode ? "Thêm khách hàng thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
            }
        }

        // GET: /api/Customer
        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/Customer");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CustomerDto>>(json);
                }
                return new List<CustomerDto>();
            }
        }

        // GET: /api/Customer/{id}
        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/Customer/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CustomerDto>(json);
                }
                return null;
            }
        }

        // PUT: /api/Customer/{id}
        public async Task<string> UpdateCustomerAsync(int id, CustomerDto dto)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{baseUrl}/api/Customer/{id}", content);
                return response.IsSuccessStatusCode ? "Cập nhật thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
            }
        }

        // DELETE: /api/Customer/{id}
        public async Task<string> DeleteCustomerAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}/api/Customer/{id}");
                return response.IsSuccessStatusCode ? "Xóa thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
            }
        }
    }
}
