using Downtown.Core.Models;
using Downtown.Data.Repositories;
using Downtown.Rest.DataContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Downtown.Rest.Controllers
{
    [ApiController]
    [Route("comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int eventId)
        {
            var events = await this.commentRepository.GetByEventId(eventId).ConfigureAwait(false);

            return this.Ok(events);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CommentCreateModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var model = new Comment();
            model.EventId = input.EventId;
            model.Content = input.Content;
            model.UserName = HttpContext.User.FindFirst("name")?.Value;
            model.Date = DateTime.UtcNow;

            var result = await this.commentRepository.SaveAsync(model).ConfigureAwait(false);

            return this.Ok(result);
        }
    }
}
