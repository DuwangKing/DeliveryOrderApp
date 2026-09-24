# DeliveryOrderApp

Веб-приложение для управления заказами на доставку.

## Описание

Приложение позволяет создавать заказы на доставку, просматривать список всех заказов и детали конкретного заказа.

## Технологии

- ASP.NET Core 9.0 (MVC)
- Entity Framework Core 9.0
- SQLite
- Razor Pages
- Bootstrap 5
- Docker
- Docker Compose
  
## Как запустить

## Требования

- .NET 9.0 SDK
- Entity Framework Core Tools
- Docker
- Docker Compose

## Инструкция

**Инструкция:**

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/DuwangKing/DeliveryOrderApp.git
   cd DeliveryOrderApp
   ```
2. Создайте файл .env в корне проекта и заполните его переменными окружения:
   POSTGRES_USER=app
   POSTGRES_PASSWORD=secret
   POSTGRES_DB=deliverydb
   DB_HOST=postgres
   DB_PORT=5432
   Примечание: это тестовые данные. .env файл был добавлен в .gitignore ради безопасности
   
3. Соберите и запустите контейнеры:
   ```bash
      docker compose up -d --build
   ```
4. Откройте в браузере: http://localhost:5000/Orders

## Планы по улучшению

-Юнит-тесты: Покрытие бизнес-логики тестами с использованием xUnit и Moq

-Мокирование базы данных: Использование InMemory-провайдера EF Core для изолированного тестирования без реальной БД

-Пагинация: Разбиение списка заказов на страницы, чтобы не выгружать все записи из БД сразу(Сделано)

-Слой сервисов: Вынос логики из контроллера в отдельный сервисный слой (IOrderService)(Сделано)

-Docker контейнеризация: Упаковка приложения в Docker контейнер(Сделано)
