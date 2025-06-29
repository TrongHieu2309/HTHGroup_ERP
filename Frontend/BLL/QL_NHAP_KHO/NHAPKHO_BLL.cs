using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class NHAPKHO_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";

        private readonly HttpClient client;

        public NHAPKHO_BLL()
        {
            client = new HttpClient();
        }

        // Lấy danh sách phiếu nhập
        public async Task<List<StockInDto>> GetAllAsync()
        {
            var response = await client.GetAsync($"{baseUrl}/api/stockin");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<StockInDto>>(json) ?? new List<StockInDto>();
            }

            return new List<StockInDto>();
        }

        // Lấy chi tiết phiếu nhập theo mã
        public async Task<List<StockInDetailDto>> GetDetailsByPhieuNhapAsync(int maPhieuNhap)
        {
            var response = await client.GetAsync($"{baseUrl}/api/stockindetail/phieunhap/{maPhieuNhap}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<StockInDetailDto>>(json) ?? new List<StockInDetailDto>();
            }

            return new List<StockInDetailDto>();
        }

        // Lấy 1 phiếu nhập theo ID
        public async Task<StockInDto?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/api/stockin/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StockInDto>(json);
            }

            return null;
        }

        // Tạo mới phiếu nhập + chi tiết
        public async Task<string> CreateAsync(StockInInputDto inputPhieu, StockInDetailInputDto inputChiTiet)
        {
            var json = JsonConvert.SerializeObject(inputPhieu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/stockin", content);

            if (!response.IsSuccessStatusCode)
                return $"Lỗi tạo phiếu nhập: {await response.Content.ReadAsStringAsync()}";

            var responseBody = await response.Content.ReadAsStringAsync();
            var created = JsonConvert.DeserializeObject<StockInDto>(responseBody);
            if (created == null)
                return "Không thể lấy phiếu nhập vừa tạo.";

            // Tạo chi tiết phiếu nhập
            inputChiTiet.MaPhieuNhap = created.MaPhieuNhap;
            var jsonCT = JsonConvert.SerializeObject(inputChiTiet);
            var contentCT = new StringContent(jsonCT, Encoding.UTF8, "application/json");
            var responseCT = await client.PostAsync($"{baseUrl}/api/stockindetail", contentCT);

            return responseCT.IsSuccessStatusCode
                ? "Thêm phiếu nhập và chi tiết thành công!"
                : $"Tạo phiếu nhập thành công nhưng lỗi khi thêm chi tiết: {await responseCT.Content.ReadAsStringAsync()}";
        }

        // Cập nhật phiếu nhập và chi tiết
        public async Task<string> UpdateAsync(int id, StockInInputDto inputPhieu, int chiTietId, StockInDetailInputDto inputChiTiet)
        {
            var json = JsonConvert.SerializeObject(inputPhieu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/stockin/{id}", content);

            if (!response.IsSuccessStatusCode)
                return $"Lỗi cập nhật phiếu nhập: {await response.Content.ReadAsStringAsync()}";

            inputChiTiet.MaPhieuNhap = id;

            var jsonCT = JsonConvert.SerializeObject(inputChiTiet);
            var contentCT = new StringContent(jsonCT, Encoding.UTF8, "application/json");
            var responseCT = await client.PutAsync($"{baseUrl}/api/stockindetail/{chiTietId}", contentCT);

            return responseCT.IsSuccessStatusCode
                ? "Cập nhật thành công cả phiếu nhập và chi tiết!"
                : $"Cập nhật phiếu nhập thành công nhưng lỗi khi cập nhật chi tiết: {await responseCT.Content.ReadAsStringAsync()}";
        }


        // Xóa phiếu nhập và chi tiết
        public async Task<string> DeleteAsync(int id)
        {
            // Lấy danh sách chi tiết
            var chiTiets = await GetDetailsByPhieuNhapAsync(id);
            foreach (var ct in chiTiets)
            {
                var resCT = await client.DeleteAsync($"{baseUrl}/api/stockindetail/{ct.Id}");
                if (!resCT.IsSuccessStatusCode)
                    return $"Lỗi khi xóa chi tiết phiếu nhập ID {ct.Id}: {await resCT.Content.ReadAsStringAsync()}";
            }

            // Xóa phiếu nhập
            var response = await client.DeleteAsync($"{baseUrl}/api/stockin/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa phiếu nhập và chi tiết thành công!"
                : $"Lỗi xóa phiếu nhập: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
