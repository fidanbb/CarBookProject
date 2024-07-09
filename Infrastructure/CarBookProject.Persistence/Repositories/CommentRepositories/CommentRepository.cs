using CarBookProject.Application.Feautures.RepositoryPattern;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task Create(Comment entity)
        {
          await _context.Comments.AddAsync(entity);
          await  _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentsByBlogId(int id)
        {
           return await _context.Set<Comment>().Where(y=>y.BlogID==id).ToListAsync();
        }

        public async Task<int> GetCountCommentByBlog(int id)
        {
         return  await   _context.Comments.Where(x=>x.BlogID==id).CountAsync();
        }

        public async Task Remove(Comment entity)
        {
            var value = await _context.Comments.FindAsync(entity.CommentID);
           _context.Comments.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Comment entity)
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
