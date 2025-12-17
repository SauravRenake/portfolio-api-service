using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Interface;
using Portfolio.Service;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Controllers
builder.Services.AddControllers();

// 🔹 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 DI
builder.Services.AddScoped<IProfileService, ProfileService>();

var app = builder.Build();

// 🔹 Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔹 THIS IS THE MOST COMMONLY MISSED LINE
app.MapControllers();

app.Run();
