namespace Shopee.Application.Exceptions
{
    public class EmptyCartException : Exception
    {
        public EmptyCartException() : base("Your cart is empty.")
        {

        }
    }
}