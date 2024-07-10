namespace MultiShop.Catalog.Exceptions
{
    public class EntityNullException : Exception
    {
        public EntityNullException()
        {
        }

        public EntityNullException(string message)
            : base(message)
        {
        }

        public EntityNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
