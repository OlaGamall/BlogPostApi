using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _360ImagingTask.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
