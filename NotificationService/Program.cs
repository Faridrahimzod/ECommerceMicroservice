using NotificationService.Services;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем сервисы
builder.Services.AddScoped<NotificationSender>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();