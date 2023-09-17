using Microsoft.AspNetCore.Mvc;

namespace ModelBindingDem.Controllers
{
    public class HomeController : Controller
    {
        //IF WE USE ROUTE PARAMETERS, THEN THE MODEL BINDING WILL FETCH THE DATA FROM THERE SINCE IT HAS A HIGHER PRIORITY THAN QUERY STRING.
        //SO THE VALUES FROM THE ROUTE PARAMETERS WILL BE SUPPLIED TO THE ACTION METHOD UNLESS THE ROUTE PARAMETERS DONT CONTAIN THAT DATA.
        [Route("/book/{bookId?}/{isloggedin?}")]
        public IActionResult Index(int? bookId, bool? isloggedin)
        {
            //WITH MODEL BINDING, WE CAN RETRIEVE THE VALUE AS A PARAMETER IN OUR METHOD.
            //WE SHOULD ALSO DECLARE THAT THE VARIABLES COULD BE NULL.
            if (bookId.HasValue == false)
            {
                return BadRequest("Bookid is not supplied.");
            }

            if (String.IsNullOrEmpty(Convert.ToString(bookId)))
            {
                return BadRequest("Bookid cannot be null or empty");
            }


            if (bookId < 1 || bookId > 1000)
            {
                return NotFound("Book id can't be less than 1 or greater than 1000");
            }

            if (isloggedin == false)
            {
                return Unauthorized("User must be authenticated");
            }

            return Content($"Book id: {bookId}", "text/plain");

        }

        [Route("bookstore")]
        public IActionResult BookStore()
        {
            int bookId = 3;
            return LocalRedirectPermanent($"store/books/{bookId}");
        }
    }

}