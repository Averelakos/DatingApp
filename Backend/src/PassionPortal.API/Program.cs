using PassionPortal.API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);
WebApplication? app = builder.Build();
app.Configure(app.Environment);
app.MapControllers();
app.Run();



