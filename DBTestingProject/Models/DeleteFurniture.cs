using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class DeleteFurniture:IDeleteFurniture
    {
        
        public void WithDeleteFurniture(int id, FurnitureDBContext furnitureDBContext)
        {
            Furniture it = furnitureDBContext.Furnitures.Find(id);
            furnitureDBContext.Furnitures.Remove(it);
            furnitureDBContext.SaveChanges();
        }
    }
}
