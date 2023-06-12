using Models;

namespace Models
{
    public class Ship
    {
        public List<Row> Rows { get; set; }
        public int MaxWeight { get; set; }
        public int CurrentWeight { get; set; }
        public int LeftWeight { get; set; }
        public int RightWeight { get; set; }

        public Ship(int numRows, int numStacksPerRow)
        {
            Rows = new List<Row>();

            for (int i = 0; i < numRows; i++)
            {
                Rows.Add(new Row(numStacksPerRow));
            }

            MaxWeight = numRows * numStacksPerRow * 120;
            CurrentWeight = 0;
        }

        public bool CanLoadContainer(Container container)
        {
            if (container.Type == ContainerType.Cooled)
            {
                foreach (Row row in Rows)
                {
                    if (row.Stacks[0].CanLoadContainer(container))
                    {
                        return true;
                    }
                }

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

            if (container.Type == ContainerType.Valuable)
            {
                foreach (Row row in Rows)
                {
                    if (row.CanLoadContainer(container))
                    {
                        row.LoadContainer(container);
                        CurrentWeight += container.Weight;
                        return true;
                    }
                }

                if (Math.Abs((LeftWeight + container.Weight) - RightWeight) <= MaxWeight * 0.2)
                {
                    LeftWeight += container.Weight;
                    return true;
                }
                else if (Math.Abs(LeftWeight - (RightWeight + container.Weight)) <= MaxWeight * 0.2)
                {
                    RightWeight += container.Weight;
                    return true;
                }

                return false;
            }

            if (container.Type == ContainerType.Cooled)
            {
                foreach (Row row in Rows)
                {
                    if (row.Stacks[0].LoadContainer(container))
                    {
                        CurrentWeight += container.Weight;
                        return true;
                    }
                }

                return false;
            }

            // Try to load the container in each row, starting from the front
            foreach (Row row in Rows)
            {
                if (row.LoadContainer(container))
                {
                    CurrentWeight += container.Weight;
                    return true;
                }
            }

            // If we reach here, the container could not be loaded
            return false;
        }

        public override string ToString()
        {
            string result = "Ship layout:\n";

            for (int i = 0; i < Rows.Count; i++)
            {
                result += "Row " + (i + 1) + ":\n" + Rows[i].ToString() + "\n";
            }

            return result;
        }
    }
}