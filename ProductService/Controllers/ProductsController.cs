using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }

    // GET: api/products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        return Ok(_repository.GetAllProducts());
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _repository.GetProductById(id);
        return product == null ? NotFound() : Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public ActionResult<Product> CreateProduct([FromBody] Product product)
    {
        var createdProduct = _repository.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct),
            new { id = createdProduct.Id }, createdProduct);
    }

    // PUT: api/products/5
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product product)
    {
        return _repository.UpdateProduct(id, product)
            ? NoContent()
            : NotFound();
    }
}