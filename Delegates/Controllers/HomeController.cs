using System.Diagnostics;
using Delegates.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delegates.Controllers
{
    delegate double Calculate(double x, double y);
    public class HomeController : Controller
    {

        List<string> namen = new List<string> { "Hans", "Peter", "Klaus", "Franz" };
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public HomeController()
        {
            List<string> namen = new List<string> { "Hans", "Peter", "Klaus", "Franz" };
            string result = namen.Find((n) => n == "Herbert");
            List<string> alleMitB = namen.FindAll((n) => n.StartsWith("B"));
            namen.ForEach(n => Debug.WriteLine(n));

        }
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
                string resultText = string.Empty;

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
        double? Add(double? x, double? y)
        {
            return x + y;
        }

        double? Subtract(double? x, double? y)
        {
            return x - y;
        }

        double? Multiply(double? x, double? y)
        {
            return x * y;
        }

        double? Divide(double? x, double? y)
        {
            return x / y;
        }
    }
}
