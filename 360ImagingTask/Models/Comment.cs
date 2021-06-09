using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _360ImagingTask.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
