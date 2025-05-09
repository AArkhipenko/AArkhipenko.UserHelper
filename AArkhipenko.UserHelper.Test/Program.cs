using AArkhipenko.Keycloak;
using AArkhipenko.UserHelper;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
builder.Configuration.AddYamlFile("DebugConfig.yml", false);
#endif

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddKeycloakAuth(builder.Configuration);
// ƒобавление провайдера дл€ работы с пользовател€ми
builder.Services.AddNpgsqlUserProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
