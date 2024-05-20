using NSwag.AspNetCore;


internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        ConfigureSwagger(builder);

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            SubscribeToSwagger(app);
        }

        app.MapGet("/", RootPage);

        app.Run();
    }

    private static void SubscribeToSwagger(WebApplication app)
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

    private static void ConfigureSwagger(WebApplicationBuilder builder)
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

    private static async Task RootPage(HttpResponse responce, HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=UTF-8";
        await context.Response.WriteAsync("Hello World!");

        Console.WriteLine("Root asked");
    }
}