namespace DBTestingProject.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string TypeFurniture { get; set; } = String.Empty;
        public string OutsideView { get; set; } = String.Empty;
        public string Material { get; set; } = String.Empty;

        public double Price { get; set; }

    }
}
