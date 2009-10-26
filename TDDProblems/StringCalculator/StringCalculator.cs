using System;
using System.Linq;

namespace TDDProblems.StringCalculator
{
    public class StringCalculator
    {
        public static int Calculate(string value)
        {
            if (value == String.Empty)
                return 0;

            var delimiters = new[] { ",", "\n" };

            if (value.StartsWith("//"))
            {
                delimiters = new[]{value.Substring(2, value.IndexOf("\n") - 2)};
                value = value.Substring(value.IndexOf("\n") + 1);
            }

            var values = value.Split(delimiters, StringSplitOptions.None);

            return values.Select(v => int.Parse(v)).Sum();
        }
    }
}