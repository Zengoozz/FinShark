using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dataset.ToListAsync();
        }
    }
}