using Models;

namespace ContainerLoading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Harbor harbor = new Harbor();
            harbor.Ship = new Ship(3, 5);

            // Create and add containers to harbor
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.NormalContainers.Add(new NormalContainer(30));
            harbor.CooledContainers.Add(new CooledContainer(10));
            harbor.CooledContainers.Add(new CooledContainer(15));
            harbor.CooledContainers.Add(new CooledContainer(15));
            harbor.CooledContainers.Add(new CooledContainer(15));
            harbor.ValuableContainers.Add(new ValuableContainer(15));
            harbor.ValuableContainers.Add(new ValuableContainer(15));
            harbor.ValuableContainers.Add(new ValuableContainer(15));
            harbor.ValuableContainers.Add(new ValuableContainer(15));

            // Load ship
            harbor.LoadShip();

            // Print the status of the ship
            Console.WriteLine(harbor.Ship.ToString());
        }

    }
}
