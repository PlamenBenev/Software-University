namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium = null;
        [Test]
        public void NameExeption()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium(null, 5);
            });
        }
        [Test]
        public void CapacityExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                aquarium = new Aquarium("aqua", -1);
            });
        }
        [Test]
        public void ProperlyParamsReturn()
        {
            aquarium = new Aquarium("aqua", 5);

            Assert.True(aquarium.Name == "aqua");
            Assert.True(aquarium.Capacity == 5);
        }
        [Test]
        public void AquariumFishCount()
        {
            aquarium = new Aquarium("aqua", 5);
            Fish fish = new Fish("nemo");

            aquarium.Add(fish);

            Assert.True(aquarium.Count == 1);
        }
        [Test]
        public void AddingFishException()
        {
            aquarium = new Aquarium("aqua", 1);
            Fish fish = new Fish("nemo");
            Fish fish2 = new Fish("Canko");

            aquarium.Add(fish);

            Assert.That(() => aquarium.Add(fish2),
                Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveFishException()
        {
            aquarium = new Aquarium("aqua", 1);
            Fish fish = new Fish("nemo");

            aquarium.Add(fish);

            Assert.That(() => aquarium.RemoveFish("nemoo"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveFishProperlyReturn()
        {
            aquarium = new Aquarium("aqua", 1);
            Fish fish = new Fish("nemo");

            aquarium.Add(fish);
            aquarium.RemoveFish("nemo");
            Assert.True(aquarium.Count == 0);
        }
        [Test]
        public void SellFishException()
        {
            aquarium = new Aquarium("aqua", 1);
            Fish fish = new Fish("nemo");

            aquarium.Add(fish);

            Assert.That(() => aquarium.SellFish("nemoo"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void AvalibleAfterSellFish()
        {
            aquarium = new Aquarium("aqua", 1);
            Fish fish = new Fish("nemo");

            aquarium.Add(fish);
            aquarium.SellFish("nemo");

            Assert.True(fish.Available == false);
        }
        [Test]
        public void SellFishReturnsTheRequestedFish()
        {
            aquarium = new Aquarium("aqua", 1);
            Fish fish = new Fish("nemo");

            aquarium.Add(fish);

            Assert.True(aquarium.SellFish("nemo") == fish);
        }
        [Test]
        public void ReportReturnProperly()
        {
            aquarium = new Aquarium("aqua", 2);
            Fish fish = new Fish("nemo");
            Fish fish2 = new Fish("Canko");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.True(aquarium.Report() == $"Fish available at aqua: nemo, Canko");
        }
        [Test]
        public void FishParamsAreCorrect()
        {
            Fish nemo = new Fish("Nemo");
            Assert.True(nemo.Name == "Nemo");
            Assert.True(nemo.Available == true);
        }
    }
}
