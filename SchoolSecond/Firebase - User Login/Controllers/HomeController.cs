using Firebase___User_Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firebase___User_Login.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() { return View(); } 


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}