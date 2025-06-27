using ERP.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAN_SU
{
    public class PHONGBAN_BLL
    {
        private readonly string baseUrl = "https://localhost:7086"; // Cập nhật đúng port của backend

        public async Task<Dictionary<int, string>> GetDepartmentDictionaryAsync() // lấy dữ liệu lên comboBox
        {
            var list = await GetAllAsync();
            return list.ToDictionary(pb => pb.MaPhongBan, pb => $"{pb.TenPhongBan}");
        }

        // Lấy tất cả phòng ban
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/Departments");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DepartmentDto>>(json);
                }
                return new List<DepartmentDto>();
            }
        }

        // Lấy phòng ban theo ID
        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DepartmentDto>(json);
            }
            return null;
        }

        // Thêm mới phòng ban
        public async Task<string> AddAsync(DepartmentInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/Departments", content);
            return response.IsSuccessStatusCode
                ? "Thêm phòng ban thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật phòng ban
        public async Task<string> UpdateAsync(int id, DepartmentInputDto dto)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/Departments/{id}", content);
            return response.IsSuccessStatusCode
                ? "Cập nhật phòng ban thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa phòng ban
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Departments/{id}");
            return response.IsSuccessStatusCode
                ? "Xóa phòng ban thành công!"
                : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
        }
    }
}
