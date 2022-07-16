namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        Arena arena = new Arena();
        [Test]
        public void IsArenaNull()
        {
            Assert.True(arena != null);
        }
        [Test]
        public void MakingCollection()
        {
            List<Warrior> list = new List<Warrior>();

            CollectionAssert.AreEqual(arena.Warriors,  list);
        }
        [Test]
        public void CountAndAddingInTheCollection()
        {
            Warrior war1 = new Warrior("goshoGladiatora", 5, 4);
            Warrior war2 = new Warrior("peshoGladiatora", 3, 6);

            Arena newArena = new Arena();
            newArena.Enroll(war1);
            newArena.Enroll(war2);

            Assert.True(newArena.Count == 2);
        }
        [Test]
        public void ExeptionIfTheNameExist()
        {
            Warrior war1 = new Warrior("goshoGladiatora", 5, 4);
            Warrior war2 = new Warrior("goshoGladiatora", 3, 6);

            Arena newArena = new Arena();
            newArena.Enroll(war1);

            Assert.That(() => newArena.Enroll(war2)
            , Throws.InvalidOperationException);
        }
        [Test]
        public void FightExeption()
        {
            Warrior war1 = new Warrior("goshoGladiatora", 5, 4);
            Warrior war2 = new Warrior("peshoGladiatora", 3, 6);

            Arena newArena = new Arena();
            newArena.Enroll(war1);
            newArena.Enroll(war2);

            Assert.That(() => newArena.Fight(null,"peshoGladiatora")
            ,Throws.InvalidOperationException);
            Assert.That(() => newArena.Fight("peshoGladiatora", null)
            , Throws.InvalidOperationException);
            Assert.That(() => newArena.Fight(null, null)
            , Throws.InvalidOperationException);
        }
        [Test]
        public void DoesFightTakeDamage()
        {
            Warrior war1 = new Warrior("goshoGladiatora", 30, 31);
            Warrior war2 = new Warrior("peshoGladiatora", 30, 32);

            Arena newArena = new Arena();
            newArena.Enroll(war1);
            newArena.Enroll(war2);
            newArena.Fight("peshoGladiatora", "goshoGladiatora");

            Assert.True(war1.HP == 1);
        }
    }
}
