using Models;

namespace Models
{
    public abstract class Container
    {
        public int Weight { get; set; }
        public string Type { get; protected set; } // Add this field

        public Container(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }

    public class CooledContainer : Container
    {
        public CooledContainer(int weight) : base(weight, "Cooled") { } // Set type here
    }

    public class NormalContainer : Container
    {
        public NormalContainer(int weight) : base(weight, "Normal") { } // Set type here
    }

    public class ValuableContainer : Container
    {
        public ValuableContainer(int weight) : base(weight, "Valuable") { } // Set type here
    }
}
