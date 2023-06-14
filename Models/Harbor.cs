using Models;

namespace Models
{
    public class Harbor
    {
        public List<CooledContainer> CooledContainers { get; set; }
        public List<NormalContainer> NormalContainers { get; set; }
        public List<ValuableContainer> ValuableContainers { get; set; }
        public Ship Ship { get; set; }

        public Harbor()
        {
            this.CooledContainers = new List<CooledContainer>();
            this.NormalContainers = new List<NormalContainer>();
            this.ValuableContainers = new List<ValuableContainer>();
        }

        public Ship CreateShip(int numRows, int numStacksPerRow)
        {
            return new Ship(numRows, numStacksPerRow);
        }

        public void LoadShip()
        {
            // Sort the containers of each type by weight in descending order
            Random random = new Random();
            CooledContainers = CooledContainers.OrderBy(container => random.Next()).ToList();
            NormalContainers = NormalContainers.OrderBy(container => random.Next()).ToList();
            ValuableContainers = ValuableContainers.OrderBy(container => random.Next()).ToList();

            Ship.LoadContainers(CooledContainers.Cast<Container>().ToList(), NormalContainers.Cast<Container>().ToList(), ValuableContainers.Cast<Container>().ToList());

        }
    }
}
