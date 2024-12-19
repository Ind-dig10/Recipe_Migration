namespace TestProject.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateModified { get; set; }
        public int? RecipeMixerSetId { get; set; }
        public RecipeMixerSet RecipeMixerSet { get; set; }
        public int? RecipeTimeSetId { get; set; }
        public RecipeTimeSet RecipeTimeSet { get; set; }
        //public float? WaterCorrect { get; set; }
        //public int? ConsistencyId { get; set; }
    }
}