using System.ComponentModel.DataAnnotations;

namespace DBTestingProject.Models
{
    public class Furniture
    {
        public int Id { get; set; }

        [Required(ErrorMessage="This line is important!")]
        public string TypeFurniture { get; set; } = String.Empty;

        [Required(ErrorMessage = "This line is important!")]
        public string OutsideView { get; set; } = String.Empty;

        [Required(ErrorMessage = "This line is important!")]
        public string Material { get; set; } = String.Empty;

        [Required(ErrorMessage = "This line is important!")]
        [Range(0.01, double.MaxValue, ErrorMessage ="Price must be a positive number!.")]
        public double Price { get; set; }

    }
}
