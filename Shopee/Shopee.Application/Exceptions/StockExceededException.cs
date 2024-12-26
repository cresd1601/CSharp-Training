namespace Shopee.Application.Exceptions
{
    public class StockExceededException : Exception
    {
        public int AvailableStock { get; }

        public StockExceededException(int availableStock) : base($"The requested quantity exceeds the available stock. Available stock: {availableStock}.")
        {
            AvailableStock = availableStock;
        }
    }
}
