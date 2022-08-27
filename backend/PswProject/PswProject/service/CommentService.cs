using PswProject.model;
using PswProject.repository;
using System;

namespace PswProject.service
{
    public class CommentService
    {
        private CommentRepository CommentRepository { get; set; }
        private CommentSqlRepository commentSqlRepositorys { get; set; }
        public CommentService()
        {
            CommentRepository = new CommentSqlRepository();
        }
        public CommentService(CommentSqlRepository commentSqlRepository)
        {
            CommentRepository = commentSqlRepository;
            commentSqlRepositorys = commentSqlRepository;
        }
        public Boolean SaveUserFeedback(Comment comment)
        {
            return commentSqlRepositorys.SaveUserFeedback(comment);
        }
    }
}
