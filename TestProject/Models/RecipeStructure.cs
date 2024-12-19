namespace TestProject.Models
{
    public class RecipeStructure
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public float Amount { get; set; }
        public float? CorrectValue { get; set; } = 0;
    }
}
