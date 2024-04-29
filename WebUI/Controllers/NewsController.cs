
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class NewsController : Controller
	{
		private readonly INewsApiRequest _newsApiRequest;
		private readonly ICategoryApiRequest _categoryApiRequest;
		private readonly ICommentApiRequest _commentApiRequest;

		public NewsController(INewsApiRequest newsApiRequest, ICategoryApiRequest categoryApiRequest, ICommentApiRequest commentApiRequest)
		{
			_categoryApiRequest = categoryApiRequest;
			_newsApiRequest = newsApiRequest;
			_commentApiRequest = commentApiRequest;
		}
		public IActionResult Index(int id)
		{
			NewsViewModel model = new NewsViewModel();
			if (id == 0)
				model.News = _newsApiRequest.GetAll().OrderByDescending(x => x.NewsDate).ToList();
			else
				model.News = _newsApiRequest.GetAll().Where(x => x.CategoryId == id).OrderByDescending(x => x.NewsDate).ToList();

			model.Category = _categoryApiRequest.GetAll().OrderByDescending(x => x.CategoryId).ToList();

			return View(model);
		}

		public IActionResult Detail(int id)
		{
			if (id == 0)
				RedirectToAction("Index");

			NewsDetailViewModel model = new NewsDetailViewModel();
			model.News = _newsApiRequest.GetById(id);
			model.Comment = _commentApiRequest.GetAll().Where(x => x.NewsId == id && x.CommentStatus).OrderByDescending(x => x.CommentDate).ToList();
			model.Category = _categoryApiRequest.GetAll().OrderByDescending(x => x.CategoryId).ToList();

			if (model.News == null)
				RedirectToAction("Index");

			return View(model);
		}
		public IActionResult AddComment(CommentDto model)
		{
			var result = _commentApiRequest.Add(model);

			return Redirect("/News/Detail/" + result.NewsId);
		}
	}
}
