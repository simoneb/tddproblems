using NUnit.Framework;

namespace TDDProblems.KataPotter
{
    [TestFixture]
    public class Test : Calculator
    {
        [Test]
        public void No_books_are_0()
        {
            Assert.AreEqual(0, Price());
        }

        [Test]
        public void One_book_is_8()
        {
            Assert.AreEqual(8, Price(0));
        }

        [Test]
        public void Two_same_books_is_16()
        {
            Assert.AreEqual(8 * 2, Price(0, 0));
        }

        [Test]
        public void Three_same_books_is_24()
        {
            Assert.AreEqual(8 * 3, Price(1, 1, 1));
        }

        [Test]
        public void Two_distinct_books_should_get_5_percent_discount()
        {
            Assert.AreEqual(8 * 2 * 0.95, Price(0, 1));
        }

        [Test]
        public void Three_distinct_books_should_get_10_percent_discount()
        {
            Assert.AreEqual(8 * 3 * 0.9, Price(0, 2, 4));
        }

        [Test]
        public void Four_distinct_books_should_get_20_percent_discount()
        {
            Assert.AreEqual(8 * 4 * 0.8, Price(0, 1, 2, 4));
        }

        [Test]
        public void Five_distinct_books_should_get_25_percent_discount()
        {
            Assert.AreEqual(8 * 5 * 0.75, Price(0, 1, 2, 3, 4));
        }

        [Test]
        public void Mixed_case()
        {
            Assert.AreEqual(8 + (8 * 2 * 0.95), Price(0, 0, 1));
        }

        [Test]
        public void Complex_case()
        {
            Assert.AreEqual(51.2, Price(0, 0, 1, 1, 2, 2, 3, 4));
        }
    }
}