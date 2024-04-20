using SocialMediaAPI.Dto.Account;
using SocialMediaAPI.Models;
using System.Linq;
using System.Net.NetworkInformation;

namespace SocialMediaAPI.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(this Account account)
        {
            return new AccountDto
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName,
                FollowersCount = account.FollowersCount,
                FollowingCount = account.FollowingCount,
                PostCount = account.PostCount,
                CreationDate = account.CreationDate,
                Comments = (List<Dto.Comment.CommentDto>)account.comments.Select(c => c.ToCommentDto()),


            };
        }

        public static Account ToAccountFromCreateDTO(this CreateAccountRequestDto accountDto)
        {
            return new Account
            {
                AccountName = accountDto.AccountName,
                FollowersCount = accountDto.FollowersCount,
                FollowingCount = accountDto.FollowingCount,
                PostCount = accountDto.PostCount,
                
            };
        }
    }
}
