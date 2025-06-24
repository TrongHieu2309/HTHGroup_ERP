using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class EducationLevelDto
    {
        public int MaTDHV { get; set; }
        public string TrinhDoHocVan { get; set; } = null!;
    }

    public class EducationLevelInputDto
    {
        [Required(ErrorMessage = "Trình độ học vấn không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Trình độ học vấn không được vượt quá 100 ký tự")]
        public string TrinhDoHocVan { get; set; } = null!;
    }
}
