using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace TestProject.Models
{
    public class TargetRecipe2
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateModified { get; set; }

        public float MixerHumidity { get; set; }

        public int MixerSetId { get; set; }
        public RecipeMixerSet MixerSet { get; set; }

        public int TimeSetId { get; set; }
        public RecipeTimeSet TimeSet { get; set; }

        public int ConsistencyId { get; set; }
        public Consistency Consistency { get; set; }
    }
}
