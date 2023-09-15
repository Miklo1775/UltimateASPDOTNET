using Microsoft.AspNetCore.Mvc;

namespace IActionResultDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("/book")]
        public IActionResult Index()
        {
            //A MAIN REASON IT IS RECOMMENDED TO SPECIFY THE RETURN TYPE AS IActionResult IS BECAUSE YOU CAN RETURN DIIFERENT TYPES OF RESULTS.
            //THE EXAMPLE BELOW ILLUSTRATES THAT WE ARE RETURN CONTENTRESULT DEPENDING ON AN ERROR, AND IF NO ERROR OCCURS, WE ARE RETURNING A VIRTUALFILERESULT TYPE. 
            //C# DOESN'T ALLOW US TO EXPLICITLY RETURN 2 DATA TYPES. TO BE ABLE TO DO THAT, WE NEED TO USE THE PARENT CLASS OF THOSE 2 TYPES, FOR EXAMPLE IACTIONRESULT WHICH IS THE PARENT CLASS OF CONTENTRESULT AND VIRTUALFILERESULT

            //bookid should be applied
            if (!Request.Query.ContainsKey("bookid")){
                //return Content("Book id is not supplied");

                //INSTEAD OF SETTING THE STATUS CODE MANUALLY, WE CAN USE THE BadRequestResult().
                //FROM HERE ON FORWARD, THESE RETURNED RESULTS WILL HAVE A SIMPLER METHOD AS WELL UNLESS STATED OTHERWISE.
                //return new BadRequestResult();
                //IF USING STATUSCODE() THE RESPONSE BODY WILL AUTOMATICALLY BE EMPTY
                //return StatusCode(401);
                return BadRequest("Bookid is not supplied.");

            }

            //bookid can't be null or empty
            if (String.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Bookid cannot be null or empty");
            }

            //book id should be between 1 to 1000
            int bookId = Convert.ToInt32(Request.Query["bookid"]);

            if(bookId < 1 || bookId > 1000) 
            {
                return NotFound("Book id can't be less than 1 or greater than 1000");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                return Unauthorized("User must be authenticated");
            }

            return File("/Victor-Flores-Resume.pdf", "application/pdf");

        }
    }
}
