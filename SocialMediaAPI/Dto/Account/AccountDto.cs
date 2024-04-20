using SocialMediaAPI.Dto.Comment;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Account
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public int FollowersCount { get; set; }

        [Required]
        public int FollowingCount { get; set; }

        [Required]
        public int PostCount { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<CommentDto> Comments { get; set; }  
    }
}
