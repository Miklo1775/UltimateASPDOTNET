using Microsoft.AspNetCore.Mvc;

namespace ControllersDemo.Controllers
{
    //ASP.NET WILL AUTOMATICALLY CONVERT THE CLASS INTO A CONTROLLER IF WE SUFFIX OUR CLASSNAME WITH CONTROLLER: e.g HomeController, UserController, AdminController
    public class HomeController : Controller
    {
        //WHEN WRITING OUR ROUTES LIKE THIS [Route(")], THIS IS CALLED ATTRIBUTE ROUTING.
        //WHATEVER IS RETURNED FROM THE ACTION METHOD WILL BE RETURNED TO THE BROWSER AS THE RESPONSE.
        //SO WHEN WE GO TO THE ROUTE DEFINED BELOW, THE ACTION METHOD method1 WILL BE INVOKED AND THE RETURNED STRING WILL BE SENT TO THE BROWSER.
        //WE CAN ALSO DEFINE MULTIPLE ROUTES FOR THE SAME ACTION METHOD.
        //[Route("say-hello1")]
        //[Route("/")]
        //public string method1()
        //{
        //    return "Hello from method1";
        //}

        //IT IS CONVENTIONAL TO NAME THE FIRST IAction METHOD AS INDEX.

        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //ContentResult RETURNS THE CONTENT AS WELL AS THE CONTENT-TYPE
            //Content WILL BE ADDED TO THE RESPONSE BODY.
            //ContentType WILL BE ADDED TO THE RESPONSE HEADER.
            //return new ContentResult() 
            //{Content = "<h1>INDEX</h1>", ContentType = "text/html" };

            //THERE IS A SIMPLER WAY TO RETURN THE ContentResult.
            //TO USE THE SIMPLER WAY, WE NEED TO IMPLEMENT THE Controller BASE CLASS.
            return Content("<h1>Hello World</h1>", "text/html");
        }

        [Route("about")]
        public string About()
        {
            return "About";
        }

        //WE CAN ALSO SPECIFY OUR CONSTRAINTS IN ATTRIBUTE ROUTING
        [Route("contact/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Contact";
        }
    }
}
