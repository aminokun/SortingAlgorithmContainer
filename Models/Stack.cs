using Models;

namespace Models
{
    public class Stack
    {
        public List<Container> Containers { get; set; }
        public int MaxWeight { get; set; }

        public Stack()
        {
            this.Containers = new List<Container>();
            this.MaxWeight = 120;
        }

        public bool CanAdd(Container container)
        {
            // Make sure Valuable containers are at the top of the stack
            if (container is ValuableContainer && Containers.Any())
                return false;

            int currentWeight = CurrentWeight();
            return currentWeight + container.Weight <= MaxWeight;
        }

        public void Add(Container container)
        {
            if (CanAdd(container))
                this.Containers.Add(container);
            else
                throw new Exception($"Cannot add the container of type {container.GetType().Name} and weight {container.Weight} to the stack due to weight or type limitation.");
        }

        public int CurrentWeight()
        {
            int totalWeight = 0;
            foreach (var container in Containers)
            {
                totalWeight += container.Weight;
            }

            return totalWeight;
        }

    }
}

