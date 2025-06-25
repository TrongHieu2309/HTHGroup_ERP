using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_BAN_HANG
{
    public class CHITIETHOADON_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        public async Task<List<ReceiptDetailDto>> GetAllDetailsAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/ReceiptDetail");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ReceiptDetailDto>>(json);
        }

        public async Task<ReceiptDetailDto?> GetDetailByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/ReceiptDetail/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReceiptDetailDto>(json);
        }

        public async Task<string> CreateDetailAsync(ReceiptDetailInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/ReceiptDetail", content);

            return response.IsSuccessStatusCode
                ? "Thêm chi tiết hóa đơn thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<string> UpdateDetailAsync(int id, ReceiptDetailInputDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/ReceiptDetail/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật chi tiết hóa đơn thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<string> DeleteDetailAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/ReceiptDetail/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa chi tiết hóa đơn thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        public async Task<List<ReceiptDetailDto>> GetDetailsByReceiptIdAsync(int maHD)
        {
            var allDetails = await GetAllDetailsAsync();
            return allDetails.FindAll(d => d.MaHD == maHD);
        }
    }
}
