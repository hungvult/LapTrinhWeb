using Microsoft.AspNetCore.Mvc;
using LapTrinhWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LapTrinhWeb.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            //Tạo danh sách sinh viên với 4 dữ liệu mẫu
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                    Gender = Gender.Male, IsRegular=true,
                    Address = "A1-2018", Email = "nam@g.com" },
                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                    Gender = Gender.Female, IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com" },
                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                    Gender = Gender.Male, IsRegular=false,
                    Address = "A1-2020", Email = "phong@g.com" },
                new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                    Gender = Gender.Female, IsRegular = false,
                    Address = "A1-2021", Email = "mai@g.com" }
            };
        }
        // GET: Student
        public ActionResult Index()
        {
            return View(listStudents);
        }

        // GET: Student/Create
        [HttpGet]
        public IActionResult Create()
        {
            //lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //lấy danh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                student.Id = listStudents.Any() ? listStudents.Last().Id + 1 : 1;
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);
                    var extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = $"{student.Id}_{Guid.NewGuid().ToString().Substring(0, 8)}{extension}";
                    var filePath = Path.Combine(uploads, fileName);
                    try
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImageFile.CopyTo(stream);
                        }
                        student.ImageFileName = fileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Lỗi khi lưu file: {ex.Message}");
                        ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                        ViewBag.AllBranches = new List<SelectListItem>()
                    {
                        new SelectListItem(){ Text="Information Technology", Value=Branch.IT.ToString() },
                        new SelectListItem(){ Text="Bio Engineering", Value=Branch.BE.ToString() },
                        new SelectListItem(){ Text="Civil Engineering", Value=Branch.CE.ToString() },
                        new SelectListItem(){ Text="Electrical Engineering", Value=Branch.EE.ToString() }
                    };
                        return View(student);
                    }
                }

                listStudents.Add(student);
                return Redirect("/Admin/Student/List");
            }
            return View(student);
        }
    }
}
