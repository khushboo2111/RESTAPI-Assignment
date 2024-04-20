using SocialMediaAPI.Dto.Comment;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Account
{
    public class CreateAccountRequestDto
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public int FollowersCount { get; set; }
        [Required]
        public int FollowingCount { get; set; }
        [Required]
        public int PostCount { get; set; }
        public List<CommentDto> Comments {  get; set; }    
    }
}
