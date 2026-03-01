using OnlineStore.Context;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore;

public class Shop
{
    private readonly OnlineStoreDBContext _context;

    public Shop(OnlineStoreDBContext context)
    {
        _context = context;
    }

    public void CreateProduct()
    {
        var product = new Product();
        Console.Write("Enter name: ");
        product.Name = Console.ReadLine();
        Console.Write("Enter description: ");
        product.Description = Console.ReadLine();
        Console.Write("Enter price: ");
        product.Price = decimal.Parse(Console.ReadLine());
        Console.Write("Enter stock quantity: ");
        product.StockQuantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Product created");
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void CreateCategory()
    {
        var category = new Category();
        Console.Write("Enter name: ");
        category.Name = Console.ReadLine();
        Console.WriteLine("Category created");
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void ShowProduct()
    {
        var products = _context.Products.ToList();
        foreach (var item in products)
        {
            Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Description: {item.Description} Price: {item.Price}, Stock: {item.StockQuantity}");
        }
    }

    public void ShowCategory()
    {
        var categories = _context.Categories.ToList();
        foreach (var item in categories)
        {
            Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
        }
    }

    public void UpdateProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            Console.WriteLine("Product not found");
            return;
        }

        Console.Write("Enter name: ");
        product.Name = Console.ReadLine();
        Console.Write("Enter description: ");
        product.Description = Console.ReadLine();
        Console.Write("Enter price: ");
        product.Price = decimal.Parse(Console.ReadLine());
        Console.Write("Enter stock quantity: ");
        product.StockQuantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Product updated");
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            Console.WriteLine("Product not found");
            return;
        }
        Console.WriteLine("Product deleted");
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public void UpdateCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);

        if (category == null)
        {
            Console.WriteLine("Category not found");
            return;
        }

        Console.Write("Enter name: ");
        category.Name = Console.ReadLine();
        Console.WriteLine("Category updated");
        _context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);

        if (category == null)
        {
            Console.WriteLine("Product not found");
            return;
        }
        Console.WriteLine("Category deleted");
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }
}
