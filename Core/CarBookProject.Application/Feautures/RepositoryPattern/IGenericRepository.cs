using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetCommentsByBlogId(int id);
        Task<int> GetCountCommentByBlog(int id);
    }
}
