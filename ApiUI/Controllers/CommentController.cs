using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace ApiUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService _commentService)
        {
            _commentService = _commentService;
        }

        [HttpGet]
        [Route("GetAllComment")]
        public List<CommentDto> GetAll() => _commentService.GetAll();

        [HttpGet]
        [Route("GetCommentById")]
        public CommentDto GetById(int id) => _commentService.GetById(id);

        [HttpGet]
        [Route("DeleteComment")]
        public bool Delete(int id) => _commentService.Delete(id);

        [HttpPost]
        [Route("AddComment")]
        public CommentDto Add(CommentDto model) => _commentService.Add(model);

        [HttpPost]
        [Route("UpdateComment")]
        public CommentDto Update(CommentDto model) => _commentService.Update(model);
    }
}

