using OrderService.Services;
using Swashbuckle.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем HTTP-клиент для ProductService
builder.Services.AddHttpClient("ProductService", client =>
{
    client.BaseAddress = new Uri("http://productservice:80"); // Для Docker
    // Или для локальной разработки:
    // client.BaseAddress = new Uri("http://localhost:5001");
});

builder.Services.AddSingleton<OrderRepository>();
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