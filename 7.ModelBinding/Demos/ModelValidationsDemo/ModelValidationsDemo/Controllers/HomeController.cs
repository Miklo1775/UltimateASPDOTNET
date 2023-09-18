using Microsoft.AspNetCore.Mvc;
using ModelValidationsDemo.Models;

namespace ModelValidationsDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            //ModelState.IsValid WILL RETURN TRUE IF NO ERRORS OR FALSE IF ATLEAST ONE ERROR
            if(!ModelState.IsValid)
            {
                //List<string> errorsList = new List<string>();
                ////WE LOOP THROUGH EACH VLAUE/PROPERTY IN THE MODELSTATE
                //foreach (var value in ModelState.Values)
                //{
                //    //WE LOOP THROUGH EACH ERROR FOR EACH VALUE/PROPERTY
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}

                //WE CAN DO THE ABOVE LOOPS SHORTER USING LINQ
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));

                //JOINING ERRORS WITH A NEW LINE
                //string errors = string.Join("\n", errorsList);
                //SENDING ERRORS ALONG WITH 400 BAD REQUEST
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
