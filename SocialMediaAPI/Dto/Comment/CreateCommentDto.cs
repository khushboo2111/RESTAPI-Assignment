using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Comment
{
    public class CreateCommentDto
    {
        
        public string Title { get; set; }
        
        public string Content { get; set; }
    }
}
