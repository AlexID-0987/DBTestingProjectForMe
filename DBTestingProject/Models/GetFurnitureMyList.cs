using DBTestingProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBTestingProject.Models
{
    public class GetFurnitureMyList : IGetItemFurniture
    {
        public IEnumerable<Furniture> GetMyFurniture(FurnitureDBContext furnitureDBContext)
        {
            List<Furniture> it = furnitureDBContext.Furnitures.ToList();
            return it;
        }
    }
}
