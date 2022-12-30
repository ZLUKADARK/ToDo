using Microsoft.EntityFrameworkCore;
using ToDo.BLL.Automapper;
using ToDo.BLL.Interfaces;
using ToDo.BLL.Modules;
using ToDo.BLL.Services;
using ToDo.DAL.Data;
using ToDo.DAL.Interfaces;
using ToDo.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//База данных SqlServer в "builder.Configuration["DB"]" в файле appsetings.json прописана строка подключения к локальной БД 
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration["DB"]));

//Автомаппер
builder.Services.AddAutoMapper(typeof(UserTaskProfile));

//Services
builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
builder.Services.AddScoped<IUserTaskServices, UserTaskServices>();
builder.Services.AddHostedService<TasksRemover>();

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
