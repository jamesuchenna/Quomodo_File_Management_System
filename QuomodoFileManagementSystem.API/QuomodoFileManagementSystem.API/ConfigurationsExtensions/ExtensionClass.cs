using Microsoft.OpenApi.Models;
using System.Reflection;

namespace QuomodoFileManagementSystem.API.ConfigurationsExtensions
{
    public static class ExtensionClass
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            // This method gets called by the runtime from the startup "ConfigureServices()" to add swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Quomodo-File-Management- System Api",
                    Description = "This Api will be responsible for creating files and folder",
                    Contact = new OpenApiContact
                    {
                        Name = "File-Management Api",
                        Email = "jamesuchennachi@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "File-Management Api",
                        //Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
