# AArkhipenko.UserHelper

Nuget-проект с настройками провайдера для работы с пользователем.


## Методы расширения

Все методы расширения находятся [здесь](./AArkhipenko.UserHelper/UserHelperExtension.cs)

### Провайдер для работы с пользователем (PostgreSQL)

Подключение:
```C#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
...
// Добавление провайдера для работы с пользователями
builder.Services.AddNpgsqlUserProvider();
...
var app = builder.Build();
app.UseAuthorization();
...
app.MapControllers();

app.Run();
```

## Раздел с настройками

Для настройки программы провайдер конфигурации должен иметь разделы:
```yml
...
DatabaseSettings:
    CommandTimeout: 30000

ConnectionStrings:
    UserDb: "Host=aid-kit.arkhipenko.lan;Port=60001;Database=aid_kit_db;Username=application_user;Password=application_user"
...
```