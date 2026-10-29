using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Middleware;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Retrieve and validate connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register DbContext with SQL Server configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Register Repositories and Services for Dependency Injection
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();

builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<DirectorService>();

builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<ActorService>();

builder.Services.AddScoped<ConsoleMenuService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// 3. Register Global Exception Handling Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 4. Run Interactive Console Menu Loop
using (var scope = app.Services.CreateScope())
{
    var menuService = scope.ServiceProvider.GetRequiredService<ConsoleMenuService>();
    await menuService.RunAsync();
}