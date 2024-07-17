using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities.Concrete;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;
        private readonly IMapper _mapper;

        public CommentsController(CommentContext commentContext, IMapper mapper)
        {
            _commentContext = commentContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "CommentReadPermission")]
        public async Task<IActionResult> GetAll([FromQuery] bool status = true)
        {
            var comments = await _commentContext.UserComments.Where(x => x.Status == status).ToListAsync();
            return Ok(_mapper.Map<List<ResultUserCommentDto>>(comments));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CommentReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var comment = await _commentContext.UserComments.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(_mapper.Map<ResultUserCommentDto>(comment));
        }

        [HttpGet("countByStatus")]
        [Authorize(Policy = "CommentReadPermission")]
        public async Task<IActionResult> GetCommentCountByStatus([FromQuery] bool status)
        {
            var count = await _commentContext.UserComments.CountAsync(x => x.Status == status);
            return Ok(count);
        }

        [HttpGet("countTotal")]
        [Authorize(Policy = "CommentReadPermission")]
        public async Task<IActionResult> GetTotalCountOfComment()
        {
            var count = await _commentContext.UserComments.CountAsync();
            return Ok(count);
        }

        [HttpGet("product/{productId}")]
        [Authorize(Policy = "CommentReadPermission")]
        public async Task<IActionResult> GetByProductId(string productId, [FromQuery] bool status = true)
        {
            var comments = await _commentContext.UserComments.Where(x => x.ProductId == productId && x.Status == status).ToListAsync();
            return Ok(_mapper.Map<List<ResultUserCommentDto>>(comments));
        }

        [HttpPost]
        [Authorize(Policy = "CommentFullPermission")]
        public async Task<IActionResult> Create(CreateUserCommentDto dto)
        {
            var comment = _mapper.Map<UserComment>(dto);
            _commentContext.Entry(comment).State = EntityState.Added;
            await _commentContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CommentFullPermission")]
        public async Task<IActionResult> Update(ResultUserCommentDto dto)
        {
            var comment = _mapper.Map<UserComment>(dto);
            _commentContext.Entry(comment).State = EntityState.Modified;
            await _commentContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CommentFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            var comment = await _commentContext.UserComments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment is null)
                return NotFound();
            _commentContext.Entry(comment).State = EntityState.Deleted;
            await _commentContext.SaveChangesAsync();
            return Ok();
        }
    }
}
