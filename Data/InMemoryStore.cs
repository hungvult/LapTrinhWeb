using LapTrinhWeb.Models;
using System.Collections.Generic;

namespace LapTrinhWeb.Data
{
    public static class InMemoryStore
    {
        public static List<Category> Categories { get; } = new List<Category>
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" }
        };

        public static List<Product> Products { get; } = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "OPPO A37FW",
                Image = "OPPO.webp",
                Price = 3990000f,
                SalePrice = 3591000f,
                CategoryId = 1,
                Description = "OPPO A37FW - điện thoại mẫu tham khảo"
            }
        };
    }
}
