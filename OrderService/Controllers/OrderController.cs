using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;
using System.Net;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderRepository _orderRepository;
    private readonly IHttpClientFactory _httpClientFactory;

    public OrdersController(
        OrderRepository orderRepository,
        IHttpClientFactory httpClientFactory)
    {
        _orderRepository = orderRepository;
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto dto)
    {
        var productClient = _httpClientFactory.CreateClient("ProductService");
        var productResponse = await productClient.GetAsync($"/api/products/{dto.ProductId}");

        if (productResponse.StatusCode == HttpStatusCode.NotFound)
            return BadRequest("Товар не найден");

        var order = new Order
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity
        };
        _orderRepository.CreateOrder(order);

        var notificationClient = _httpClientFactory.CreateClient();
        await notificationClient.PostAsJsonAsync(
            "http://notificationservice/api/notifications",
            new { Message = $"Order #{order.Id} created!" });

        return Ok(order);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(Guid id)
    {
        var order = _orderRepository.GetOrder(id);
        return order == null ? NotFound() : Ok(order);
    }
}