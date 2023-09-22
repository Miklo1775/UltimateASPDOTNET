var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//THIS ENABLES THE XML INPUT FORMATTERS.
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
