using AspNetCore.Services.Context;
using AspNetCore.Services.Interfaces;
using AspNetCore.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "localhost";

//Criado contexto InMemory
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

//Criado acesso da api para a rota local
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:3000").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClientRepository, ClientServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetService<AppDbContext>();
//Inserção de dados para o banco local
//static void DefaultDatabase(AppDbContext context)
//{
//    context.Database.EnsureCreated();
//    var testClient = new Client
//    {
//        Id = 1,
//        Name = "Teste",
//        Email = "teste@teste.com",
//        Address = "Street Teste, 80",
//        Phone = "8889990"
//    };
//    context.Clients.Add(testClient);
//    context.SaveChanges();
//}
////Inicializado o contexto com os dados
//DefaultDatabase(service);

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
