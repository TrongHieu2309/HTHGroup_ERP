using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_BAN_HANG
{
    public class XUATKHO_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";
        private readonly HttpClient client;

        public XUATKHO_BLL()
        {
            client = new HttpClient();
        }

        // Lấy danh sách phiếu xuất
        public async Task<List<StockOutDto>> GetAllAsync()
        {
            var response = await client.GetAsync($"{baseUrl}/api/stockout");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<StockOutDto>>(json) ?? new List<StockOutDto>();
            }

            return new List<StockOutDto>();
        }

        // Lấy chi tiết phiếu xuất theo mã
        public async Task<List<StockOutDetailDto>> GetDetailsByPhieuXuatAsync(int maPhieuXuat)
        {
            var response = await client.GetAsync($"{baseUrl}/api/stockoutdetail/by-stockout/{maPhieuXuat}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<StockOutDetailDto>>(json) ?? new List<StockOutDetailDto>();
            }

            return new List<StockOutDetailDto>();
        }

        // Lấy 1 phiếu xuất theo ID
        public async Task<StockOutDto?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/api/stockout/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StockOutDto>(json);
            }

            return null;
        }

        // Tạo mới phiếu xuất + chi tiết
        public async Task<string> CreateAsync(StockOutInputDto inputPhieu, StockOutDetailInputDto inputChiTiet)
        {
            var json = JsonConvert.SerializeObject(inputPhieu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/stockout", content);

            if (!response.IsSuccessStatusCode)
                return $"Lỗi tạo phiếu xuất: {await response.Content.ReadAsStringAsync()}";

            var responseBody = await response.Content.ReadAsStringAsync();
            var created = JsonConvert.DeserializeObject<StockOutDto>(responseBody);
            if (created == null)
                return "Không thể lấy phiếu xuất vừa tạo.";

            // Tạo chi tiết phiếu xuất
            inputChiTiet.MaPhieuXuat = created.MaPhieuXuat;
            var jsonCT = JsonConvert.SerializeObject(inputChiTiet);
            var contentCT = new StringContent(jsonCT, Encoding.UTF8, "application/json");
            var responseCT = await client.PostAsync($"{baseUrl}/api/stockoutdetail", contentCT);

            return responseCT.IsSuccessStatusCode
                ? "Thêm phiếu xuất và chi tiết thành công!"
                : $"Tạo phiếu xuất thành công nhưng lỗi khi thêm chi tiết: {await responseCT.Content.ReadAsStringAsync()}";
        }

        // Cập nhật phiếu xuất và chi tiết
        public async Task<string> UpdateAsync(int id, StockOutInputDto inputPhieu, int chiTietId, StockOutDetailInputDto inputChiTiet)
        {
            var json = JsonConvert.SerializeObject(inputPhieu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/stockout/{id}", content);

            if (!response.IsSuccessStatusCode)
                return $"Lỗi cập nhật phiếu xuất: {await response.Content.ReadAsStringAsync()}";

            inputChiTiet.MaPhieuXuat = id;

            var jsonCT = JsonConvert.SerializeObject(inputChiTiet);
            var contentCT = new StringContent(jsonCT, Encoding.UTF8, "application/json");
            var responseCT = await client.PutAsync($"{baseUrl}/api/stockoutdetail/{chiTietId}", contentCT);

            return responseCT.IsSuccessStatusCode
                ? "Cập nhật thành công cả phiếu xuất và chi tiết!"
                : $"Cập nhật phiếu xuất thành công nhưng lỗi khi cập nhật chi tiết: {await responseCT.Content.ReadAsStringAsync()}";
        }

        // Xóa phiếu xuất và toàn bộ chi tiết
        public async Task<string> DeleteAsync(int id)
        {
            // Lấy chi tiết trước
            var chiTiets = await GetDetailsByPhieuXuatAsync(id);
            foreach (var ct in chiTiets)
            {
                var resCT = await client.DeleteAsync($"{baseUrl}/api/stockoutdetail/{ct.Id}");
                if (!resCT.IsSuccessStatusCode)
                    return $"Lỗi khi xóa chi tiết phiếu xuất ID {ct.Id}: {await resCT.Content.ReadAsStringAsync()}";
            }

            // Xóa phiếu xuất
            var response = await client.DeleteAsync($"{baseUrl}/api/stockout/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa phiếu xuất và chi tiết thành công!"
                : $"Lỗi xóa phiếu xuất: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
