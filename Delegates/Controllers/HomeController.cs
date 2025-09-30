using System.Diagnostics;
using Delegates.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delegates.Controllers
{
    delegate double Calculate(double x, double y);
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Calculate(string operation, string x, string y)
        {
            ViewData["X"] = x;
            ViewData["Y"] = y;

            if (double.TryParse(x, out double X) && double.TryParse(y, out double Y))
            {
                Calculate add = (a, b) => a + b;
                Calculate subtract = (a, b) => a - b;
                Calculate multiply = (a, b) => a * b;
                Calculate divide = (a, b) => a / b;

                double result = 0;
                string resultText= string.Empty;

                switch (operation)
                {
                    case "Add":
                        result = add(X, Y);
                        resultText = $"{X} + {Y} = {result}";
                        break;

                    case "Subtract":
                        result = subtract(X, Y);
                        resultText = $"{X} - {Y} = {result}";
                        break;

                    case "Multiply":
                        result = multiply(X, Y);
                        resultText = $"{X} * {Y} = {result}";
                        break;

                    case "Divide":
                        result = divide(X, Y);
                        resultText = $"{X} / {Y} = {result}";
                        break;
                }
                ViewData["Result"] = resultText;
                TempData["Result"] = resultText;

            }
            else
            {
                ViewData["Result"] = "Invalid input";
            }

            return View("Index");
        }
    }
}
