namespace MultiShop.Comment.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedAt { get; set; }
    }
}
