using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _360ImagingTask.Dtos
{
    public class CommentDto
    {
        //public int Id { get; set; }

        public string CommentText { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
