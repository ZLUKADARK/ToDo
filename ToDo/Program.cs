using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//База данных SqlServer в "builder.Configuration["DB"]" в файле appsetings.json прописана строка подключения к локальной БД 
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration["DB"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
