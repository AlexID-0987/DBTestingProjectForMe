namespace DBTestingProject.Models
{
    public class FurnitureWithOperation:IFurnitureOperations
    {
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
            var it = furnitureDBContext.Furnitures.Find(id);
            furnitureDBContext.Furnitures.Remove(it);
            furnitureDBContext.SaveChanges();
            
        }
    }
}
