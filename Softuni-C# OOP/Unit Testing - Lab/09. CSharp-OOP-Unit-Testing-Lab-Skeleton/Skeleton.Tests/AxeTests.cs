using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void DurabilityLoose()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackWithBrokenWeapon()
        {
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),
           Throws.InvalidOperationException
           .With.Message.EqualTo("Axe is broken."));
        }
    }
}