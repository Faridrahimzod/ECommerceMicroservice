# ECommerceMicroservices

## Общее описание
Проект реализует микросервисную архитектуру для интернет-магазина с использованием .NET 8 и Docker. Система состоит из четырех основных сервисов:

## Технологический стек
- **Язык программирования**: C# (.NET 8)
- **Архитектура**: Микросервисы
- **API Gateway**: Ocelot
- **Контейнеризация**: Docker
- **Взаимодействие**: HTTP/REST API
- **Документация API**: Swagger

##  Структура проекта
```
ECommerceMicroservices/
├── ProductService/ # Сервис управления товарами
├── OrderService/ # Сервис обработки заказов
├── NotificationService/ # Сервис уведомлений
├── ApiGateway/ # API Gateway (Ocelot)
└── docker-compose.yml # Оркестрация контейнеров
```


## Подробное описание компонентов

### 1. ProductService
**Назначение**: Управление каталогом товаров.

**Реализация**:
- REST API (CRUD операции)
- In-memory хранилище (для демонстрации)
- Swagger документация

**Dockerfile**:
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
...
ENTRYPOINT ["dotnet", "ProductService.dll"]
```
### 2. OrderService
**Назначение**: Обработка заказов.

**Особенности**:
- Взаимодействие с ProductService через HTTP
- Отправка уведомлений через NotificationService
- Валидация заказов

Интеграция:
```csharp
var response = await _httpClient.GetAsync("http://productservice/api/products/1");
```
### 3. NotificationService
**Назначение**: Отправка уведомлений.

**Функционал**:
- Логирование уведомлений
- Подготовка к интеграции с email/SMS сервисами

### 4. ApiGateway (Ocelot)
**Конфигурация (ocelot.json)**:
```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/products",
      "UpstreamPathTemplate": "/products",
      ...
    }
  ]
}
```
## Docker-развертывание
docker-compose.yml:
```yaml
services:
  productservice:
    build: ./ProductService
    ports: ["5001:80"]
    
  apigateway:
    depends_on: [productservice, orderservice]
    ports: ["5000:80"]
```

## Использованные паттерны
- **Микросервисная архитектура**
- **API Gateway**
- **Dependency Injection**
- **Repository Pattern**
- **RESTful API**

## Разоработчик:
**Рахимзода Фаридун**



