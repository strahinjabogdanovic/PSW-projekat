using PswProject.dto;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PswProject.repository
{
    public class CommentSqlRepository : CommentRepository
    {
        public MyDbContext dbContext { get; set; }

        public CommentSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CommentSqlRepository()
        {

        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public bool SaveUserFeedback(Comment comment)
        {
            comment.Id = GetAll().Count + 1;
            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();
            return true;
        }
        public List<Comment> GetAll()
        {
            List<Comment> result = new List<Comment>();
            dbContext.Comments.ToList().ForEach(comments => result.Add(comments));

            return result;
        }

        public string GetUserFeedback(int id)
        {
            var query = from st in dbContext.Comments
                        where st.Id == id
                        select st.Content;
            return query.FirstOrDefault();
        }

        public List<CommentDTO> GetAllAproved()
        {
            var a = dbContext.Comments.Where(f => f.canPublish == true);

            List<Comment> list = new List<Comment>();
            list = a.ToList<Comment>();

            List<CommentDTO> result = new List<CommentDTO>();
            foreach (Comment f in list)
            {  
                result.Add(new CommentDTO { Name = f.Name, Date = f.TimeWritten, Content = f.Content, Rating = f.Rating });
            }

            return result;
        }

        public Comment GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Comment newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment editedObject)
        {
            throw new NotImplementedException();
        }
    }
}