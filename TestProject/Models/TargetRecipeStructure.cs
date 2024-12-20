namespace TestProject.Models
{
    public class TargetRecipeStructure
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public TargetRecipe Recipe { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public float Amount { get; set; }
    }
}
