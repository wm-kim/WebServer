using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ApplicationDbContext ������ �ϰڴٰ� ������ ���ÿ� DB�� SQL Server�� ������ �ϰڴٰ� �ɼ��� ������
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
