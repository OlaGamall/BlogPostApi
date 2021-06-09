using _360ImagingTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _360ImagingTask.Services
{
    public interface IBlogRepo
    {
        //generic methods
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T:class;

        void Delete<T>(T entity) where T : class;
        //

        List<Post> GetPosts();
        List<Comment> GetCommentsOfPost(int post_id);
        List<User> GetUsers();

        Post GetPostById(int id);
        Comment GetCommentById(int id);
        User GetUserById(int id);

        Task<bool> SaveChanges();
    }
}
