using DBTestingProject.Models;
using DBTestingProject.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            
            return  View(myList);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddToFurnitureMyList(Furniture furniture)
        {
            await Task.Run(()=> FurnitureWithOperation.AddFurniture(DBContext, furniture));
            return RedirectToAction("Index");
        }
        public IActionResult AddToFurnitureMyList()
        {
            
            return View("AddToFurnitureMyList");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
           var furniture = await Task.Run(()=> FurnitureWithOperation.GetFurniture(DBContext).FirstOrDefault(furniture=>furniture.Id==id));
            return View(furniture);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Furniture furnitureNew)
        {
            
            await Task.Run(() => FurnitureWithOperation.EditToList(furnitureNew, DBContext));
            return RedirectToAction("Index");
        }
        public async  Task<IActionResult> Delete(int id)
        {
           
            await Task.Run(() => FurnitureWithOperation.Remove(id, DBContext));
            return RedirectToAction("Index");
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
