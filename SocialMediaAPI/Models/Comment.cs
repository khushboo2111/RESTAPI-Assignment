namespace SocialMediaAPI.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn{ get; set; } = DateTime.Now;
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
