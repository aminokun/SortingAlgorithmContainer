using Models;

namespace Models
{
    // Class to represent a container
    public class Container
    {
        public ContainerType Type { get; set; }
        public int Weight { get; set; }

        public Container(ContainerType type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public override string ToString()
        {
            return Type.ToString() + " container (" + Weight + " tons)";
        }
    }

    // Enum to represent the different types of containers
    public enum ContainerType
    {
        Normal,
        Valuable,
        Cooled
    }
}
