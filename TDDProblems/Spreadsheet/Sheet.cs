using System;
using System.Collections.Generic;
using System.Text;

namespace TDDProblems.Spreadsheet
{
    public class Sheet
    {
        private readonly Dictionary<string, string> lookup = new Dictionary<string, string>();

        public string this[string cell]
        {
            get
            {
                if (!lookup.ContainsKey(cell))
                    return "";

                string formula = lookup[cell];
                if (formula.StartsWith("="))
                    return ComputeFormula(formula.Substring(1));

                int parsedValue;
                return int.TryParse(lookup[cell], out parsedValue) ? lookup[cell].Trim() : lookup[cell];
            }
            set
            {
                lookup[cell] = value;
            }
        }

        private string ComputeFormula(string formula)
        {
            var currentOperator = string.Empty;
            var leftDigits = new StringBuilder();
            var rightDigits = new StringBuilder();

            foreach (var ch in formula)
            {

                if (char.IsDigit(ch))
                {
                    if (currentOperator == String.Empty)
                        leftDigits.Append(ch);
                    else
                        rightDigits.Append(ch);
                }
                else if (ch == '(' || ch == ')')
                    continue;
                else
                {
                    leftDigits = GetLeftDigits(currentOperator, leftDigits, ref rightDigits);
                    currentOperator = ch.ToString();
                }
            }

            leftDigits = GetLeftDigits(currentOperator, leftDigits, ref rightDigits);

            return leftDigits.ToString();
        }

        private StringBuilder GetLeftDigits(string currentOperator, StringBuilder leftDigits, ref StringBuilder rightDigits)
        {
            if (currentOperator == "*")
            {
                int left = int.Parse(leftDigits.ToString());
                int right = int.Parse(rightDigits.ToString());
                int product = left*right;
                leftDigits = new StringBuilder(product.ToString());
                rightDigits = new StringBuilder();
            }
            if (currentOperator == "+")
            {
                int left = int.Parse(leftDigits.ToString());
                int right = int.Parse(rightDigits.ToString());
                int sum = left + right;
                leftDigits = new StringBuilder(sum.ToString());
                rightDigits = new StringBuilder();
            }
            return leftDigits;
        }

        public string GetLiteral(string cell)
        {
            return lookup[cell];
        }
    }
}