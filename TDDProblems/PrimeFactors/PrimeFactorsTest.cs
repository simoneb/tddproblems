using NUnit.Framework;

namespace TDDProblems.PrimeFactors
{
    [TestFixture]
    public class PrimeFactorsTest : TDDProblems.PrimeFactors.PrimeFactors
    {
        [Test]
        public void Should_factor_1()
        {
            Factor(1).ShouldEq();
        }

        [Test]
        public void Should_factor_2()
        {
            Factor(2).ShouldEq(2);
        }

        [Test]
        public void Should_factor_3()
        {
            Factor(3).ShouldEq(3);
        }

        [Test]
        public void Should_factor_4()
        {
            Factor(4).ShouldEq(2, 2);
        }

        [Test]
        public void Should_factor_5()
        {
            Factor(5).ShouldEq(5);
        }

        [Test]
        public void Should_factor_6()
        {
            Factor(6).ShouldEq(2, 3);
        }

        [Test]
        public void Should_factor_7()
        {
            Factor(7).ShouldEq(7);
        }

        [Test]
        public void Should_factor_8()
        {
            Factor(8).ShouldEq(2, 2, 2);
        }

        [Test]
        public void Should_factor_9()
        {
            Factor(9).ShouldEq(3, 3);
        }

        [Test]
        public void Should_factor_any_product_of_primes()
        {
            Factor(11 * 19 * 29 * 43).ShouldEq(11, 19, 29 , 43);
        }

        [Test]
        public void Should_factor_big_power_of_2()
        {
            Factor(4096).ShouldEq(12.Times(2));
        }
    }
}