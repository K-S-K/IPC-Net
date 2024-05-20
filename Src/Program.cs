using NSwag.AspNetCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureSwagger();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.SubscribeToSwagger();
        }

        app.MapGet("/", RootPage);

        app.Run();
    }

    private static async Task RootPage(HttpResponse responce, HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=UTF-8";
        await context.Response.WriteAsync("Hello World!");

        Console.WriteLine("Root asked");
    }
}