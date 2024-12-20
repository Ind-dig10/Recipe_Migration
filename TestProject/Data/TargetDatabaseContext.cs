using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class Target1DatabaseContext : DbContext
    {
        public DbSet<TargetRecipe> Recipes { get; set; }
        public DbSet<TargetRecipeStructure> RecipeStructures { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }

        public Target1DatabaseContext(DbContextOptions<Target1DatabaseContext> options) : base(options) {}
    }

    public class Target2DatabaseContext : DbContext
    {
        public DbSet<TargetRecipe2> Recipes { get; set; }
        public DbSet<RecipeMixerSet> MixerSets { get; set; }
        public DbSet<RecipeTimeSet> TimeSets { get; set; }
        public DbSet<Consistency> Consistencies { get; set; }

        public Target2DatabaseContext(DbContextOptions<Target2DatabaseContext> options) : base(options) { }
    }
}
