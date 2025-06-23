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

        private readonly IDateTime  time;
        public delegate string myTime(DateTime dateTime);
        FurnitureWithOperation FurnitureWithOperation=new FurnitureWithOperation();
        public HomeController(ILogger<HomeController> logger, FurnitureDBContext furnitureDBContext, IDateTime dateTime)
        {
            _logger = logger;
            DBContext = furnitureDBContext;
            time = dateTime;
        }
        public string MyMessage(DateTime dateTime)
        {
            if (dateTime.Hour < 12) { return "Good Moring!"; }
            else if(dateTime.Hour<17) { return "Good Afternoon!"; }
            return "Good Evening!";
        }
        public async Task<IActionResult> Index()
        {
            //var furniture = await Task.Run(()=> DBContext.Furnitures.ToList());
            List<Furniture> myList = await Task.Run(() =>FurnitureWithOperation.GetFurniture(DBContext).ToList());
            myTime my = MyMessage;
            //ViewBag.str = MyMessage(time.Now);
            ViewBag.str2 = my(time.Now);
            return  View(myList);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddToFurnitureMyList(Furniture furniture)
        {
            if (ModelState.IsValid)
            {

                await Task.Run(() => FurnitureWithOperation.AddFurniture(DBContext, furniture));
                return RedirectToAction("Index");
            }
            return View("AddToFurnitureMyList");

        }
        public IActionResult AddToFurnitureMyList()
        {
            
            return View("AddToFurnitureMyList");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
           var furniture = await Task.Run(()=> FurnitureWithOperation.GetFurniture(DBContext).FirstOrDefault(furniture=>furniture.Id==id));
            if (furniture != null)
            {
                return View(furniture);
            }
            return View("NotExists");
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

        public async Task<IActionResult> MyProducts()
        {
            List<Furniture> myCard = await Task.Run(() => FurnitureWithOperation.GetFurniture(DBContext).ToList());
            return View(myCard);
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
