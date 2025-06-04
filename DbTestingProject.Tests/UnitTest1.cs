using DBTestingProject.Controllers;
using DBTestingProject.Models;
using DBTestingProject.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Moq;

namespace DbTestingProject.Tests
{
    [TestFixture]
    public class Tests
    {
        
        AddToListFurniture addToList=new AddToListFurniture();
        GetFurnitureMyList getFurniture=new GetFurnitureMyList();
        IDeleteFurniture deleteFurniture= new DeleteFurniture();
        IEditFurniture editFurniture = new EditMyListFurniture();

        [Test]
        public void AddToFurnitureMyList_Test() 
        {
            var test = new List<Furniture>();
           Furniture furniture = new Furniture
            {
                TypeFurniture="Desk", OutsideView="Color", Material="Wood", Price=465.22
                
            };
           
            test.Add(furniture);
            Assert.AreEqual(1,test.Count());
            Assert.AreEqual("Color", test[0].OutsideView);
        }

        [Test]
        public void TestToOnDatabase()
        {
            var option = new DbContextOptionsBuilder<FurnitureDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            using (var context = new FurnitureDBContext(option))
            {
                context.Furnitures.Add(new Furniture {Id=1, TypeFurniture = "Chair11", OutsideView = "Red", Material = "Pe", Price = 32.56 });
                context.SaveChanges();
            }
            using (var context=new FurnitureDBContext(option))
            {
                Assert.AreEqual(1,context.Furnitures.Count());
            }
            using (var context= new FurnitureDBContext(option))
            {
                Furniture furniture = new Furniture { Id = 2, TypeFurniture = "Desk", OutsideView = "Color", Material = "Pe", Price = 32.56 };
                addToList.AddFurnitureToList(context,furniture);
                context.SaveChanges();
                Assert.AreEqual(2, context.Furnitures.Count());
                var MyList = getFurniture.GetMyFurniture(context);
                Assert.IsNotNull(MyList);
            }
        }
        [Test]

        public void Delete_To_Item_MyList_Test()
        {
            var option = new DbContextOptionsBuilder<FurnitureDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            using (var context = new FurnitureDBContext(option))
            {
                context.Furnitures.Add(new Furniture { Id = 1, TypeFurniture = "Chair11", OutsideView = "Red", Material = "Pe", Price = 32.56 });
                context.SaveChanges();
                
            }
            using (var context = new FurnitureDBContext(option))
            {

                deleteFurniture.WithDeleteFurniture(1, context);
                Assert.IsEmpty(context.Furnitures);
                Assert.AreNotEqual(1, context.Furnitures.Count());
            }
        }
        [Test]
        public void Edit_To_MyList_Test()
        {
            var option = new DbContextOptionsBuilder<FurnitureDBContext>()
               .UseInMemoryDatabase(databaseName: "TestDb3")
               .Options;
            using (var context = new FurnitureDBContext(option))
            {
                context.Furnitures.Add(new Furniture { Id = 1, TypeFurniture = "Chair11", OutsideView = "Red", Material = "Pe", Price = 32.56 });
                context.SaveChanges();

            }
            using (var context = new FurnitureDBContext(option))
            {
                Furniture furniture = new Furniture { Id = 1, TypeFurniture = "Sofa", OutsideView = "Red", Material = "Pe", Price = 32.56 };
                editFurniture.EditMyList(furniture, context);
                context.SaveChanges();
                var MyList1 = getFurniture.GetMyFurniture(context);
                foreach (var it in MyList1)
                {
                    Assert.AreEqual(it.TypeFurniture, furniture.TypeFurniture);
                }
                


            }
        }
        
    }
}