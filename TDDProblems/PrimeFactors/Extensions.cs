using System.Linq;
using NUnit.Framework;

namespace TDDProblems.PrimeFactors
{
    public static class Extensions
    {
        public static void ShouldEq(this int[] actual, params int[] expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static int[] Times(this int times, int n)
        {
            return Enumerable.Repeat(n, times).ToArray();
        }
    }
}