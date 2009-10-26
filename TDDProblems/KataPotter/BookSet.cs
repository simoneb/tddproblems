using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDProblems.KataPotter
{
    internal class BookSet
    {
        private readonly List<int> books = new List<int>();

        public BookSet(int book)
        {
            books.Add(book);
        }

        public double Total
        {
            get { return TotalWith(books); }
        }

        private static double ComputeDiscount(IEnumerable<int> books)
        {
            switch(books.Count())
            {
                case 1: return 0;
                case 2: return 0.05;
                case 3: return 0.1;
                case 4: return 0.2;
                case 5: return 0.25;
                default: throw new NotSupportedException();
            }
        }

        public bool CanAccept(int book)
        {
            return !books.Contains(book);
        }

        public void Accept(int book)
        {
            books.Add(book);
        }

        public double TotalWith(int book)
        {
            return TotalWith(books.Concat(new[] {book}));
        }

        private static double TotalWith(IEnumerable<int> books)
        {
            return 8 * books.Count() * (1 - ComputeDiscount(books));
        }
    }
}