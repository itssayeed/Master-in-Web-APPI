using Master_in_Web_APPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShirtStoreManagement"));
});
// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Minimal Api's
//=============
//app.MapGet("/shirts", () =>
//{
//    return "Reading all shirts";
//});

//app.MapGet("/shirts/{id}", (int id) =>
//{
//    return $"Reading single shirt with id:{id}";
//});

//app.MapPost("/shirts", (object obj) =>
//{
//    return $"Added a new shirt with shirt obj {obj}";
//});

//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"Updated the shirt with Id:{id}";
//});

//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"Deleted a shirt with id:{id}";
//});
app.MapControllers();
app.Run();
