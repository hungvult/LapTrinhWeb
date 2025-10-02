using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LapTrinhWeb.Models;
using LapTrinhWeb.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LapTrinhWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        public ProductController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _env = env;
        }
        // Sử dụng InMemoryStore cho dữ liệu tĩnh
        private static List<Category> Categories => InMemoryStore.Categories;
        private static List<Product> Products => InMemoryStore.Products;

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Details(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            ViewBag.Categories = Categories;
            return View(product);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewBag.Categories = Categories;
            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                try
                {
                    var uploadsDir = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "products");
                    Directory.CreateDirectory(uploadsDir);
                    var ext = Path.GetExtension(product.ImageFile.FileName);
                    var fileName = $"{Guid.NewGuid()}{ext}";
                    var savePath = Path.Combine(uploadsDir, fileName);
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        product.ImageFile.CopyTo(stream);
                    }
                    product.Image = fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ImageFile", "Lỗi khi lưu ảnh: " + ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Ảnh sản phẩm bắt buộc chọn");
            }
            if (ModelState.IsValid)
            {
                product.Id = Products.Count > 0 ? Products.Max(p => p.Id) + 1 : 1;
                Products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            ViewBag.Categories = Categories;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            ViewBag.Categories = Categories;
            var existing = Products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();
            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                try
                {
                    var uploadsDir = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "products");
                    Directory.CreateDirectory(uploadsDir);
                    var ext = Path.GetExtension(product.ImageFile.FileName);
                    var fileName = $"{Guid.NewGuid()}{ext}";
                    var savePath = Path.Combine(uploadsDir, fileName);
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        product.ImageFile.CopyTo(stream);
                    }
                    product.Image = fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ImageFile", "Lỗi khi lưu ảnh: " + ex.Message);
                }
            }
            else
            {
                product.Image = existing.Image;
            }
            if (ModelState.IsValid)
            {
                existing.Name = product.Name;
                existing.Image = product.Image;
                existing.Price = product.Price;
                existing.SalePrice = product.SalePrice;
                existing.CategoryId = product.CategoryId;
                existing.Description = product.Description;
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            ViewBag.Categories = Categories;
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                // Try delete image file if exists
                try
                {
                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        var uploadsDir = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "products");
                        var imgPath = Path.Combine(uploadsDir, product.Image);
                        if (System.IO.File.Exists(imgPath))
                        {
                            System.IO.File.Delete(imgPath);
                        }
                    }
                }
                catch
                {
                    // ignore errors when deleting file
                }

                Products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}