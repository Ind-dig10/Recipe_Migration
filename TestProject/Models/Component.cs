namespace TestProject.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
        public float Humidity { get; set; } = 0;
    }
}
