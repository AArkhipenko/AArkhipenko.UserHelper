# AArkhipenko.UserHelper

Nuget-проект с настройками программой, котора позволяет определить пользователя по токену.


## Методы расширения

Все методы расширения находятся [здесь](./AArkhipenko.UserHelper/UserHelperExtension.cs)

### Программа для определения пользователя

Подключение:
```C#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
...
// Регистрация программы для определения пользователя
builder.Services.AddUserHelper(builder.Configuration);
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
UserHelper:
  UserService:
    Url: http://user-service.url
...
```