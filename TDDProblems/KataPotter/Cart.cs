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
                bookSets.Where(g => g.CanAccept(book))
                    .Select(s => new { Set = s, TotalWithNewBook = s.TotalWith(book) })
                    .OrderBy(g => g.TotalWithNewBook)
                    .Select(g => g.Set)
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