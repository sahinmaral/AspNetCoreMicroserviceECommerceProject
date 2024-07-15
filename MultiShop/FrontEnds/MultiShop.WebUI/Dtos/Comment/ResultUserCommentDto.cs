namespace MultiShop.WebUI.Dtos.Comment
{
    public class ResultUserCommentDto
    {
        public string Id { get; set; }
        public string UserImageUrl { get; set; }
        public string UserNameSurname { get; set; }
        public string UserEmail { get; set; }
        public string ProductId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
