namespace DBTestingProject.Models
{
    public static class FurnitureData
    {
        public static void Init(FurnitureDBContext furnitureDBContext)
        {
            if (!furnitureDBContext.Furnitures.Any())
            {
                furnitureDBContext.Furnitures.AddRange(
                    new Furniture
                    {
                        TypeFurniture="Chair",
                        OutsideView="Cloth",
                        Material="Tree",
                        Price=12.56
                    },
                    new Furniture
                    {
                        TypeFurniture = "Bad",
                        OutsideView = "Cloth",
                        Material = "Tree",
                        Price=189.23
                    },
                    new Furniture
                    {
                        TypeFurniture = "Desk",
                        OutsideView = "Oat",
                        Material = "Tree",
                        Price=1456.78
                    }
                    );


                furnitureDBContext.SaveChanges();
            }
        }
    }
}
