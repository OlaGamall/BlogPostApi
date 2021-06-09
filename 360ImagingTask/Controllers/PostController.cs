using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _360ImagingTask.Models;
using _360ImagingTask.Services;
using AutoMapper;
using _360ImagingTask.Dtos;

namespace _360ImagingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        readonly IBlogRepo _repo;
        readonly IMapper _mapper;

        public PostController(IBlogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {

            return Ok(_repo.GetPosts());
        } 

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _repo.GetPostById(id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(PostDto postView)
        {
            var mappedPost = _mapper.Map<Post>(postView);

            _repo.Add(mappedPost);
            await _repo.SaveChanges();

            return Ok(postView);
        }

        [HttpPut("{user_id}")]
        public async Task<IActionResult> UpdatePost(int post_id, PostDto post_view)
        {
            Post p = _repo.GetPostById(post_id);

            if (p == null)
                return BadRequest();

            //var mappedPost = _mapper.Map<Post>(post_view);
            p.PostText = post_view.PostText;
            p.CreatorId = post_view.CreatorId;
            _repo.Update(p);

            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Post p = _repo.GetPostById(id);

            if (p == null)
                return NotFound();

            _repo.Delete(p);

            await _repo.SaveChanges();

            return NoContent();
        }


    }
}
