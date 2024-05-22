using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepo = commentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var comments = await _commentRepo.GetAllAsync();
            var commentsModel = comments.Select(comment => comment.ToDto());
            return Ok(commentsModel);
        }
    }
}