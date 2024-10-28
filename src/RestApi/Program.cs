using Microsoft.EntityFrameworkCore;
using RestApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração da string de conexão com o MySQL
builder.Services.AddDbContext<VendasContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("VendasDB"), 
        new MySqlServerVersion(new Version(8, 0, 21)))); // Altere a versão conforme necessário

// Adiciona serviços para controllers
builder.Services.AddControllers();

// Configuração do Swagger (opcional, para documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para usar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware padrão
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento de rotas
app.MapControllers();

// Inicia a aplicação
app.Run();