using CRUDPersonCleanArchitecture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});




builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
        ));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // URL de Swagger UI (puedes personalizar esta ruta)
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person Catalog API v1");
        c.RoutePrefix = string.Empty;  // Dejar la interfaz de Swagger en la ruta raíz
    });
}

app.UseHttpsRedirection();
    
//app.UseAuthorization();

app.MapControllers();

app.Run();
