using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _360ImagingTask.Services;
using _360ImagingTask.Models;
using AutoMapper;
using _360ImagingTask.Dtos;

namespace _360ImagingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        readonly IBlogRepo _repo;
        readonly IMapper _mapper;

        public CommentController(IBlogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("post/{post_id}")]
        public IActionResult GetComments(int post_id)
        {
            var result = _repo.GetCommentsOfPost(post_id);

            if (_repo.GetPostById(post_id) == null)
                return BadRequest();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _repo.GetCommentById(id);

            if (comment == null)
                return NotFound();


            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDto c)
        {
            var user = _repo.GetUserById(c.UserId);

            if (user == null)
                return BadRequest();

            var mappedComment = _mapper.Map<Comment>(c); //map view to the original model
            _repo.Add(mappedComment);
            await _repo.SaveChanges();


            return Ok(c);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentDto c)
        {
            var comment = _repo.GetCommentById(id);

            if (comment == null)
                return BadRequest();

            comment.CommentText = c.CommentText;
            comment.UserId = c.UserId; //may prevent updating user_id and post_id
            comment.PostId = c.PostId;

            _repo.Update(comment);
            await _repo.SaveChanges();


            return Ok(c);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = _repo.GetCommentById(id);

            if (comment == null)
                return NotFound();

            _repo.Delete(comment);
            await _repo.SaveChanges();


            return NoContent();
        }

    }
}
