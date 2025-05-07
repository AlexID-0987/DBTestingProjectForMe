using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class FurnitureWithOperation:IFurnitureOperations
    {
        IDeleteFurniture DeleteFurniture;
        IAddFurniture AddFurnitureTo;
        IGetItemFurniture GetGetItemFurniture;
        IEditFurniture EditFurniture;
        public FurnitureWithOperation ()
        {
            IDeleteFurniture deleteFurniture = new DeleteFurniture ();
            IAddFurniture addFurniture = new AddToListFurniture();
            IGetItemFurniture getItemFurniture = new GetFurnitureMyList();
            IEditFurniture editfurniture = new EditMyListFurniture();
            DeleteFurniture= deleteFurniture;
            AddFurnitureTo= addFurniture;
            GetGetItemFurniture= getItemFurniture;
            EditFurniture = editfurniture;
        }

        public IEnumerable<Furniture> GetFurniture(FurnitureDBContext dBContext)
        {
           
            return GetGetItemFurniture.GetMyFurniture(dBContext);
        }
        public  void AddFurniture(FurnitureDBContext furnitureDB, Furniture furniture)
        {
            
              AddFurnitureTo.AddFurnitureToList(furnitureDB, furniture);
        }

        public void EditToList(Furniture furniture, FurnitureDBContext dbContext)
        {
            EditFurniture.EditMyList(furniture, dbContext);
        }
        public void Remove(int id, FurnitureDBContext furnitureDBContext)
        {
            DeleteFurniture.WithDeleteFurniture(id, furnitureDBContext);
            
            
        }
    }
}
