using Microsoft.AspNetCore.Mvc;
using LapTrinhWeb.Data;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(InMemoryStore.Categories);
        }

        public IActionResult Details(int id)
        {
            var item = InMemoryStore.Categories.FirstOrDefault(c => c.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = InMemoryStore.Categories.Count > 0 ? InMemoryStore.Categories.Max(c => c.Id) + 1 : 1;
                InMemoryStore.Categories.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var item = InMemoryStore.Categories.FirstOrDefault(c => c.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            var existing = InMemoryStore.Categories.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();
            if (ModelState.IsValid)
            {
                existing.Name = category.Name;
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var item = InMemoryStore.Categories.FirstOrDefault(c => c.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = InMemoryStore.Categories.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                InMemoryStore.Categories.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
