using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
         Task<List<Blog>> GetLast3BlogsWithAuthors();
         Task<List<Blog>> GetAllBlogsWithAuthors();
         Task<List<Blog>> GetBlogByAuthorId(int id);
         Task<Blog> GetBlogAuthorByBlogId(int id);
    }
}
