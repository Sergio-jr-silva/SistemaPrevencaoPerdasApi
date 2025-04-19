using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Adiciona o banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços de controlador
builder.Services.AddControllers();

// Adiciona e configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita o Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/teste-conexao", async (AppDbContext db) =>
{
    var existeTabela = await db.Database.CanConnectAsync();
    return Results.Ok(existeTabela ? "Conexão OK!" : "Erro na conexão");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
