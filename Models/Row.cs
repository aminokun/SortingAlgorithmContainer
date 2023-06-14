using Models;
using System.Linq;

namespace Models
{
    public class Row
    {
        public List<Stack> Stacks { get; set; }

        public Row(int numOfStacks)
        {
            this.Stacks = new List<Stack>();
            for (int i = 0; i < numOfStacks; i++)
            {
                this.Stacks.Add(new Stack());
            }
        }

        public Stack FindSuitableStack(Container container)
        {
            // Fill the cooled containers only in the first stack of each row
            if (container is CooledContainer)
            {
                if (Stacks[0].CanAdd(container))
                {
                    return Stacks[0];
                }
            }
            else if (container is ValuableContainer)
            {
                // Find a suitable stack for valuable containers
                foreach (var stack in Stacks)
                {
                    if (stack.CanAdd(container))
                    {
                        return stack;
                    }
                }
            }
            else
            {
                // Fill the last stack with normal containers until it has a similar weight to the first stack
                if (Stacks.Last().CurrentWeight() < Stacks[0].CurrentWeight() && Stacks.Last().CanAdd(container))
                {
                    return Stacks.Last();
                }

                // Put a normal container in each stack from the second stack until the last stack
                for (int i = 1; i < Stacks.Count - 1; i++)
                {
                    if (Stacks[i].CanAdd(container))
                    {
                        return Stacks[i];
                    }
                }
            }

            return null; // No suitable stack found
        }
    }
}