namespace TDDProblems.KataPotter
{
    public class Calculator
    {
        public double Price(params int[] books)
        {
            var cart = new Cart();

            foreach (var book in books)
                cart.Add(book);

            return cart.Total;
        }
    }
}