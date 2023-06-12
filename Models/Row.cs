using Models;

namespace Models
{
    public class Row
    {
        public List<Stack> Stacks { get; set; }
        public int LeftWeight { get; set; }
        public int RightWeight { get; set; }

        public Row(int numStacks)
        {
            Stacks = new List<Stack>();

            for (int i = 0; i < numStacks; i++)
            {
                Stacks.Add(new Stack());
            }
        }

        public bool CanLoadContainer(Container container)
        {
            foreach (Stack stack in Stacks)
            {
                if (stack.CanLoadContainer(container))
                {
                    return true;
                }
            }

            return false;
        }

        public bool LoadContainer(Container container)
        {
            bool loadLeft = LeftWeight <= RightWeight;

            for (int i = 0; i < Stacks.Count; i++)
            {
                if (loadLeft && i >= Stacks.Count / 2) break;
                if (!loadLeft && i < Stacks.Count / 2) continue;

                Stack stack = Stacks[i];
                if (stack.LoadContainer(container))
                {
                    if (loadLeft) LeftWeight += container.Weight;
                    else RightWeight += container.Weight;

                    return true;
                }
            }

            return false;
        }
        public override string ToString()
        {
            string result = "Row contains:\n";

            for (int i = 0; i < Stacks.Count; i++)
            {
                result += "  Stack " + (i + 1) + ":\n" + Stacks[i].ToString() + "\n";
            }

            return result;
        }
    }
}
