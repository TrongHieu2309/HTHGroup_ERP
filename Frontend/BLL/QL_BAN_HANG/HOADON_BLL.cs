using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_BAN_HANG
{
    public class HOADON_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";
        private readonly HttpClient client;

        public HOADON_BLL()
        {
            client = new HttpClient();
        }

        // Lấy danh sách hóa đơn
        public async Task<List<ReceiptDto>> GetAllAsync()
        {
            var response = await client.GetAsync($"{baseUrl}/api/receipt");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ReceiptDto>>(json) ?? new List<ReceiptDto>();
            }

            return new List<ReceiptDto>();
        }

        // Lấy chi tiết hóa đơn theo mã hóa đơn
        public async Task<List<ReceiptDetailDto>> GetDetailsByMaHDAsync(int maHD)
        {
            var response = await client.GetAsync($"{baseUrl}/api/receiptdetail");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var all = JsonConvert.DeserializeObject<List<ReceiptDetailDto>>(json) ?? new List<ReceiptDetailDto>();
                return all.FindAll(x => x.MaHD == maHD);
            }

            return new List<ReceiptDetailDto>();
        }

        // Lấy 1 hóa đơn theo ID
        public async Task<ReceiptDto?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/api/receipt/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ReceiptDto>(json);
            }

            return null;
        }

        // Tạo mới hóa đơn + chi tiết
        public async Task<string> CreateAsync(ReceiptInputDto inputPhieu, ReceiptDetailInputDto inputChiTiet)
        {
            var json = JsonConvert.SerializeObject(inputPhieu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/receipt", content);

            if (!response.IsSuccessStatusCode)
                return $"Lỗi tạo hóa đơn: {await response.Content.ReadAsStringAsync()}";

            var responseBody = await response.Content.ReadAsStringAsync();
            var created = JsonConvert.DeserializeObject<ReceiptDto>(responseBody);
            if (created == null)
                return "Không thể lấy hóa đơn vừa tạo.";

            // Tạo chi tiết hóa đơn
            inputChiTiet.MaHD = created.MaHD;
            var jsonCT = JsonConvert.SerializeObject(inputChiTiet);
            var contentCT = new StringContent(jsonCT, Encoding.UTF8, "application/json");
            var responseCT = await client.PostAsync($"{baseUrl}/api/receiptdetail", contentCT);

            return responseCT.IsSuccessStatusCode
                ? "Thêm hóa đơn và chi tiết thành công!"
                : $"Tạo hóa đơn thành công nhưng lỗi khi thêm chi tiết: {await responseCT.Content.ReadAsStringAsync()}";
        }

        // Cập nhật hóa đơn và chi tiết
        public async Task<string> UpdateAsync(int id, ReceiptInputDto inputPhieu, int chiTietId, ReceiptDetailInputDto inputChiTiet)
        {
            var json = JsonConvert.SerializeObject(inputPhieu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/receipt/{id}", content);
            if (!response.IsSuccessStatusCode)
                return $"Lỗi cập nhật hóa đơn: {await response.Content.ReadAsStringAsync()}";

            // Cập nhật chi tiết
            inputChiTiet.MaHD = id;
            var jsonCT = JsonConvert.SerializeObject(inputChiTiet);
            var contentCT = new StringContent(jsonCT, Encoding.UTF8, "application/json");
            var responseCT = await client.PutAsync($"{baseUrl}/api/receiptdetail/{chiTietId}", contentCT);

            return responseCT.IsSuccessStatusCode
                ? "Cập nhật thành công cả hóa đơn và chi tiết!"
                : $"Cập nhật hóa đơn thành công nhưng lỗi khi cập nhật chi tiết: {await responseCT.Content.ReadAsStringAsync()}";
        }

        // Xóa hóa đơn và toàn bộ chi tiết
        public async Task<string> DeleteAsync(int id)
        {
            // Lấy chi tiết trước
            var chiTiets = await GetDetailsByMaHDAsync(id);
            foreach (var ct in chiTiets)
            {
                var resCT = await client.DeleteAsync($"{baseUrl}/api/receiptdetail/{ct.Id}");
                if (!resCT.IsSuccessStatusCode)
                    return $"Lỗi khi xóa chi tiết hóa đơn ID {ct.Id}: {await resCT.Content.ReadAsStringAsync()}";
            }

            // Xóa hóa đơn
            var response = await client.DeleteAsync($"{baseUrl}/api/receipt/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa hóa đơn và chi tiết thành công!"
                : $"Lỗi xóa hóa đơn: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
