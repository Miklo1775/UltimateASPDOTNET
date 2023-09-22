using ModelValidationsDemo.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    //ADDING OUR CUSTOM MODEL BINDER PROVIDER
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});

//THIS ENABLES THE XML INPUT FORMATTERS.
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
