using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using T5S.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      policy =>
      {
          policy.WithOrigins("http://localhost:4200"
                  ).AllowAnyHeader()
                           .AllowAnyMethod();
      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<T5sContext>(options => options.UseSqlServer("Server=DESKTOP-QO3RBTB;Database=T5S; Trusted_Connection=true;MultipleActiveResultSets=true"));

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
app.UseCors();

app.Run();
