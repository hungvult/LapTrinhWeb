using LapTrinhWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapTrinhWeb.ViewComponents;

public class ProductListViewComponent : ViewComponent
{
    List<Product> list;

    public IViewComponentResult Invoke()
    {
        list = new List<Product>()
        {
            new Product() { ImageSrc = "/images/product.jpg", Name = "Nồi cơm điện cao tần Nagakawa NAG0102" },
            new Product() { ImageSrc = "/images/product.jpg", Name = "Nồi cơm điện cao tần Nagakawa NAG0102" },
            new Product() { ImageSrc = "/images/product.jpg", Name = "Nồi cơm điện cao tần Nagakawa NAG0102" }
        };
        return View(list);
    }
}
