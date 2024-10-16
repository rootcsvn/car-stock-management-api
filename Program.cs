var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Enable support for controllers
builder.Services.AddEndpointsApiExplorer(); // Configure API endpoint exploration
builder.Services.AddSwaggerGen(); // Enable Swagger generation

// Register CarService as a dependency injection service
builder.Services.AddSingleton<ICarService, CarService>(); // Add the car service as singleton (in-memory storage stays active for the app lifetime)

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger only in development
    app.UseSwaggerUI(); // Swagger UI to explore and test API endpoints
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.UseAuthorization(); // Enable Authorization middleware (optional if you implement authentication)

app.MapControllers(); // Map routes to controller actions

app.Run(); // Start the application