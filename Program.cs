using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Configurator;
using OnlineStore.Context;
using OnlineStore.Entities;

namespace OnlineStore;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection(); //Створюється контейнер DI (Dependency Injection)

        services.AddDbContext<OnlineStoreDBContext>(options =>
        {
            DbContextConfigurator.Configure(options);
        });

        //Створюється вже «працюючий» контейнер.
        var provider = services.BuildServiceProvider();

        //"Один DbContext на одну операцію роботи з БД"

        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OnlineStoreDBContext>();

        //ICollection<Category> categories = new List<Category>
        //{
        //    new Category { Name = "Electronics" },
        //    new Category { Name = "Books" },
        //    new Category { Name = "Clothing" },
        //    new Category { Name = "Home & Kitchen" }
        //};

        //context.Categories.AddRange(categories);
        //context.SaveChanges();

        //        var products = new List<Product>
        //{
        //        new Product
        //        {
        //            Name = "iPhone 15",
        //            Description = "Apple smartphone 128GB",
        //            Price = 999.99m,
        //            StockQuantity = 10,
        //            CategoryId = 2
        //        },
        //        new Product
        //        {
        //            Name = "Samsung TV 55\"",
        //            Description = "4K Smart TV",
        //            Price = 699.50m,
        //            StockQuantity = 5,
        //            CategoryId = 2
        //        },
        //        new Product
        //        {
        //            Name = "Clean Code",
        //            Description = "Programming book by Robert C. Martin",
        //            Price = 39.99m,
        //            StockQuantity = 20,
        //            CategoryId = 3
        //        },
        //        new Product
        //        {
        //            Name = "Men's T-Shirt",
        //            Description = "Cotton black T-shirt",
        //            Price = 19.99m,
        //            StockQuantity = 50,
        //            CategoryId = 4
        //        },
        //        new Product
        //        {
        //            Name = "Blender",
        //            Description = "Kitchen blender 700W",
        //            Price = 89.00m,
        //            StockQuantity = 15,
        //            CategoryId = 5
        //        }
        //    };

        //        context.Products.AddRange(products);
        //        context.SaveChanges();

        var products = context.Products.Where(p => p.Id == 10).Include(p => p.Category).ToList();

        products.ForEach(p =>
        {
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Category.Name);
        });

        var categories = context.Categories.Where(c => c.Id == 2).Include(c => c.Products).ToList();

        categories.ForEach(с =>
        {
            Console.WriteLine($"Category: {с.Name}");
            foreach (var product in с.Products)
            {
                Console.WriteLine($" - Product: {product.Name}");
            }
        });

        //var shop = new Shop(context);
        //shop.CreateProduct();
        //shop.ShowProduct();
        //Console.Write("Enter id: ");
        //int id = int.Parse(Console.ReadLine());
        //shop.UpdateProduct(id);
        //shop.ShowProduct();
        //shop.DeleteProduct(id);
        //shop.ShowProduct();
        //shop.CreateCategory();
        //shop.ShowCategory();
        //Console.Write("Enter id: ");
        //int id2 = int.Parse(Console.ReadLine());
        //shop.UpdateCategory(id2);
        //shop.ShowCategory();
        //shop.DeleteCategory(id2);
        //shop.ShowCategory();

        //if (context.Database.CanConnect())
        //{
        //    Console.WriteLine("Пiдключення до БД встановлено");
        //}
        //else
        //{
        //    Console.WriteLine("Не вдалось підключитись до БД");
        //}

        //var configuration = new ConfigurationBuilder()
        //                 .SetBasePath(Directory.GetCurrentDirectory())
        //                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //                 .Build();
        //var optionsBuilder = new DbContextOptionsBuilder<OnlineStoreDBContext>();
        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        //// Создаем контекст с этими опциями
        //using (var context = new OnlineStoreDBContext(optionsBuilder.Options))
        //{
        //    var shop = new Shop(context);
        //    shop.CreateProduct();
        //    shop.ShowProduct();
        //    Console.WriteLine("Enter id: ");
        //    int id = int.Parse(Console.ReadLine());
        //    shop.UpdateProduct(id);
        //    shop.DeleteProduct(id);
        //    shop.CreateCategory();
        //    shop.ShowCategory();
        //    Console.WriteLine("Enter id: ");
        //    int id2 = int.Parse(Console.ReadLine());
        //    shop.UpdateCategory(id2);
        //    shop.DeleteCategory(id2);

        //}



        //using (var context = new OnlineStoreDBContext()) 
        //{
        //    //context.Database.EnsureCreated();
        //    context.Database.EnsureDeleted();
        //    //var store = new OnlineStoreMetods(context);


        //    //var cat1 = new Category { Name = "Electronics" };
        //    //var cat2 = new Category { Name = "Books" };

        //    //context.Categories.AddRange(cat1, cat2);
        //    //context.SaveChanges();

        //    //var category = context.Categories.First();

        //    //context.Products.AddRange(
        //    //    new Product
        //    //    {
        //    //        Name = "Laptop",
        //    //        Description = "Gaming laptop",
        //    //        Price = 50000,
        //    //        StockQuantity = 5,
        //    //        CategoryId = category.Id
        //    //    },
        //    //    new Product
        //    //    {
        //    //        Name = "Mouse",
        //    //        Description = "Wireless mouse",
        //    //        Price = 800,
        //    //        StockQuantity = 0,
        //    //        CategoryId = category.Id
        //    //    },
        //    //    new Product
        //    //    {
        //    //        Name = "Keyboard",
        //    //        Description = "Mechanical keyboard",
        //    //        Price = 2500,
        //    //        StockQuantity = 10,
        //    //        CategoryId = category.Id
        //    //    },
        //    //    new Product
        //    //    {
        //    //        Name = "Monitor",
        //    //        Description = "4K Monitor",
        //    //        Price = 15000,
        //    //        StockQuantity = 2,
        //    //        CategoryId = category.Id
        //    //    }
        //    //);

        //    //context.SaveChanges();


        //    //Console.WriteLine("Out of stock products:");
        //    //var outOfStock = store.ShowProductOutOfStock();
        //    //foreach (var p in outOfStock)
        //    //{
        //    //    Console.WriteLine($"{p.Id} {p.Name} {p.Price}");
        //    //}

        //    //Console.WriteLine("\nTop 3 expensive products:");
        //    //var top3 = store.GetTop3ExpensiveProducts();
        //    //foreach (var p in top3)
        //    //{
        //    //    Console.WriteLine($"{p.Name} - {p.Price}");
        //    //}

        //    //store.DeleteProduct(1);

        //    //store.ChangeName(2);


        //    //store.ChangeQuantity(3);

        //}
        //;
    }
}
