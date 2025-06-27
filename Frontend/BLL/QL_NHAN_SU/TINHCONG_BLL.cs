using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TINHCONG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086"; // Cập nhật đúng địa chỉ và port API

        // Lấy danh sách chấm công
        public async Task<List<WorkRecordDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/WorkRecord");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<WorkRecordDto>>(json)!;
            }
            return new List<WorkRecordDto>();
        }

        // Lấy chi tiết 1 bản ghi
        public async Task<WorkRecordDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/WorkRecord/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WorkRecordDto>(json);
            }
            return null;
        }

        // Thêm mới chấm công
        public async Task<string> CreateAsync(WorkRecordInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/WorkRecord", content);
            return response.IsSuccessStatusCode
                ? "Thêm bản ghi chấm công thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật chấm công
        public async Task<string> UpdateAsync(int id, WorkRecordInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/WorkRecord/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật bản ghi chấm công thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa chấm công
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/WorkRecord/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa bản ghi chấm công thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
