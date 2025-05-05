using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class AddToListFurniture : IAddFurniture
    {
        Furniture Furniture = new Furniture() { Material = "Oat", OutsideView = "Tree", TypeFurniture = "Bad", Price = 346.098 };
        public void AddFurnitureToList(FurnitureDBContext context)
        {
            context.Add(Furniture);
            context.SaveChanges();
        }
    }
}
