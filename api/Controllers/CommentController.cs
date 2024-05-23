using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
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
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var comments = await _commentRepo.GetAllAsync();
            var commentsModel = comments.Select(comment => comment.ToDto());
            return Ok(commentsModel);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null) return NotFound();
            return Ok(comment.ToDto());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto model){
            if(!await _stockRepo.CheckStockExistance(stockId)) return BadRequest("Stock not found!");
            var comment = await _commentRepo.CreateAsync(model.ToEntityFromCreate(stockId));
            return CreatedAtAction(nameof(GetById), new {id = comment.Id}, comment.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto model){
            // if(!await _stockRepo.CheckStockExistance(stockId)) return BadRequest("Stock not found!");
            var comment = await _commentRepo.UpdateAsync(id, model.ToEntityFromUpdate());
            if(comment == null) return NotFound("Comment not found!");
            return Ok(comment.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var comment = await _commentRepo.DeleteAsync(id);
            if(comment == null) return NotFound("Comment not found!");
            return Ok(comment.ToDto());
        }
    }
}