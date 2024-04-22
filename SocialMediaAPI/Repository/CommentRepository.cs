using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Data.DbInitializer _context;
        
        public CommentRepository(Data.DbInitializer applicationDbContext) {

            this._context = applicationDbContext;
        }
        async Task<List<Comment>> ICommentRepository.GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

         async Task<Comment?> ICommentRepository.GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        }


        async Task<Comment> ICommentRepository.CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
           
        }

        async Task<Comment?> ICommentRepository.UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;
            await _context.SaveChangesAsync();  
            return existingComment; 
        }

        async Task<Comment> ICommentRepository.DeleteAsync(int id)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }
            _context.Comments.Remove(existingComment);  
            await _context.SaveChangesAsync();  
            return existingComment;
        }
    }
}
