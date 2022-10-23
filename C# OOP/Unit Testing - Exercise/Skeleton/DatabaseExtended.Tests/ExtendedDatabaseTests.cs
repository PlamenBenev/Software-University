namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]

        public void DatabaseLength()
        {
            Person[] datatest16 = new Person[16];
            for (int i = 0; i < datatest16.Length; i++)
            {
                datatest16[i] = new Person(123 + i, "gosho" + i.ToString());
            }
            Database database16 = new Database(datatest16);

            Assert.True(database16.Count == 16);
        }
        [Test]
        public void DublicatingUsernames()
        {
            Person gosho = new Person(123, "gosho");
            Person pesho = new Person(456, "pesho");
            Person pesho2 = new Person(321, "pesho");

            Database database = new Database(gosho, pesho);

            Assert.That(() => database.Add(pesho2),
                Throws.InvalidOperationException.With.Message
                .EqualTo("There is already user with this username!"));
        }
        [Test]
        public void DublicatingID()
        {
            Person gosho = new Person(123, "gosho");
            Person pesho = new Person(456, "pesho");
            Person grisho = new Person(123, "grisho");

            Database database = new Database(gosho, pesho);

            Assert.That(() => database.Add(grisho),
                Throws.InvalidOperationException.With.Message
                .EqualTo("There is already user with this Id!"));
        }
        [Test]
        public void CountAfterRemoving()
        {
            Person gosho = new Person(123, "gosho");
            Person pesho = new Person(456, "pesho");

            Database database = new Database(gosho, pesho);
            database.Remove();

            Assert.True(database.Count == 1);
            database.Remove();
            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException);
        }
        [Test]
        public void CheckTheNameIfItsExist()
        {
            Person goshoAnonimniq = new Person(123, "gosho");

            Database database = new Database(goshoAnonimniq);

            Assert.That(() => database.FindByUsername("kiro"),
                Throws.InvalidOperationException.With.Message
                .EqualTo("No user is present by this username!"));
        }
        [Test]
        public void IfUsernameIsNullExeption()
        {
            Database database = new Database();

            Assert.That(() => database.FindByUsername(null),
                Throws.ArgumentNullException);
        }
        [Test]
        public void ArgumentsAreCaseSensitive()
        {
            Person goshoAnonimniq = new Person(123, "gosho");

            Database database = new Database(goshoAnonimniq);

            Assert.That(() => database.FindByUsername("GOSHO"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IsThereSuchId()
        {
            Person goshoAnonimniq = new Person(123, "gosho");

            Database database = new Database(goshoAnonimniq);

            Assert.That(() => database.FindById(234)
            , Throws.InvalidOperationException);
        }
        [Test]
        public void IsItNegativeId()
        {
            Person goshoAnonimniq = new Person(123, "gosho");

            Database database = new Database(goshoAnonimniq);

            Assert.That(() => database.FindById(-234)
            , Throws.Exception);
        }
    }
}