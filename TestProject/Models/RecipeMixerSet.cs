namespace TestProject.Models
{
    public class RecipeMixerSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnloadTime { get; set; } = 1;
        public UploadMode UploadMode { get; set; }
    }
}
