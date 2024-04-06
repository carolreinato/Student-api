using Microsoft.EntityFrameworkCore;
using Student.Domain.Interfaces.Repositories;
using Student.Domain.Interfaces.Services;
using Student.Domain.Interfaces.Validators;
using Student.Infra.Data.Context;
using Student.Infra.Data.Repository;
using Student.Service.AutoMapper;
using Student.Service.Services;
using Student.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseNpgsql(builder.Configuration["DefaultConnection"]);
});

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentValidator, StudentValidator>();
builder.Services.AddAutoMapper(typeof(StudentAutoMapper));

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
