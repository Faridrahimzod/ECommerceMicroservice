using ProductService.Models;

namespace ProductService.Services;

public class ProductRepository
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public ProductRepository()
    {
        AddProduct(new Product { Name = "Ноутбук", Price = 999.99m, Stock = 10 });
        AddProduct(new Product { Name = "Смартфон", Price = 699.99m, Stock = 25 });
    }

    public IEnumerable<Product> GetAllProducts() => _products;

    public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public Product AddProduct(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public bool UpdateProduct(int id, Product updatedProduct)
    {
        var product = GetProductById(id);
        if (product == null) return false;

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Stock = updatedProduct.Stock;
        return true;
    }
}