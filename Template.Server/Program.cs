using Microsoft.EntityFrameworkCore;

using Template.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Configura e regista o DbContext (TemplateContext) no contêiner de dependências
// Define o provedor SQL Server utilizando a ConnectionString "DefaultConnection" definida no appsettings.json
// Ativa a exibição de dados sensíveis (parâmetros de queries SQL) nos logs de depuração
builder.Services.AddDbContext<TemplateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging());

// Adiciona os serviços necessários para suportar o uso de Controllers da API
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();

app.MapStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();