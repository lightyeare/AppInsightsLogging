var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddApplicationInsightsTelemetry(new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions
{
    ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]
});

builder.Logging.ClearProviders();
builder.Logging.AddApplicationInsights();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/log/{id}", async (int id, ILogger<Program> logger, HttpResponse response) =>
{
    logger.LogInformation("Testing logging in Program.cs");
    try
    {
        throw new ArgumentException("Invalid ID","id");
    }
    catch (Exception ex)
    {
        logger.LogError("Message template with exception | There has been an error for id {id}: {exception}", id, ex); 
        logger.LogError($"String interpolation | There has been an error for id {id}: {ex}");
        logger.LogError(ex, "Message template, exception as parameter | There has been an error for id {id}", id);
    }

    await response.WriteAsync("Success?");
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
