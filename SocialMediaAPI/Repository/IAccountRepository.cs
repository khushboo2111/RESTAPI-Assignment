using SocialMediaAPI.Dto.Account;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository
{
    public interface IAccountRepository
    {

        public Task<List<Account>> GetAllAsync();
        public Task<Account> GetByIdAsync(Guid id);
        public Task<Account>CreateAsync(Account account);
        public Task<Account> UpdateAsync(Guid id, UpdateAccountRequestDto accountDto);
        public Task<Account> DeleteAsync(Guid id);
        public Task<bool> AccountExists(Guid id);
    }
}
