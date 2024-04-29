using AdminUI.Models;
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace AdminUI.Controllers
{
	public class CommentController : Controller
    {
        private readonly ICommentApiRequest _commentApiRequest;
        public CommentController(ICommentApiRequest commentApiRequest)
        {
            _commentApiRequest = commentApiRequest;
        }
        public IActionResult Index()
        {
            List<CommentDto> pageData = _commentApiRequest.GetAll();

            return View(pageData);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel model)
        {
            CommentDto comment = new CommentDto()
            {
                CommentText = model.CommentText,
                CommentTitle = model.CommentTitle,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                NewsId = model.NewsId,
                CommentStatus = model.CommentStatus,
            };
            var result = _commentApiRequest.Add(comment);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var data = _commentApiRequest.GetById(id);

            CommentViewModel comment = new CommentViewModel()
            {
                CommentId = data.CommentId,
                CommentText = data.CommentText,
                CommentTitle = data.CommentTitle,
                Name = data.Name,
                Surname = data.Surname,
                Email = data.Email,
                NewsId = data.NewsId,
                CommentStatus = data.CommentStatus,
            };
            return View(comment);
        }

        [HttpPost]
        public IActionResult UpdateComment(CommentViewModel model)
        {
            CommentDto comment = new CommentDto()
            {
                CommentId = model.CommentId,
                CommentText = model.CommentText,
                CommentTitle = model.CommentTitle,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                NewsId = model.NewsId,
                CommentStatus = model.CommentStatus,
            };
            _commentApiRequest.Update(comment);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _commentApiRequest.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
