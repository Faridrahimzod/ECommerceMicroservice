using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Services;

namespace NotificationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly NotificationSender _sender;

    public NotificationsController(NotificationSender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] NotificationDto dto)
    {
        await _sender.SendAsync(dto.Message);
        return Ok(new { Status = "Notification queued" });
    }
}