// Bổ sung vào HOADON_BLL.cs
using ERP.Application.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class HOADON_BLL
{
    private readonly string baseUrl = "https://localhost:7086";

    public async Task<List<ReceiptDto>> GetAllReceiptsAsync()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"{baseUrl}/api/Receipt");
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ReceiptDto>>(json);
    }

    public async Task<string> CreateReceiptAsync(ReceiptDto dto)
    {
        using var client = new HttpClient();
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{baseUrl}/api/Receipt", content);
        return response.IsSuccessStatusCode ? "Thêm hóa đơn thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
    }

    public async Task<string> UpdateReceiptAsync(int id, ReceiptDto dto)
    {
        using var client = new HttpClient();
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{baseUrl}/api/Receipt/{id}", content);
        return response.IsSuccessStatusCode ? "Cập nhật hóa đơn thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
    }

    public async Task<string> DeleteReceiptAsync(int id)
    {
        using var client = new HttpClient();
        var response = await client.DeleteAsync($"{baseUrl}/api/Receipt/{id}");
        return response.IsSuccessStatusCode ? "Xóa hóa đơn thành công!" : $"Lỗi: {await response.Content.ReadAsStringAsync()}";
    }
}
