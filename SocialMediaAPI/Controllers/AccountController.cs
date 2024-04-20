using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dto.Account;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;
using SocialMediaAPI.Repository;

namespace SocialMediaAPI.Controllers
{
    [Route("SocialMediaAPI/Account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountRepository accountRepo;
        public AccountController(ApplicationDbContext context, IAccountRepository accountRepo)
        {
            _context = context;
            this.accountRepo = accountRepo;
            var sampleAccounts = SampleData.GenerateSampleAccounts();
            var sampleComments = SampleCommentData.GenerateSampleComments(sampleAccounts);
            foreach (var account in sampleAccounts)
            {
                _context.Accounts.Add(account);

            }

            /*foreach (var comment in sampleComments)
            {
               _context.Comments.Add(comment);
            }*/
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accounts = await accountRepo.GetAllAsync();
            var accountDto = accounts.Select(s => s.ToAccountDto());
            return Ok(accounts);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var account = await accountRepo.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account.ToAccountDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequestDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accountModel = accountDto.ToAccountFromCreateDTO();
            await accountRepo.CreateAsync(accountModel);
            return CreatedAtAction(nameof(GetById), new { id = accountModel.AccountId }, accountModel.ToAccountDto());
        }

        [HttpPut]
        [Route("{id: Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAccountRequestDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accountModel = await accountRepo.UpdateAsync(id, accountDto);   
            if (accountModel == null)
            {
                return NotFound();
            }           
            return Ok(accountModel.ToAccountDto());
        }

        [HttpDelete]
        [Route("{id: Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accountModel = await accountRepo.DeleteAsync(id);
            if(accountModel  == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }


    }

