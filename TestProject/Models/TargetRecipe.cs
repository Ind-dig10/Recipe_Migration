namespace TestProject.Models
{
    public class TargetRecipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateModified { get; set; }

        public int MixTime { get; set; }

        public float MixerHumidity { get; set; }

        public float WaterCorrect { get; set; } = 0;
    }
}
