using System;

namespace PswProject.dto
{
    public class CommentDTO
    {
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public String Content { get; set; }
        public int Rating { get; set; }

        public CommentDTO()
        {

        }
    }
}
