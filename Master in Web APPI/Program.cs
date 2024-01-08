var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/shirts", () =>
{
    return "Reading all shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading single shirt with id:{id}";
});

app.MapPost("/shirts", (object obj) =>
{
    return $"Added a new shirt with shirt obj {obj}";
});

app.MapPut("/shirts/{id}", (int id) =>
{
    return $"Updated the shirt with Id:{id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Deleted a shirt with id:{id}";
});

app.Run();
