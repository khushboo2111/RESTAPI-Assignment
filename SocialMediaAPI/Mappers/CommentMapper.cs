using SocialMediaAPI.Dto.Comment;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Mappers
{
    public static class  CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel )
        {
            return new CommentDto
            {
                CommentId = commentModel.CommentId,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                AccountId = commentModel.AccountId,
            };
        }
        
        public static Comment ToCommentCreateDto(this CreateCommentDto commentDto, Guid AccountId )
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                AccountId = AccountId
            };
        }
        
        
         public static Comment ToCommentUpdateDto(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
               
            };
        }
    }
}
