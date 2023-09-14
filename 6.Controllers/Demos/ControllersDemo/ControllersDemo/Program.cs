using ControllersDemo.Controllers;

var builder = WebApplication.CreateBuilder(args);

//WE CAN USE OUR CONTROLLER BY ADDING IT TO THE SERVICES.
//THIS APPROACH, HOWEVER, WE WILL NEED TO ADD EACH CONTROLLER MANUALLY.
//builder.Services.AddTransient<HomeController>();

//WE CAN USE A SIMPLER WAY TO ADD MULTIPLE CONTROLLERS.
//THIS ADDS ALL THE CONTROLLER CLASSES AS SERVICES.
builder.Services.AddControllers();

var app = builder.Build();

//THIS IS THE LONGER WAY OF ADDING ROUTING FOR OUR ACTION METHODS

//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    //THIS WILL PICK UP ALL THE CONTROLLERS AND THE ACTION METHODS WITHIN THE CONTROLLERS.
//    //IT ENABLES THE ROUTING FOR EACH ACTION METHOD.
//    endpoints.MapControllers(); 
//});

//WE CAN SIMPLIFY THE ABOVE INTO ONE STATEMENT DIRECTLY
app.MapControllers();

app.Run();
