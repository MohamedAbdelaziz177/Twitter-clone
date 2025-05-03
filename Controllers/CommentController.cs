using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.DTOs.CommentDtos;
using Twitter.Model;
using Twitter.Services.CommentService_dir;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : BasePlusUserController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }


        [HttpGet("get-by-id/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        { 
            CommentDto comment = await commentService.GetCommentById(id);

            return Ok(comment);
        }

        [HttpGet("get-by-postId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByPostId([FromQuery] int postId)
        {
            List<CommentDto> comments = await commentService.GetCommentsByPostId(postId);

            return Ok(comments);
        }

        [HttpGet("get-by-userId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            List<CommentDto> comments = await commentService.GetCommentsByUserId(userId);

            return Ok(comments);
        }


        [HttpPost("add")]

        public async Task<IActionResult> AddComment(int postId, CreateUpdateCommentDto comment)
        {
            if(ModelState.IsValid)
                return BadRequest(ModelState);

            CommentDto commDto = await commentService.AddNewComment(postId, userId, comment);

            return CreatedAtAction("GetById", new
            {
                id = commDto.Id,
                commDto
            });
        }

        [HttpPost("update/{id:int}")]
        public async Task<IActionResult> EditComment([FromRoute] int id, CreateUpdateCommentDto comment) 
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            CommentDto commDto = await commentService.UpdateComment(id, comment, userId);

            return Ok(commDto);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await commentService.DeleteComment(id, userId);

            return NoContent();
        }
    }
}
