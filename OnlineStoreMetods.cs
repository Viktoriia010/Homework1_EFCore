using OnlineStore.Context;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore;

public class OnlineStoreMetods
{
    private readonly OnlineStoreDBContext _context;

    public OnlineStoreMetods(OnlineStoreDBContext context)
    {
        _context = context;
    }
    public void CreateProduct()
    {
        var product = new Product();
        Console.WriteLine("Enter name: ");
        product.Name = Console.ReadLine();
        Console.WriteLine("Enter description: ");
        product.Description = Console.ReadLine();
        Console.WriteLine("Enter price: ");
        product.Price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter stock quantity: ");
        product.StockQuantity = int.Parse(Console.ReadLine());
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void ChangeName(int pId)
    {
        var product = _context.Products.Find(pId);
        if (product != null)
        {
            Console.WriteLine("Enter new name: ");
            product.Name = Console.ReadLine();
            _context.SaveChanges();
        }
    }

    public void ChangeQuantity(int pId)
    {
        var product = _context.Products.Find(pId);
        if (product != null)
        {
            Console.WriteLine("Enter stock quantity: ");
            product.StockQuantity = int.Parse(Console.ReadLine());
            _context.SaveChanges();
        }

    }

    public void DeleteProduct(int ProductId)
    {
        var product = _context.Products.Find(ProductId);
        if (product != null)
        {
            _context.Products.Remove(product);
            Console.WriteLine($"Product {product.Name} is deleted");
            _context.SaveChanges();
        }
    }

    public List<Product> ShowProductOutOfStock()
    {
        return _context.Products
            .Where(p => p.StockQuantity == 0)
            .ToList();
    }

    public List<Product> GetTop3ExpensiveProducts()
    {
        return _context.Products
            .OrderByDescending(p => p.Price)
            .Take(3)
            .ToList();
    }
}
