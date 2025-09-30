using System.Diagnostics;
using Delegates.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delegates.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate()
        { 
           return View();
        }
    }
}
