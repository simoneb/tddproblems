using NUnit.Framework;

namespace TDDProblems.StringCalculator
{
    [TestFixture]
    public class StringCalculatorTest : StringCalculator
    {
        [Test]
        public void Empty_string_should_give_0()
        {
            Assert.AreEqual(0, Calculate(""));
        }

        [Test]
        public void _1_should_give_1()
        {
            Assert.AreEqual(1, Calculate("1"));
        }

        [Test]
        public void _1_comma_1_should_be_2()
        {
            Assert.AreEqual(2, Calculate("1,1"));
        }

        [Test]
        public void _1_comma_2_should_be_3()
        {
            Assert.AreEqual(3, Calculate("1,2"));
        }

        [Test]
        public void _1_newline_1_should_be_2()
        {
            Assert.AreEqual(2, Calculate("1\n1"));
        }

        [Test]
        public void _1_newline_2_comma_3_should_be_6()
        {
            Assert.AreEqual(6, Calculate("1\n2,3"));
        }

        [Test]
        public void Should_accept_new_delimiter()
        {
            Assert.AreEqual(2, Calculate("//;\n1;1"));
        }
    }
}