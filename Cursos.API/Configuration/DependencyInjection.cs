using Common.EncriptyPass.Logic.Interfaces;
using Common.EncriptyPass.Logic.Services;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Services.Logic.Interfaces;
using Services.Logic.Services;

namespace Cursos.API.Configuration;

public static class DependencyInjection
{
    public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            }, ServiceLifetime.Scoped
        );
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IIncryptService, IncryptService>();
        services.AddScoped<ICursosService, CursoService>();
        services.AddScoped<IUsuarioCursoService, UsuarioCursoService>();
    }
}