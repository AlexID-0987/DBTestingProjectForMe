using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class FurnitureWithOperation:IFurnitureOperations
    {
        IDeleteFurniture DeleteFurniture;
        
        public FurnitureWithOperation ()
        {
            IDeleteFurniture deleteFurniture = new DeleteFurniture ();
            DeleteFurniture= deleteFurniture;
        }

        public IEnumerable<Furniture> GetFurniture(FurnitureDBContext dBContext)
        {
           List <Furniture> it = dBContext.Furnitures.ToList();
            return it;
        }
        public void AddFurniture(FurnitureDBContext furnitureDB)
        {
            furnitureDB.Add(new Furniture
            {
                TypeFurniture="Sofa",
                OutsideView="Soft",
                Material="Skin",
                Price=456.89

            });
            furnitureDB.SaveChanges();
        }
        public void Remove(int id, FurnitureDBContext furnitureDBContext)
        {
            DeleteFurniture.WithDeleteFurniture(id, furnitureDBContext);
            //var it = furnitureDBContext.Furnitures.Find(id);
           // furnitureDBContext.Furnitures.Remove(it);
            //furnitureDBContext.SaveChanges();
            
        }
    }
}
