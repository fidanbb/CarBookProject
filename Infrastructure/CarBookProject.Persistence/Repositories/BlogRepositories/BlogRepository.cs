using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var values =await _carBookContext.Blogs.Include(x => x.Author)
                                                   .Include(y=>y.Category)
                                                   .Include(z=>z.Comments)
                                                   .ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogAuthorByBlogId(int id)
        {
            var value = await _carBookContext.Blogs.Include(x => x.Author)
                                              .Where(y => y.BlogID == id)
                                              .FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<Blog>> GetBlogByAuthorId(int id)
        {
            var values =await _carBookContext.Blogs.Include(x => x.Author).Where(y => y.AuthorID == id).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            var values =await _carBookContext.Blogs.Include(x => x.Author)
                                                   .Include(z => z.Comments)
                                                   .OrderByDescending(x => x.BlogID)
                                                   .Take(3)
                                                   .ToListAsync();
            return values;
        }
    }
}
