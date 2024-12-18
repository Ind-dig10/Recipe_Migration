using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStructure> RecipeStructures { get; set; }
    }
}
