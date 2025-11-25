var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5115", "https://localhost:7296");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Initialize sample data
try
{
    Negocio.LogicaSalon.CrearDatosEjemplo();
    Negocio.LogicaDj.CrearDatosEjemplo();
    Negocio.LogicaGastronomico.CrearDatosEjemplo();
}
catch (Exception ex)
{
    Console.WriteLine($"Error initializing sample data: {ex.Message}");
}

app.Run();
