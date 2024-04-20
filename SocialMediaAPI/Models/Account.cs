namespace SocialMediaAPI.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public int PostCount { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public List<Comment>? comments { get; set; }
    }

}
