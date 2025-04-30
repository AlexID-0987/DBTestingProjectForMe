namespace DBTestingProject.Models.Interfaces
{
    public interface IDeleteFurniture
    {
         void WithDeleteFurniture(int Id, FurnitureDBContext furnitureDBContext);
    }
}
