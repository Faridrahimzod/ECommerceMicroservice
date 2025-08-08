using OrderService.Models;

namespace OrderService.Services;

public class OrderRepository
{
    private readonly List<Order> _orders = new();

    public Order CreateOrder(Order order)
    {
        _orders.Add(order);
        return order;
    }

    public Order? GetOrder(Guid id) => _orders.FirstOrDefault(o => o.Id == id);
}