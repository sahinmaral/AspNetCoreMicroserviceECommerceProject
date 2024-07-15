using MultiShop.Comment.Entities.Abstract;

namespace MultiShop.Comment.Entities.Concrete
{
    public class UserComment: BaseEntity
    {
        public string UserImageUrl { get; set; }
        public string UserNameSurname { get; set; }
        public string UserEmail { get; set; }
        public string ProductId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public bool Status { get; set; }
    }
}
