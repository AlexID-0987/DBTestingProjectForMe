using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class AddToListFurniture : IAddFurniture
    {
        
        public void AddFurnitureToList(FurnitureDBContext context, Furniture furniture)
        {
            context.Add(furniture);
            context.SaveChanges();
        }
    }
}
