using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Repository
{
    public interface ICommentRepository 
    {
        public Task<List<Comment>> GetAllAsync();
        public Task<Comment?> GetByIdAsync(int id);
       Task<Comment> CreateAsync(Comment comment);
        Task<Comment?> UpdateAsync(int id, Comment comment);
        Task<Comment> DeleteAsync(int id);

    }
}
