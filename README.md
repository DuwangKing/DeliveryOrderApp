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

## Как запустить

## Требования

- .NET 9.0 SDK
- Entity Framework Core Tools


## Инструкция
1. Установить EF Core Tools:
 -bash
  dotnet tool install --global dotnet-ef

2. Клонируйте репозиторий:
  git clone https://github.com/DuwangKing/DeliveryOrderApp.git
  cd DeliveryOrderApp

3. Восстановите зависимости:
   dotnet restore
   
4. Создайте базу данных:
   dotnet ef database update

5. Запустите приложение:
   dotnet run

6. Откройте в браузере: https://localhost:5001/Orders или http://localhost:5000/Orders

## Планы по улучшению

-Юнит-тесты: Покрытие бизнес-логики тестами с использованием xUnit и Moq

-Мокирование базы данных: Использование InMemory-провайдера EF Core для изолированного тестирования без реальной БД

-Пагинация: Разбиение списка заказов на страницы, чтобы не выгружать все записи из БД сразу

-Слой сервисов: Вынос логики из контроллера в отдельный сервисный слой (IOrderService)
  
