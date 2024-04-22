using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dto.Account;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Data.DbInitializer _context;
        
        public AccountRepository(Data.DbInitializer applicationDbContext) {
            _context = applicationDbContext;           
        }

        Task<bool> IAccountRepository.AccountExists(Guid id)
        {
            return _context.Accounts.AnyAsync(s => s.AccountId == id);
        }

        async Task<Account> IAccountRepository.CreateAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

         async Task<Account> IAccountRepository.DeleteAsync(Guid id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if(account == null)
            {
                return null;
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return account;
        }

        async Task<List<Account>> IAccountRepository.GetAllAsync()
        {
            return await _context.Accounts.Include(c => c.comments).ToListAsync();

        }

         async Task<Account> IAccountRepository.GetByIdAsync(Guid id)
        {
            return await _context.Accounts.Include(c => c.comments).FirstOrDefaultAsync(i => i.AccountId == id);
        }

        async Task<Account> IAccountRepository.UpdateAsync(Guid id, UpdateAccountRequestDto accountDto)
        {
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (existingAccount == null)
            {
                return null;
            }

                existingAccount.AccountName = accountDto.AccountName;   
                existingAccount.FollowersCount = accountDto.FollowersCount; 
                existingAccount.FollowingCount = accountDto.FollowingCount;
                existingAccount.PostCount = accountDto.PostCount;
            await _context.SaveChangesAsync();
            return existingAccount;
            
        }
    }
}
