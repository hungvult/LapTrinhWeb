using LapTrinhWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapTrinhWeb.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly List<MenuItem> menuItems;

        public RenderViewComponent()
        {
            menuItems = new List<MenuItem>()
            {
                new MenuItem() {Id=1, Name="List Student", Link="/Admin/Student/list" },
                new MenuItem() {Id=2, Name="Add Student", Link="/Admin/Student/add" },
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shared/_leftMenu.cshtml", menuItems);
        }
    }
}