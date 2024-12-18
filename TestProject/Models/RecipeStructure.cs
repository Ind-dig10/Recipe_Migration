namespace TestProject.Models
{
    public class RecipeStructure
    {
        public int RecipeId { get; set; }
        public int ComponentId { get; set; }
        public float Amoutn { get; set; }
        public float? CorrectValue { get; set; } = 0;
    }
}
