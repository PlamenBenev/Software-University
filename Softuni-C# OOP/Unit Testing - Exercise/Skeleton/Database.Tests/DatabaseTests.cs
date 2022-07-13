namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]

        public void DatabaseLength()
        {
            int[] datatest16 = new int[]
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            Database database16 = new Database(datatest16);

            Assert.True(database16.Count == 16);
        }
        [Test]
        public void ExeptionAtLength()
        {
            int[] datatest1 = new int[] {1};

            Database database1 = new Database(datatest1);

            Assert.That(() => database1.Count != 16,
            Throws.InvalidOperationException);
        }
        [Test]
        public void AddElementAtFreeCell()
        {
            int[] datatest15 = new int[]
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Database database1 = new Database(datatest15);

            database1.Add(16);

            Assert.IsTrue(database1.Fetch()[15] == 16);
        }
        [Test]
        public void ExeptionOnAdd()
        {
            int[] datatest16 = new int[]
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            Database database2 = new Database(datatest16);
            // database2.Add(17);

            Assert.That(() => database2.Add(17),
            Throws.InvalidOperationException.With.Message
            .EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void RemoveAtLastIndex()
        {
            int[] datatest15 = new int[]
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            Database database1 = new Database(datatest15);

            database1.Remove();

            Assert.IsTrue(database1.Fetch().Length == 15);
        }
        [Test]
        public void ExeptionAtRemove()
        {
            Database database1 = new Database();

            Assert.That(() => database1.Remove(),
            Throws.InvalidOperationException.With.Message
            .EqualTo("The collection is empty!"));
        }
    }
}
