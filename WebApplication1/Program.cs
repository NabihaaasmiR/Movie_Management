using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Register DbContext with SQL Server connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register Repositories and Services for Dependency Injection
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<ConsoleMenuService>();

// Optional: Keep API controllers and Swagger configured if you switch back to Web API later
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 3. Run the Interactive Console Menu Loop on startup
using (var scope = app.Services.CreateScope())
{
    var menuService = scope.ServiceProvider.GetRequiredService<ConsoleMenuService>();
    await menuService.RunAsync();
}