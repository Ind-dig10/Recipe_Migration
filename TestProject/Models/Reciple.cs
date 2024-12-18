namespace TestProject.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateModified { get; set; }
        public int? MixerSetId { get; set; }
        public int? TimeSetId { get; set; }
        public float? WaterCorrect { get; set; }
        public int? ConsistencyId { get; set; }
    }
}
