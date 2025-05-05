namespace DBTestingProject.Models.Interfaces
{
    public interface IGetItemFurniture
    {
        IEnumerable<Furniture> GetMyFurniture(FurnitureDBContext furnitureDBContext);
    }
}
