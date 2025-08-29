var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddLogging();

var app = builder.Build();

// Middleware pipeline
app.UseMiddleware<userMan.Middleware.ErrorHandlingMiddleware>();
app.UseMiddleware<userMan.Middleware.TokenAuthMiddleware>();
app.UseMiddleware<userMan.Middleware.LoggingMiddleware>();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();