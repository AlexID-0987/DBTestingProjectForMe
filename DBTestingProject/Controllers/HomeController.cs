using DBTestingProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DBTestingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FurnitureDBContext DBContext;
        public HomeController(ILogger<HomeController> logger, FurnitureDBContext furnitureDBContext)
        {
            _logger = logger;
            DBContext = furnitureDBContext;
        }
        
        public IActionResult Index()
        {
            var furniture = DBContext.Furnitures.ToList();
            return View(furniture);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
