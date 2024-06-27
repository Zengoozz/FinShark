#region CreateCommentUser
// Get User ☑
// Add AppUserId ☑
// Head to the repository and add include for getAll and get to include the appUser ☑
// Head to the stock repo and add thenInclude for getAll and get to include the appUser ☑
// Head to the commentDto and add the CreatedBy Attribute ☑
// Head to the CommentMapper and add the createdBy ☑
#endregion

using api.Dtos.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository, UserManager<AppUser> userManager)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepository;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var comments = await _commentRepo.GetAllAsync();

            var commentsModel = comments.Select(comment => comment.ToDto());

            return Ok(commentsModel);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment.ToDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _stockRepo.CheckStockExistanceAsync(stockId))
                return BadRequest("Stock not found!");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            var commentModel = model.ToEntityFromCreate(stockId);
            commentModel.AppUserId = appUser.Id;

            await _commentRepo.CreateAsync(commentModel);
            
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, model.ToEntityFromUpdate());

            if (comment == null)
                return NotFound("Comment not found!");

            return Ok(comment.ToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.DeleteAsync(id);

            if (comment == null)
                return NotFound("Comment not found!");

            return Ok(comment.ToDto());
        }
    }
}