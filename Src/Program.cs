internal class Program
{
    // RUN:  docker run minimalapi:1.0 -it ––name minimalapiapp ––p 5237:5237
    // Test: http://localhost:5237/
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}