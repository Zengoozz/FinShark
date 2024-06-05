using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        protected DbSet<Comment> _dataset;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
            _dataset = context.Comments;
        }

        public async Task<Comment> CreateAsync(Comment entity)
        {
            try
            {
                await _dataset.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var entity = await _dataset.FindAsync(id);

            if(entity == null) return entity;

            _dataset.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _dataset.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment entity)
        {
            var existEntity = await _dataset.FindAsync(id);

            if (existEntity == null) return existEntity;
            
            try
            {
                existEntity.Title = entity.Title;
                existEntity.Content = entity.Content;

                await _context.SaveChangesAsync();

                return existEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}