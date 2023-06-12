using Models;
using BLL;

namespace ContainerLoading
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a list of containers to be loaded
            List<Container> containers = new List<Container>();
            containers.Add(new Container(ContainerType.Normal, 10));
            containers.Add(new Container(ContainerType.Normal, 20));
            containers.Add(new Container(ContainerType.Normal, 30));
            containers.Add(new Container(ContainerType.Normal, 10));
            containers.Add(new Container(ContainerType.Normal, 20));
            containers.Add(new Container(ContainerType.Normal, 30));
            containers.Add(new Container(ContainerType.Normal, 10));
            containers.Add(new Container(ContainerType.Normal, 20));
            containers.Add(new Container(ContainerType.Normal, 30));
            containers.Add(new Container(ContainerType.Cooled, 25));
            containers.Add(new Container(ContainerType.Cooled, 30));
            containers.Add(new Container(ContainerType.Cooled, 25));
            containers.Add(new Container(ContainerType.Cooled, 30));
            containers.Add(new Container(ContainerType.Cooled, 25));
            containers.Add(new Container(ContainerType.Cooled, 30));
            containers.Add(new Container(ContainerType.Valuable, 15));
            containers.Add(new Container(ContainerType.Valuable, 15));
            containers.Add(new Container(ContainerType.Valuable, 15));

            // Create a ship with a specified number of rows and stacks per row
            Ship ship = new Ship(3, 4);

            // Create a ShipPlanner
            ShipPlanner planner = new ShipPlanner();

            // Load the containers onto the ship
            if (!planner.Plan(ship, containers))
            {
                Console.WriteLine("Failed to plan container loading.");
            }

            // Print the ship's layout
            Console.WriteLine(ship.ToString());

            // Wait for user input before exiting
            Console.ReadLine();
        }
    }
}
