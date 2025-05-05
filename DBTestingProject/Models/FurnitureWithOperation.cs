using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class FurnitureWithOperation:IFurnitureOperations
    {
        IDeleteFurniture DeleteFurniture;
        IAddFurniture AddFurnitureTo;
        IGetItemFurniture GetGetItemFurniture;
        public FurnitureWithOperation ()
        {
            IDeleteFurniture deleteFurniture = new DeleteFurniture ();
            IAddFurniture addFurniture = new AddToListFurniture();
            IGetItemFurniture getItemFurniture = new GetFurnitureMyList();
            DeleteFurniture= deleteFurniture;
            AddFurnitureTo= addFurniture;
            GetGetItemFurniture= getItemFurniture;
        }

        public IEnumerable<Furniture> GetFurniture(FurnitureDBContext dBContext)
        {
           
            return GetGetItemFurniture.GetMyFurniture(dBContext);
        }
        public void AddFurniture(FurnitureDBContext furnitureDB)
        {
            AddFurnitureTo.AddFurnitureToList(furnitureDB);
        }
        public void Remove(int id, FurnitureDBContext furnitureDBContext)
        {
            DeleteFurniture.WithDeleteFurniture(id, furnitureDBContext);
            
            
        }
    }
}
