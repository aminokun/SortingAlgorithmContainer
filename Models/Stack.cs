using Models;

namespace Models
{
    public class Stack
    {
        public List<Container> Containers { get; set; }

        public Stack()
        {
            Containers = new List<Container>();
        }

        public bool CanLoadContainer(Container container)
        {
            if (Containers.Count == 0)
            {
                return true;
            }

            Container topContainer = Containers[Containers.Count - 1];

            if (topContainer.Type == ContainerType.Valuable)
            {
                return false;
            }

            int totalWeight = Containers.Sum(c => c.Weight) + container.Weight;

            if (totalWeight > 120)
            {
                return false;
            }

            return true;

        }

        public bool LoadContainer(Container container)
        {
            if (!CanLoadContainer(container))
            {
                return false;
            }

            Containers.Add(container);
            return true;
        }

        public override string ToString()
        {
            string result = "Stack contains:\n";

            for (int i = 0; i < Containers.Count; i++)
            {
                result += "  Level " + (i + 1) + ": " + Containers[i].ToString() + "\n";
            }

            return result;
        }
    }
}
