using System.Reflection;
using FluentValidation;
using MediatR;
using Seventh.Desafio.Api.Middlewares;
using Seventh.Desafio.Api.Pipelines;
using Seventh.Desafio.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfraContext(connectionString);

// Configurar MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Configurar AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Adicionando configuração: FluentValidation
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipeline<,>));

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();

