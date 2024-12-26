namespace Shopee.Application.Exceptions
{
    public class ResourceNotFoundException : KeyNotFoundException
    {
        public ResourceNotFoundException(string message) : base(message)
        {

        }
    }
}
