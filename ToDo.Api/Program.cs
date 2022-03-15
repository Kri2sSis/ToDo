using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess.MSSQL;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Api;
using ToDo.Core.Repositories;
using ToDo.DataAccess.MSSQL.Repositories;
using ToDo.Core.Services;
using ToDo.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ContractMapperProfile>();
    cfg.AddProfile<EntityMapperProfile>();

});

builder.Services.AddScoped<IUserRepositorie, UserRepositorie>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDo"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
