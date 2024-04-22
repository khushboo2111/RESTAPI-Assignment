using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Dto.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public string Title { get; set; }
     
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Guid? AccountId { get; set; }

       
    }
}



