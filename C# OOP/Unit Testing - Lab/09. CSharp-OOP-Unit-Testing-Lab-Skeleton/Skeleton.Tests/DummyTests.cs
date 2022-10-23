using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LosingHealth()
        {
            Dummy dummy = new Dummy(11, 10);

            dummy.TakeAttack(10);

            Assert.True(dummy.Health == 1);
        }
        [Test]
        public void DeadDummyExeptionWhenAttacked()
        {
            Dummy dummy = new Dummy(1, 10);

            dummy.TakeAttack(10);

            Assert.That(() => dummy.TakeAttack(10), Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(11, 10);

            dummy.TakeAttack(10);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(1, 10);

            dummy.TakeAttack(10);

            Assert.True(dummy.GiveExperience() == 10);
        }
    }
}