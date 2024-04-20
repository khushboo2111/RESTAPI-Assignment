using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Dto.Comment;
using SocialMediaAPI.Mappers;
using SocialMediaAPI.Models;
using SocialMediaAPI.Repository;

namespace SocialMediaAPI.Controllers
{
    [Route("SocialMediaAPI/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context, ICommentRepository commentRepository, IAccountRepository accountRepository)
        {
            _commentRepo = commentRepository;
            _accountRepo = accountRepository;
            _context = context;
            var sampleAccounts = SampleData.GenerateSampleAccounts();
            var sampleComments = SampleCommentData.GenerateSampleComments(sampleAccounts);
            foreach (var comment in sampleComments)
            {
               _context.Comments.Add(comment);

            }
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        
        [HttpPost("{accountId}")]
        public async Task<IActionResult> Create([FromRoute] Guid accountId, CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _accountRepo.AccountExists(accountId))
            {
                return BadRequest("Account does not exist");
            }
            var comment = commentDto.ToCommentCreateDto(accountId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new {id= comment}, comment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]UpdateCommentRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentUpdateDto());
            if(comment == null)
            {
                NotFound("Comment not found");
            }
            return Ok(comment.ToCommentDto());   
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commnent = await _commentRepo.DeleteAsync(id);
            if(commnent == null) {
                NotFound("Comment Not Found");
            }
            return NoContent(); 
        }
        

    }
}
