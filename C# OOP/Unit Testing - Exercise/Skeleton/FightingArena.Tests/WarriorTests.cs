namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void IsNameNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior war = new Warrior(" ", 30, 31);
                Warrior war2 = new Warrior(null, 30, 31);
            });
        }
        [Test]
        public void DamageIsPositive()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior war = new Warrior("pesho", -30, 31);
            });
        }
        [Test]
        public void HPIsPositive()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior war = new Warrior("pesho", 30, -31);
            });
        }
        [Test]
        public void IfAttackerHPIsTooLowExeption()
        {
            Warrior war = new Warrior("pesho", 30, 29);
            Warrior def = new Warrior("pesho", 30, 41);

            Assert.That(() => war.Attack(def),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IfDefenderHPIsTooLowExeption()
        {
            Warrior war = new Warrior("pesho", 30, 30);
            Warrior def = new Warrior("pesho", 30, 29);

            Assert.That(() => war.Attack(def),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IfTheEnemyIsTooStrongExeption()
        {
            Warrior war = new Warrior("pesho", 30, 30);
            Warrior def = new Warrior("pesho", 31, 35);

            Assert.That(() => war.Attack(def),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IfAttackerTakeDamage()
        {
            Warrior war = new Warrior("pesho", 32, 36);
            Warrior def = new Warrior("pesho", 31, 35);
            war.Attack(def);

            Assert.True(war.HP == 5);
        }
        [Test]
        public void IfDefenderDies()
        {
            Warrior war = new Warrior("pesho", 32, 36);
            Warrior def = new Warrior("pesho", 31, 31);
            war.Attack(def);

            Assert.True(def.HP == 0);
        }
        [Test]
        public void IfDefenderTakeDamage()
        {
            Warrior war = new Warrior("pesho", 32, 36);
            Warrior def = new Warrior("pesho", 31, 33);
            war.Attack(def);

            Assert.True(def.HP == 1);
        }
    }
}