using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class EditMyListFurniture : IEditFurniture
    {
        public void EditMyList(Furniture furniture, FurnitureDBContext dbContext)
        {
            dbContext.Furnitures.Update(furniture);
            dbContext.SaveChanges();
        }
    }
}
