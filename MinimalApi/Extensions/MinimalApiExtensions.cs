using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MinimalApi.Abstractions;
using Microsoft.OpenApi.Models;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {

            var cs = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePost).GetTypeInfo().Assembly));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            // Add Swagger configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pmailerin's Minimal API Project", Version = "v1" });
            });

        }

        public static void RegisterEndPointDefinitions(this WebApplication app)
        {
            var endPointDefinitions = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDef in endPointDefinitions)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
    }
}
