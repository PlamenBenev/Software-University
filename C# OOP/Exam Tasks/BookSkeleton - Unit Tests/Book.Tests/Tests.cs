namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorProperties()
        {
            Book book = new Book("Harry Potter", "J K Rowling");

            Assert.True(book.BookName == "Harry Potter");
            Assert.True(book.Author == "J K Rowling");
        }
        [Test]
        public void FootnoteCount()
        {
            Book book = new Book("Harry Potter", "J K Rowling");
            book.AddFootnote(123, "asd");

            Assert.True(book.FootnoteCount == 1);
        }
        [Test]
        public void BookNameIsNullException()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, "J K Rowling");
            });
        }
        [Test]
        public void BookAuthorIsNullException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Harry Potter",null);
            });
        }
        [Test]
        public void AddFootnoteException()
        {
            Book book = new Book("Harry Potter", "J K Rowling");
            book.AddFootnote(123, "asd");

            Assert.That(() => book.AddFootnote(123, "dsa"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void FindFootnoteException()
        {
            Book book = new Book("Harry Potter", "J K Rowling");
            book.AddFootnote(123, "asd");

            Assert.That(() => book.FindFootnote(321),
                Throws.InvalidOperationException);
        }
        [Test]
        public void FindFootnoteReturns()
        {
            Book book = new Book("Harry Potter", "J K Rowling");
            book.AddFootnote(123, "asd");

            Assert.True(book.FindFootnote(123) == $"Footnote #123: asd");
        }
        [Test]
        public void AlterFootnoteException()
        {
            Book book = new Book("Harry Potter", "J K Rowling");
            book.AddFootnote(123, "asd");

            Assert.That(() => book.AlterFootnote(321,"dsa"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void AlterFootnoteReturns()
        {
            Book book = new Book("Harry Potter", "J K Rowling");
            book.AddFootnote(123, "asd");

            book.AlterFootnote(123,"dsa");

            Assert.True(book.FindFootnote(123) == $"Footnote #123: dsa");
        }
    }
}