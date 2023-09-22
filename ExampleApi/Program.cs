using ExampleApi.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAuthService();
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
