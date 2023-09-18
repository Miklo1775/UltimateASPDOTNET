using Microsoft.AspNetCore.Mvc;
using System.Net;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers
{
    public class AudioBookController : Controller
    {
        //THIS CONTROLLER IS FOR FromRoute and FromQuery examples.

        //FOR EACH PARAMETER, WE CAN SELECT WHERE WE WANT TO PULL THE DATA FROM.
        //FOR THE ROUTE DIRECTLY BELOW, WE ARE PULLING THE AUDIOBOOKID FROM THE ROUTEVALUE AND THE ISLOGGEDIN BOOLEAN VALUE FROM THE QUERY STRING.
        //WITH MODEL CLASSES, AN OBJECT OF THE CLASS THAT YOU SPECIFY WILL BE CREATED WITH THE VALUES FORM WHEREVER YOU PULL THE DATA.
        //WE CAN ALSO APPLY FROMQUERY AND FROMROUTE TO THE BOOK OBJECT AS WELL AS IN THE MODEL CLASS ITSELF.
        [Route("audiobook/{audiobookId?}/{isloggedin?}")]
        public IActionResult Index(int? audiobookId, bool? isloggedin, AudioBook book)
        {
            if (book.AudioBookId.HasValue == false)
            {
                return BadRequest("Audiobookid is not supplied.");
            }

            if (String.IsNullOrEmpty(Convert.ToString(book.AudioBookId)))
            {
                return BadRequest("Audioookid cannot be null or empty");
            }


            if (book.AudioBookId < 1 || book.AudioBookId > 1000)
            {
                return NotFound("Audiobook id can't be less than 1 or greater than 1000");
            }

            if (isloggedin == false)
            {
                return Unauthorized("User must be authenticated");
            }

            return Content($"Audiobook id: {book.AudioBookId}, Book: {book}", "text/plain");
        }
    }
}
