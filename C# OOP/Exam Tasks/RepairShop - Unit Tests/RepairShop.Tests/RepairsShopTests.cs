using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void ConstructorCheck()
            {
                Garage garage = new Garage("bbs", 3);

                Assert.True(garage != null);
            }
            [Test]
            public void NameIsNotEquelToNull()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage("", 3);
                });
            }
            [Test]
            public void MechanicsAreNotZeroOrLess()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("bbs", 0);
                    Garage garage2 = new Garage("bbs", -1);
                });
            }
            [Test]
            public void CountOfTheCars()
            {
                Car car1 = new Car("Audi",2);
                Car car2 = new Car("VW", 3);

                Garage garage = new Garage("bbs", 3);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.That(garage.CarsInGarage == 2);
            }
            [Test]
            public void AddCarExeption()
            {
                Car car1 = new Car("Audi", 2);
                Car car2 = new Car("VW", 3);
                Garage garage = new Garage("bbs", 1);
                garage.AddCar(car2);

                Assert.That(() => garage.AddCar(car1),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void FixCarExeption()
            {
                Car car2 = new Car("VW", 3);
                Garage garage = new Garage("bbs", 1);
                garage.AddCar(car2);

                Assert.That(() => garage.FixCar("Moskvich"),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void IsTheCarFixed()
            {
                Car car2 = new Car("VW", 3);
                Garage garage = new Garage("bbs", 1);
                garage.AddCar(car2);
                garage.FixCar("VW");

                Assert.True(garage.FixCar("VW").NumberOfIssues == 0);
                Assert.True(garage.FixCar("VW").IsFixed == true);
            }
            [Test]
            public void DoesFixCarReturnTheCar()
            {
                Car car2 = new Car("VW", 3);
                Garage garage = new Garage("bbs", 1);
                garage.AddCar(car2);
                garage.FixCar("VW");

                Assert.True(garage.FixCar("VW") == car2);
            }
            [Test]
            public void FixedCarRemoveExeption()
            {
                Car car2 = new Car("VW", 1);
                Garage garage = new Garage("bbs", 1);
                garage.AddCar(car2);

                Assert.That(() => garage.RemoveFixedCar(),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void DoesFixedCarReturnTheNumOfFixedCars()
            {
                Car car2 = new Car("VW", 1);
                Garage garage = new Garage("bbs", 1);
                garage.AddCar(car2);
                garage.FixCar("VW");

                Assert.True(garage.RemoveFixedCar() == 1);
            }
            [Test]
            public void IsTheCarNull()
            {
                Car car1 = new Car("VW", 1);

                Assert.True(car1.CarModel != null);
                Assert.True(car1.NumberOfIssues > 0);
            }
        }
    }
}