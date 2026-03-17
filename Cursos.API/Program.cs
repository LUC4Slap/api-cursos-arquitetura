using Cursos.API.Configuration;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddCors();
builder.Services.ApiConfig(config);
builder.Services.ResolveDependencies(configuration: config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();


app.Run();
