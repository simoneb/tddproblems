using System.Collections.ObjectModel;
using System.Linq;

namespace TDDProblems.KataPotter
{
    public class Cart
    {
        private readonly Collection<BookSet> bookSets = new Collection<BookSet>();

        public void Add(int book)
        {
            if (bookSets.Any(s => s.CanAccept(book)))
                (from set in bookSets
                let totalWithNewBook = set.TotalWith(book)
                orderby totalWithNewBook
                select set)
                .First()
                .Accept(book);
            else
                bookSets.Add(new BookSet(book));
        }

        public double Total
        {
            get { return bookSets.Sum(s => s.Total); }
        }
    }
}