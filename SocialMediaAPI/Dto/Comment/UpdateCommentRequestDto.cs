using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
