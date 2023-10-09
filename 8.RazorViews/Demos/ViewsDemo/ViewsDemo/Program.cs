var builder = WebApplication.CreateBuilder(args);
//ENABLES THE CONTROLLERS & VIEWS
//WE DON'T HAVE TO USE THE .AddControllers WHEN USING THIS SERVICE
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
