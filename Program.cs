using api.Data;
using api.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TodoApi.Interfaces;
using TodoApi.Models;
using TodoApi.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDBContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IGuardRepository, GuardRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

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
