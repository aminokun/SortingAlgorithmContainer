using Models;
using System.Collections.Generic;

namespace Models
{
    public class Ship
    {
        public List<Row> Rows { get; set; }
        public int MaxWeight { get; set; }
        public int LeftWeight { get; set; }
        public int RightWeight { get; set; }

        public Ship(int numOfRows, int numOfStacksPerRow)
        {
            this.Rows = new List<Row>();
            for (int i = 0; i < numOfRows; i++)
            {
                this.Rows.Add(new Row(numOfStacksPerRow));
            }
            this.MaxWeight = numOfRows * numOfStacksPerRow * 120;
            this.LeftWeight = 0;
            this.RightWeight = 0;
        }

        private void LoadContainerToStack(Container container, Stack stack, bool isLeftSide)
        {
            stack.Add(container);
            if (isLeftSide)
            {
                LeftWeight += container.Weight;
            }
            else
            {
                RightWeight += container.Weight;
            }

            // Ensure the ship is still balanced after loading the container
            if (Math.Abs(LeftWeight - RightWeight) > MaxWeight * 0.2)
            {
                // If the ship is unbalanced, unload the container
                stack.Containers.Remove(container);
                if (isLeftSide)
                {
                    LeftWeight -= container.Weight;
                }
                else
                {
                    RightWeight -= container.Weight;
                }
            }
        }

        public void LoadContainers(List<Container> cooledContainers, List<Container> normalContainers, List<Container> valuableContainers)
        {
            int numOfStacksPerRow = Rows[0].Stacks.Count;

            // Load cooled containers in the first stack of each row
            int i = 0;
            foreach (var container in cooledContainers)
            {
                var row = Rows[i];
                LoadContainerToStack(container, row.Stacks[0], true);
                i = (i + 1) % Rows.Count; // Move to the next row in a round-robin manner
            }

            // Load normal containers in the remaining stacks alternately (excluding first and last stacks)
            int stackIndex = 1;
            bool incrementStackIndex = true;
            foreach (var container in normalContainers)
            {
                var row = Rows[i];
                LoadContainerToStack(container, row.Stacks[stackIndex], stackIndex < numOfStacksPerRow / 2);

                // Alternate between the remaining stacks
                if (incrementStackIndex)
                {
                    stackIndex++;
                    if (stackIndex == numOfStacksPerRow - 1)
                    {
                        incrementStackIndex = false;
                    }
                }
                else
                {
                    stackIndex--;
                    if (stackIndex == 0)
                    {
                        incrementStackIndex = true;
                        stackIndex = 1;
                    }
                }

                i = (i + 1) % Rows.Count;
            }

            // Load valuable containers
            foreach (var container in valuableContainers)
            {
                var row = Rows[i];
                var stack = row.FindSuitableStack(container);
                if (stack != null)
                {
                    LoadContainerToStack(container, stack, i < Rows.Count / 2);
                }
                else
                {
                    Console.WriteLine("Could not load valuable container with weight {0}.", container.Weight);
                }
                i = (i + 1) % Rows.Count;
            }
        }


        public override string ToString()
        {
            string shipState = "Ship state:\n";
            shipState += "Left weight: " + LeftWeight + "\n";
            shipState += "Right weight: " + RightWeight + "\n";

            // Calculate the percentage difference
            double percentageDifference = Math.Abs(LeftWeight - RightWeight) / (MaxWeight * 0.2) * 100;

            shipState += "Percentage Difference: " + percentageDifference.ToString("0.00") + "%\n\n";

            for (int i = 0; i < Rows.Count; i++)
            {
                shipState += "Row " + (i + 1) + ":\n";
                for (int j = 0; j < Rows[i].Stacks.Count; j++)
                {
                    shipState += " Stack " + (j + 1) + " weight: " + Rows[i].Stacks[j].CurrentWeight() + "\n";
                    foreach (var container in Rows[i].Stacks[j].Containers)
                    {
                        shipState += "  Container Type: " + container.Type + ", Weight: " + container.Weight + "\n";
                    }
                }
            }

            return shipState;
        }

    }
}
