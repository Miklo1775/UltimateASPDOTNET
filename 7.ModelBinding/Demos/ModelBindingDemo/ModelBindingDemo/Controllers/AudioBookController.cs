﻿using Microsoft.AspNetCore.Mvc;
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
        //WE CAN ALSO APPLY FROMQUERY AND FROMROUTE TO THE BOOK OBJECT.
        [Route("audiobook/{audiobookId?}/{isloggedin?}")]
        public IActionResult Index([FromRoute]int? audiobookId, [FromQuery]bool? isloggedin, [FromQuery]AudioBook book)
        {
            if (audiobookId.HasValue == false)
            {
                return BadRequest("Audiobookid is not supplied.");
            }

            if (String.IsNullOrEmpty(Convert.ToString(audiobookId)))
            {
                return BadRequest("Audioookid cannot be null or empty");
            }


            if (audiobookId < 1 || audiobookId > 1000)
            {
                return NotFound("Audiobook id can't be less than 1 or greater than 1000");
            }

            if (isloggedin == false)
            {
                return Unauthorized("User must be authenticated");
            }

            return Content($"Audiobook id: {audiobookId}, Book: {book}", "text/plain");
        }
    }
}