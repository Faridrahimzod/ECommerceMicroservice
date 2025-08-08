namespace NotificationService.Services;

public class NotificationSender
{
    private readonly ILogger<NotificationSender> _logger;

    public NotificationSender(ILogger<NotificationSender> logger)
    {
        _logger = logger;
    }

    public async Task SendAsync(string message)
    {
        // Имитация отправки уведомления
        _logger.LogInformation($"Sending notification: {message}");
        await Task.Delay(100); // Имитация задержки
        _logger.LogInformation("Notification sent!");
    }
}