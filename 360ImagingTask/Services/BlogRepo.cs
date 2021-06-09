using _360ImagingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _360ImagingTask.Services
{
    public class BlogRepo : IBlogRepo
    {
        private readonly BlogDBContext _Context;

        public BlogRepo(BlogDBContext context)
        {
            _Context = context;
        }

        //
        public void Add<T>(T entity) where T : class
        {
            _Context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _Context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _Context.Remove(entity);
        }

        public Comment GetCommentById(int id)
        {
            return _Context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetCommentsOfPost(int post_id)
        {
            return _Context.Comments.Where(c => c.PostId == post_id).ToList();
        }

        public Post GetPostById(int id)
        {
            return _Context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetPosts()
        {
            return _Context.Posts.ToList();
        }

        public List<User> GetUsers()
        {
            return _Context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _Context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _Context.SaveChangesAsync()>0;
        }

    }
}
