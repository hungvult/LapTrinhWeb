using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LapTrinhWeb.Models
{
    public class Product : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm bắt buộc nhập")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")]
        public string Name { get; set; } = string.Empty;

    // Lưu tên file ảnh trong wwwroot/products
    public string Image { get; set; } = string.Empty;

    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm bắt buộc nhập")]
        [Range(0, 99999.99, ErrorMessage = "Giá sản phẩm phải nhỏ hơn 100000")]
        [RegularExpression("^[0-9]+(\\.[0-9]{1,2})?$", ErrorMessage = "Giá sản phẩm phải là số")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Giá khuyến mãi bắt buộc nhập")]
        [Range(0, 99999.99, ErrorMessage = "Giá khuyến mãi không được âm và nhỏ hơn giá chuẩn 10%")]
        public float SalePrice { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm bắt buộc chọn")]
        public int CategoryId { get; set; }

        [StringLength(1500, ErrorMessage = "Mô tả không vượt quá 1500 ký tự")]
        public string Description { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SalePrice < 0 || SalePrice > Price * 0.9)
            {
                yield return new ValidationResult("Giá khuyến mãi không được âm và phải nhỏ hơn giá chuẩn 10%", new[] { nameof(SalePrice) });
            }
            if (!string.IsNullOrEmpty(Description))
            {
                var badWords = new[] { "die", "admin", "fack" };
                foreach (var word in badWords)
                {
                    if (Regex.IsMatch(Description, $"\\b{Regex.Escape(word)}\\b", RegexOptions.IgnoreCase))
                    {
                        yield return new ValidationResult($"Mô tả không được chứa từ nhạy cảm: {word}", new[] { nameof(Description) });
                    }
                }
            }
        }
    }
}