var builder = WebApplication.CreateBuilder(args);
//ENABLES THE CONTROLLERS & VIEWS
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
