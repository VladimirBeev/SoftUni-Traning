using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
           [Test]
           public void GatageNameShouldThrowExeptionWithEmptyAndNullValues()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(null, 10);
                },
                "Invalid garage name.");

                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(string.Empty, 10);
                },
                "Invalid garage name.");
            }
            [Test]
            public void GarageProperyShoudWorkCorrectly()
            {
                const string garageName = "Test";
                var garage = new Garage(garageName, 10);
                Assert.That(garage.Name, Is.EqualTo(garageName));
            }
            [Test]
            public void GarageMechanicsShoudlThrowExeptionWithNoMechanics()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", 0);
                },
                "At least one mechanic must work in the garage.");

                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", -5);
                },
                "At least one mechanic must work in the garage.");
            }
            [Test]
            public void GarageMechanicsShoudWorkCorrectly()
            {
                var garageMechanics = 10;
                var garage = new Garage("Test",garageMechanics);
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(garageMechanics));
            }
            [Test]
            public void GarageAddCarShoudThrowExeptionWithNoAvailableMechanics()
            {
                //Arrange
                var garage = new Garage("Test",1);
                var firstCar = new Car("Mercedes",10);
                var secondCar = new Car("Opel",15);

                garage.AddCar(firstCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                },
                "No mechanic available.");
            }
            [Test]
            public void GarageAddCarShoudIncrementCarCauntCorrectly()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }
            [Test]
            public void GagageFixCarThrowExeptionWithCarModelDoesetExists()
            {
                const string carmodel = "Opel";
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carmodel, 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(carmodel);
                }, $"The car {carmodel} doesn't exist.");
            }
            [Test]
            public void GagageFixCarThrowExeptionWithCarModelDoesetExist()
            {
                //Arrange
                const string carmodel = "Opel";
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carmodel, 15);
                //Act
                garage.AddCar(secondCar);
                var fixedCar = garage.FixCar(carmodel);
                //Assert
                Assert.That(fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo(carmodel));
                Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            }
            [Test]
            public void GarageRemovedCarShoudThrowExeptionIfNoFixedCarsAreAvailable()
            {
                const string carmodel = "Opel";
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carmodel, 15);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }
            [Test]
            public void GarageRemoveFixedCarShoudRemoveFixedCars()
            {
                //Arrange
                const string carmodel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carmodel, 15);
                var thirdCar = new Car("BMW",50);
                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(carmodel);
                var fixedcar = garage.RemoveFixedCar();

                Assert.That(fixedcar, Is.EqualTo(1));
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }
            [Test]
            public void GarageReportShoudShowCorrectRezult()
            {
                //Arrange
                const string carmodel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carmodel, 15);
                var thirdCar = new Car("BMW", 50);
                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(carmodel);
                var report = garage.Report();

                Assert.That(report,Is.EqualTo($"There are 2 which are not fixed: Mercedes, BMW."));
            }
        }
    }
}