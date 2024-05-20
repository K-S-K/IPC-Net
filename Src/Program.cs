using NSwag.AspNetCore;


internal class Program
{
    // RUN:  docker run minimalapi:1.0 -it ––name minimalapiapp ––p 5237:5237
    // Doc:  http://localhost:5237/swagger
    // Test: http://localhost:5237/
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        /// Enables the API Explorer, 
        /// which is a service that provides metadata about the HTTP API. 
        /// The API Explorer is used by Swagger to generate the Swagger document.
        builder.Services.AddEndpointsApiExplorer();

        /// Adds the Swagger OpenAPI document generator 
        /// to the application services and configures it 
        /// to provide more information about the API, 
        /// such as its title and version.
        /// For the further details, look at https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-8.0#customize-api-documentation
        builder.Services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "IPC-Net";
            config.Title = "IPC-Net v1";
            config.Version = "v1";
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi(config =>
            {
                config.DocumentTitle = "IPC-Net API";
                config.Path = "/swagger";
                config.DocumentPath = "/swagger/{documentName}/swagger.json";
                config.DocExpansion = "list";
            });
        }

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}