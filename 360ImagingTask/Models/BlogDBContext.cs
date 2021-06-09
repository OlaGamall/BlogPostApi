using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _360ImagingTask.Models
{
    public class BlogDBContext:DbContext
    {

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
