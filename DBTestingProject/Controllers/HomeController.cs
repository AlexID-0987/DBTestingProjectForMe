using DBTestingProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DBTestingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FurnitureDBContext DBContext;
        FurnitureWithOperation FurnitureWithOperation = new FurnitureWithOperation();
        public HomeController(ILogger<HomeController> logger, FurnitureDBContext furnitureDBContext)
        {
            _logger = logger;
            DBContext = furnitureDBContext;
        }

        public async Task<IActionResult> Index()
        {
            //var furniture = await Task.Run(()=> DBContext.Furnitures.ToList());
            List<Furniture> myList = await Task.Run(() =>FurnitureWithOperation.GetFurniture(DBContext).ToList());
            //FurnitureWithOperation.AddFurniture(DBContext);
            return  View(myList);
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
