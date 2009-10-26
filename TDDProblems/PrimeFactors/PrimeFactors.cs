using System.Collections.Generic;
using System.Linq;

namespace TDDProblems.PrimeFactors
{
    public class PrimeFactors
    {
        protected static int[] Factor(int n)
        {
            return FactorEnumerable(n).ToArray();
        }

        private static IEnumerable<int> FactorEnumerable(int n)
        {
            if(n <= 0) yield break;

            var factor = 2;

            while (n > 1)
            {
                while (n%factor == 0)
                {
                    n /= factor;
                    yield return factor;
                }

                ++factor;
            }
        }
    }
}