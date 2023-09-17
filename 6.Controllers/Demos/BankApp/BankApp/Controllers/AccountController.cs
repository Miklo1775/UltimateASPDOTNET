using Microsoft.AspNetCore.Mvc;
using BankApp.CustomClasses;
using System.Runtime.CompilerServices;

namespace BankApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly Object AccountDetails = new {accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000};
        [Route("/")]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("<h1>Welcome to the Best Bank</h1>", "text/html");
        }

        [Route("/account-details")]
        public IActionResult GetAccountDetails()
        {
            Response.StatusCode = 200;
            return Json(this.AccountDetails);
        }

        [Route("/account-statement")]
        public IActionResult GetAccountStatement()
        {
            Response.StatusCode = 200;
            return File("dummy.pdf", MIMEType.GetMIMEType("dummy.pdf"));

        }

        [Route("get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {

            int? accountNum = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            Console.WriteLine(accountNum);
            if(accountNum != 0)
            {
                if(accountNum != 1001)
                {
                    return BadRequest("Account number should be 1001");
                }

                var type = this.AccountDetails.GetType();
                var prop = type.GetProperty("currentBalance");
                int balance = (int)prop!.GetValue(this.AccountDetails, null)!;

                Response.StatusCode = 200;
                return Content($"Your current balance is: {balance}", "text/plain");

            }

            return NotFound("Account number should be supplied.");

        }
    }
}
