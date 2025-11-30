using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTrinhWeb.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Thiếu")]
        [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public DateTime DateOfBorth { get; set; }

        [Required(ErrorMessage = "Thiếu")]
        public string? ProfileImagePath { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }
    }
}