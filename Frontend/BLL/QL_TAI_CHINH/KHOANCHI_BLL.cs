using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TAI_CHINH_BLL
{
    public class KHOANCHI_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        // Lấy danh sách tất cả khoản chi
        public async Task<List<ExpenseDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/expense");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ExpenseDto>>(json) ?? new List<ExpenseDto>();
            }

            return new List<ExpenseDto>();
        }

        // Lấy khoản chi theo ID
        public async Task<ExpenseDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/expense/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ExpenseDto>(json);
            }

            return null;
        }

        // Tạo mới khoản chi
        public async Task<string> CreateAsync(ExpenseInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/expense", content);

            return response.IsSuccessStatusCode
                ? "Thêm khoản chi thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật khoản chi
        public async Task<string> UpdateAsync(int id, ExpenseInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/expense/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật khoản chi thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa khoản chi
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/expense/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa khoản chi thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
