using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5115", "https://localhost:7296");

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Make JSON property name matching case-insensitive
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        // Handle circular references by ignoring them
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        // Optional: Write indented JSON for better readability during development
        options.JsonSerializerOptions.WriteIndented = true;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow requests from UI.Web
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebUI", policy =>
    {
        policy.WithOrigins("http://localhost:5200", "https://localhost:7200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowWebUI");

app.UseAuthorization();

app.MapControllers();

// Initialize sample data
try
{
    Negocio.LogicaUsuario.CrearUsuariosEjemplo();
    Negocio.LogicaSalon.CrearDatosEjemplo();
    Negocio.LogicaDj.CrearDatosEjemplo();
    Negocio.LogicaGastronomico.CrearDatosEjemplo();
}
catch (Exception ex)
{
    Console.WriteLine($"Error initializing sample data: {ex.Message}");
}

app.Run();
