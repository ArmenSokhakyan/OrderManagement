using Microsoft.Extensions.Configuration;
using OrderManagement.Application;
using OrderManagement.Core.Inteface;
using OrderManagement.Persistence;
using OrderManagement.Persistence.Data.Repository.Mongo;
using OrderManagement.Presentation.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies(builder.Configuration);

builder.Services.AddScoped<IOrderRepository, OrderMongoRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemMongoRepository>();
builder.Services.AddScoped<IProductRepository, ProductMongoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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
