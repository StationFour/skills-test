using System.Linq;
using Microsoft.AspNet.Mvc;
using S4.SkillsTest.ViewModels;

namespace S4.SkillsTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult CustomerData()
        {
            // pass results to ViewBag
            ViewBag.numberOfCustomers = CustomerDataViewModel.GetNumberOfCustomers();
            ViewBag.numberOfStatesWithCustomers = CustomerDataViewModel.GetNumberOfStatesWithCustomers();
            ViewBag.NetWorthPerCity = CustomerDataViewModel.cityNetWorth;
            ViewBag.AverageDistanceFromCenterState = CustomerDataViewModel.averageDistanceFromCenterState;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
