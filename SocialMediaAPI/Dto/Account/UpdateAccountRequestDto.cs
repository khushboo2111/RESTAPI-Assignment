using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Account
{
    public class UpdateAccountRequestDto
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public int FollowersCount { get; set; }
        [Required]
        public int FollowingCount { get; set; }
        [Required]
        public int PostCount { get; set; }
    }
}
