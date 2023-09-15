using Microsoft.AspNetCore.Mvc;
using ControllersDemo.Models;
using Microsoft.AspNetCore.StaticFiles;

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
            return Content("Hello World", "text/plain");
        }

        //[Route("about")]
        public ContentResult About()
        {
           
            return Content("<h1>About</h1>", "text/html");
        }

        //[Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() { Id = Guid.NewGuid(), FirstName = "Chichi", LastName = "Flores", Age = 3 };

            //THE JsonResult WILL RETURN THE person OBJECT AS A JSON OBJECT IN THE RESPONSE BODY.
            //return new JsonResult(person);

            //JUST LIKE WITH ContentResult, THE CONTROLLER BASE CLASS GIVES A SIMPLER WAY TO RETURN A JSON OBJECT
            return Json(person);

        }


        //WE CAN ALSO SPECIFY OUR CONSTRAINTS IN ATTRIBUTE ROUTING.
        [Route("contact/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Contact";
        }

        //VirtualFileResult RETURNS FILES FROM wwwroot FOLDER
        [Route("download-file")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("Victor-Flores-Resume.docx", GetMIMEType("Victor-Flores-Resume.docx"));

            //WE CAN ALSO USE THE SIMPLER WAY:
            return File("Victor-Flores-Resume.docx", GetMIMEType("Victor-Flores-Resume.docx"));

        }

        //PhysicalFileResult RETURNS FILE OUTSIDE OF wwwroot FOLDER USING ABSOLUTE PATH
        [Route("download-physical-file")]
        public PhysicalFileResult PhysicalFileDownload()
        {
            //return new PhysicalFileResult(@"C:\Users\Vic\Downloads\pic1.jpg", GetMIMEType("pic1.jpg"));

            //Simpler:
            return PhysicalFile(@"C:\Users\Vic\Downloads\pic1.jpg", GetMIMEType("Victor-Flores-Resume.docx"));
        }
        //FileContentResult RETURNS A BINARY FILE AS A RESPONSE.
        //IT TAKES THE FILE CONTENTS, SUCH AS A byte[].
        [Route("/download-bytearray-file")]
        public FileContentResult FileContentDownload()
        {
            //System.IO.File.ReadAllBytes WILL READ ALL THE BYTES FROM A FILE AND RETURN A byte[].
            byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\Users\Vic\Downloads\pic1.jpg");
            //return new FileContentResult(byteArray, GetMIMEType("pic1.jpg"));

            //Simpler:
            return File(byteArray, GetMIMEType("pic1.jpg"));
        }

        private static string GetMIMEType(string fileName)
        {
            const string DefaultContentType = "application/octet-stream";

            string contentType;

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }

    }
}
