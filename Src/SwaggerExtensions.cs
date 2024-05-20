public static class SwaggerExtensions
{
    internal static void SubscribeToSwagger(this WebApplication app)
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

    internal static void ConfigureSwagger(this WebApplicationBuilder builder)
    {
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
    }
}