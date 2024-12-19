using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStructure> RecipeStructures { get; set; }
        public DbSet<Component> Component { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<RecipeMixerSet> RecipeMixerSets { get; set; }
        public DbSet<RecipeTimeSet> RecipeTimeSets { get; set; }
    }
}
