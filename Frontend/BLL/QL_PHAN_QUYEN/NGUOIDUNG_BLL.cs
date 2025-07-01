using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class NGUOIDUNG_BLL
    {
        private readonly string baseUrl = "https://localhost:7086";
        private readonly string controllerRoute = "Auth";

        // Lấy tất cả người dùng
        public async Task<List<UserDto>> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/{controllerRoute}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserDto>>(json) ?? new List<UserDto>();
            }

            return new List<UserDto>();
        }

        // Lấy người dùng theo ID
        public async Task<UserDto?> GetByIdAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}/api/{controllerRoute}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserDto>(json);
            }

            return null;
        }

        // Tạo người dùng mới
        public async Task<string> CreateAsync(UserRegisterDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/{controllerRoute}/register", content);

            return response.IsSuccessStatusCode
                ? "Thêm người dùng thành công!"
                : $"Lỗi ({(int)response.StatusCode}): {await response.Content.ReadAsStringAsync()}";
        }

        // Cập nhật người dùng
        public async Task<string> UpdateAsync(int id, UserUpdateDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/api/{controllerRoute}/{id}", content);

            return response.IsSuccessStatusCode
                ? "Cập nhật người dùng thành công!"
                : $"Lỗi ({(int)response.StatusCode}): {await response.Content.ReadAsStringAsync()}";
        }

        // Xóa người dùng
        public async Task<string> DeleteAsync(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/{controllerRoute}/{id}");

            return response.IsSuccessStatusCode
                ? "Xóa người dùng thành công!"
                : $"Lỗi ({(int)response.StatusCode}): {await response.Content.ReadAsStringAsync()}";
        }

        // Đăng nhập
        public async Task<UserDto?> LoginAsync(UserLoginDto input)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/{controllerRoute}/login", content);
            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserDto>(resultJson);
            }

            return null;
        }
    }
}
