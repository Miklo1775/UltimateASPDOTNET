
//INCASE WE WANT TO USE OUR OWN CUSTOM ROOT FOLDER, WE MUST CONFIGURE IT IN THE CREATE BUILDER.
//IN THIS EXAMPLE, INSTEAD OF wwwroot I AM USING A FOLDER NAMED public LIKE IN JAVASCRIPT.
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "public"
});

var app = builder.Build();

//ENABLING STATIC FILES
//IF WE WANT TO USE MORE THAN 1 STATIC FILES FOLDER, WE NEED TO CALL UseStaticFiles() TWICE.
app.UseStaticFiles(); // serves up default or 1st WebRoot folder defined.
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
            $"{builder.Environment.ContentRootPath}\\otherpublic"
        )

    //FileProvider = new PhysicalFileProvider(
    //        Path.Combine(builder.Environment.ContentRootPath, "otherpublic")
    //    )

}); //serves up "otherpublic" folder

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Home Page");
    });

    endpoints.Map("my-portfolio", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Portfolio Page");
    });
});

app.Run();
