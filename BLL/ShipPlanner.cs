using Models;

namespace BLL
{
    public class ShipPlanner
    {
        public bool Plan(Ship ship, List<Container> containers)
        {
            // Sort the containers by weight, with the heaviest first
            containers = containers.OrderByDescending(c => c.Weight).ToList();

            // Try to load each container onto the ship
            foreach (Container container in containers)
            {
                if (!ship.LoadContainer(container))
                {
                    // If a container can't be loaded, the planning has failed
                    return false;
                }
            }

            // If we reach here, all containers could be loaded successfully
            return true;
        }
    }
}