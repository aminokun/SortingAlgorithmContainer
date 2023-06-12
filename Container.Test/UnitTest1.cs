using NUnit.Framework;
using System.Collections.Generic;
using ContainerLoading;
using Models;
using BLL;

namespace ContainerLoadingTests
{
    [TestFixture]
    public class ShipPlannerTests
    {
        [Test]
        public void TestPlan()
        {
            // Arrange
            List<Container> containers = new List<Container>();
            containers.Add(new Container(ContainerType.Normal, 10));
            containers.Add(new Container(ContainerType.Normal, 20));
            containers.Add(new Container(ContainerType.Normal, 30));
            containers.Add(new Container(ContainerType.Valuable, 15));
            containers.Add(new Container(ContainerType.Cooled, 25));
            containers.Add(new Container(ContainerType.Cooled, 30));
            containers.Add(new Container(ContainerType.Normal, 10));
            containers.Add(new Container(ContainerType.Normal, 20));
            containers.Add(new Container(ContainerType.Normal, 30));
            containers.Add(new Container(ContainerType.Valuable, 15));
            containers.Add(new Container(ContainerType.Cooled, 25));
            containers.Add(new Container(ContainerType.Cooled, 30));
            containers.Add(new Container(ContainerType.Normal, 10));
            containers.Add(new Container(ContainerType.Normal, 20));
            containers.Add(new Container(ContainerType.Normal, 30));
            containers.Add(new Container(ContainerType.Valuable, 15));
            containers.Add(new Container(ContainerType.Cooled, 25));
            containers.Add(new Container(ContainerType.Cooled, 30));
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


            Ship ship = new Ship(3, 4);
            ShipPlanner planner = new ShipPlanner();

            // Act
            bool result = planner.Plan(ship, containers);

            // Assert
            Assert.IsTrue(result, "Failed to plan container loading.");
            Assert.IsTrue(ship.CurrentWeight >= ship.MaxWeight * 0.5, "Not enough weight loaded onto ship.");
            Assert.IsTrue(Math.Abs(ship.LeftWeight - ship.RightWeight) <= ship.CurrentWeight * 0.2, "Weight distribution is uneven.");
        }
    }
}
