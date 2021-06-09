using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _360ImagingTask.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string PostText { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
