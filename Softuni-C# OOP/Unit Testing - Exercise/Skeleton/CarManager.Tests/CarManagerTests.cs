namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;


        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.car);
        }
        [Test]
        public void ConstructorTest()
        {
            car = new Car("audi", "a3", 4.4, 48.5);

            Assert.True(car.Make == "audi");
            Assert.True(car.Model == "a3");
            Assert.True(car.FuelConsumption == 4.4);
            Assert.True(car.FuelCapacity == 48.5);
        }
        [Test]
        public void IsMakeNullOrEmptyExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(null, "A4", 15, 300);
            });
        }
        [Test]
        public void IsModelNullOrEmptyExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("audi", null, 15, 300);
            });
        }
        [Test]
        public void IsFuelNegativeExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("audi", "a3", -15, 300);
            });
        }
        [Test]
        public void IsFuelCapacityNegativeExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("audi", "a3", 15, -300);
            });
        }
        [Test]
        public void IsFuelAmountNegativeExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("audi", "a3", 15, 300);
                newCar.Refuel(-1);
            });
        }
        [Test]
        public void IsFuelAmountOverCapacity()
        {
                Car newCar = new Car("audi", "a3", 15, 30);
            newCar.Refuel(31);
            Assert.True(newCar.FuelAmount == 30);
        }
        [Test]
        public void IsItEnoughFuel()
        {
            Car newCar = new Car("audi", "a3", 15, 30);

            Assert.That(() => newCar.Drive(999),
            Throws.InvalidOperationException);
        }
        [Test]
        public void TestRefuelWithZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }
        [Test]
        public void TestFuelAmount()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }
        [Test]
        public void ConsumingFuelWhenDrive()
        {
            Car newCar = new Car("audi", "a3", 15, 30);
            newCar.Refuel(30);
            newCar.Drive(5);
            Assert.True(newCar.FuelAmount == newCar.FuelAmount - (5 / 100) * 15);
        }
    }
}