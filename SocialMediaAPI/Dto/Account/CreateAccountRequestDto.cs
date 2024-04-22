using SocialMediaAPI.Dto.Comment;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Account
{
    public class CreateAccountRequestDto
    {
        public string AccountName { get; set; }
        
        public int FollowersCount { get; set; }
    
        public int FollowingCount { get; set; }
      
        public int PostCount { get; set; }

        //public List<CommentDto> Comments {  get; set; }    
    }
}
