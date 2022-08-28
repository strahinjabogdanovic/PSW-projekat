using Microsoft.AspNetCore.Mvc;
using PswProject.dto;
using PswProject.model;
using PswProject.repository;
using PswProject.service;
using System;
using System.Collections.Generic;

namespace PswProject.controller
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public CommentSqlRepository repoComment = new CommentSqlRepository();
        public CommentService commentService = new CommentService();

        public CommentController(MyDbContext db)
        {
            this.dbContext = db;
            commentService = new CommentService(new CommentSqlRepository(dbContext));

        }


        [HttpPost("/comments")]
        public IActionResult Post(CommentDTO comment)
        {
            Console.WriteLine("Ovde");
            Comment feedback = GenerateUserFeedbackFromDTO(comment);
            commentService.SaveUserFeedback(feedback); 
            return Ok();
        }


        [HttpGet("/comments")]
        public IActionResult Get()
        {
            repoComment.dbContext = dbContext;
            List<Comment> result = new List<Comment>();
            result = repoComment.GetAll();
            return Ok(result);
        }

        [HttpGet("/commentAp")]
        public IActionResult GetAp()
        {
            repoComment.dbContext = dbContext;
            List<CommentDTO> result = new List<CommentDTO>();
            result = repoComment.GetAllAproved();
            return Ok(result);
        }



        private Comment GenerateUserFeedbackFromDTO(CommentDTO comDTO)
        {
            Comment comment = new Comment(comDTO.Date, comDTO.Content, comDTO.Name, comDTO.CanPublish, comDTO.Rating);

            return comment;
        }
    }
}
