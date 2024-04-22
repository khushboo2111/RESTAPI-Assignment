using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Account
{
    public class UpdateAccountRequestDto
    {
        
        public string AccountName { get; set; }
        
        public int FollowersCount { get; set; }
        
        public int FollowingCount { get; set; }
       
        public int PostCount { get; set; }
    }
}
