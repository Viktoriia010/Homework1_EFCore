using OnlineStore.Context;
using OnlineStore.Entities;

namespace OnlineStore;

internal class Program
{
    static void Main(string[] args)
    {
        using (var context = new OnlineStoreDBContext()) 
        {
            //context.Database.EnsureCreated();
            //context.Database.EnsureDeleted();
            var store = new OnlineStoreMetods(context);


            //var cat1 = new Category { Name = "Electronics" };
            //var cat2 = new Category { Name = "Books" };

            //context.Categories.AddRange(cat1, cat2);
            //context.SaveChanges();

            //var category = context.Categories.First();

            //context.Products.AddRange(
            //    new Product
            //    {
            //        Name = "Laptop",
            //        Description = "Gaming laptop",
            //        Price = 50000,
            //        StockQuantity = 5,
            //        CategoryId = category.Id
            //    },
            //    new Product
            //    {
            //        Name = "Mouse",
            //        Description = "Wireless mouse",
            //        Price = 800,
            //        StockQuantity = 0,
            //        CategoryId = category.Id
            //    },
            //    new Product
            //    {
            //        Name = "Keyboard",
            //        Description = "Mechanical keyboard",
            //        Price = 2500,
            //        StockQuantity = 10,
            //        CategoryId = category.Id
            //    },
            //    new Product
            //    {
            //        Name = "Monitor",
            //        Description = "4K Monitor",
            //        Price = 15000,
            //        StockQuantity = 2,
            //        CategoryId = category.Id
            //    }
            //);

            //context.SaveChanges();


            Console.WriteLine("Out of stock products:");
            var outOfStock = store.ShowProductOutOfStock();
            foreach (var p in outOfStock)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.Price}");
            }

            Console.WriteLine("\nTop 3 expensive products:");
            var top3 = store.GetTop3ExpensiveProducts();
            foreach (var p in top3)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }

            store.DeleteProduct(1);

            store.ChangeName(2);

  
            store.ChangeQuantity(3);

        }
        ;
    }
}
