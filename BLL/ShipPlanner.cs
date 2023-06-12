using Models;

namespace BLL
{
    public class ShipPlanner
    {
        public List<Row> Rows { get; set; }
        public int CurrentWeight { get; set; }
        public int LeftWeight { get; set; }
        public int RightWeight { get; set; }
        public int MaxWeight { get; set; }

        public ShipPlanner(int numRows, int numStacksPerRow, int maxWeightPerStack, int maxWeight)
        {
            Rows = new List<Row>();
            for (int i = 0; i < numRows; i++)
            {
                Rows.Add(new Row(numStacksPerRow, maxWeightPerStack));
            }
            CurrentWeight = 0;
            LeftWeight = 0;
            RightWeight = 0;
            MaxWeight = maxWeight;
        }

        public bool LoadContainer(Container container, bool loadLeft)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                int stackIndex = loadLeft ? 0 : Rows[i].Stacks.Count - 1;

                if (Rows[i].Stacks[stackIndex].TryAddContainer(container))
                {
                    CurrentWeight += container.Weight;

                    if (loadLeft)
                    {
                        LeftWeight += container.Weight;
                    }
                    else
                    {
                        RightWeight += container.Weight;
                    }

                    return true;
                }
            }

            return false;
        }

        public bool Plan(List<Container> containers)
        {
            containers = containers.OrderByDescending(c => c.Weight).ToList();

            foreach (var container in containers)
            {
                if (CurrentWeight + container.Weight > MaxWeight)
                {
                    return false;
                }

                bool loadLeft = LeftWeight <= RightWeight;

                if (!LoadContainer(container, loadLeft))
                {
                    return false;
                }
            }

            return true;
        }

        public void PrintShipLayout()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                Console.WriteLine($"Row {i + 1}:");
                for (int j = 0; j < Rows[i].Stacks.Count; j++)
                {
                    Console.WriteLine($"  Stack {j + 1}:");
                    for (int k = 0; k < Rows[i].Stacks[j].Containers.Count; k++)
                    {
                        Console.WriteLine($"    Level {k + 1}: {Rows[i].Stacks[j].Containers[k].Type} container ({Rows[i].Stacks[j].Containers[k].Weight} tons)");
                    }
                }
            }
        }
    }
}