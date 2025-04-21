using Microsoft.EntityFrameworkCore;

namespace DBTestingProject.Models
{
    public class FurnitureDBContext:DbContext
    {
        public FurnitureDBContext(DbContextOptions<FurnitureDBContext> options):base(options) 
        { Database.EnsureCreated(); }
        public DbSet<Furniture> Furnitures { get; set; }
        
    }
}
