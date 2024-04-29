using AdminUI.Models;
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Dtos;

namespace AdminUI.Controllers
{
	public class NewsController : Controller
	{
		private readonly INewsApiRequest _newsApiRequest;
		private readonly ICommonApiRequest _commonApiRequest;
		private readonly IWriterApiRequest _writerApiRequest;
		private readonly ICategoryApiRequest _categoryApiRequest;
		public NewsController(INewsApiRequest newsApiRequest, ICommonApiRequest commonApiRequest, IWriterApiRequest writerApiRequest, ICategoryApiRequest categoryApiRequest)
		{
			_newsApiRequest = newsApiRequest;
			_commonApiRequest = commonApiRequest;
			_writerApiRequest = writerApiRequest;
			_categoryApiRequest = categoryApiRequest;
		}
		public IActionResult Index()
		{
			var news = _newsApiRequest.GetAll();
			return View(news);
		}

		public IActionResult Add()
		{
			var writer = _writerApiRequest.GetAll().Select(x => new SelectListItem { Text = x.Name + " " + x.SurName, Value = x.WriterId.ToString() }).ToList();
			var category = _categoryApiRequest.GetAll().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
			NewsViewModel model = new NewsViewModel();
			model.Writer = writer;
			model.Category = category;
			return View(model);
		}

		[HttpPost]
		public IActionResult AddNews(NewsViewModel model)
		{
			string imageUrl = model.Image;
			if (model.ImageFile != null)
			{
				imageUrl = _commonApiRequest.Upload(model.ImageFile);
			}
			string videoUrl = model.Video;
			if (model.VideoFile != null)
			{
				videoUrl = _commonApiRequest.Upload(model.VideoFile);
			}

			NewsDto news = new NewsDto()
			{
				WriterId = model.WriterId,
				ClicksNumber = model.ClicksNumber,
				Image = imageUrl,
				Video = videoUrl,
				NewsStatus = model.NewsStatus,
				Title = model.Title,
				CategoryId = model.CategoryId,
				Contents = model.Contents,
			};
			var result = _newsApiRequest.Add(news);
			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var writer = _writerApiRequest.GetAll().Select(x => new SelectListItem { Text = x.Name + " " + x.SurName, Value = x.WriterId.ToString() }).ToList();
			var category = _categoryApiRequest.GetAll().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
			var model = _newsApiRequest.GetById(id);

			NewsViewModel news = new NewsViewModel()
			{
				NewsId = model.NewsId,
				NewsDate = model.NewsDate,
				WriterId = model.WriterId,
				ClicksNumber = model.ClicksNumber,
				Image = model.Image,
				NewsStatus = model.NewsStatus,
				Title = model.Title,
				CategoryId = model.CategoryId,
				Contents = model.Contents,
				Video = model.Video,
				Writer = writer,
				Category = category,
			};
			return View(news);
		}

		[HttpPost]
		public IActionResult UpdateNews(NewsViewModel model)
		{
			string imageUrl = model.Image;
			if (model.ImageFile != null)
			{
				imageUrl = _commonApiRequest.Upload(model.ImageFile);
			}
			string videoUrl = model.Video;
			if (model.VideoFile != null)
			{
				videoUrl = _commonApiRequest.Upload(model.VideoFile);
			}
			NewsDto news = new NewsDto()
			{
				NewsId = model.NewsId,
				WriterId = model.WriterId,
				ClicksNumber = model.ClicksNumber,
				Image = imageUrl,
				Video = videoUrl,
				NewsStatus = model.NewsStatus,
				Title = model.Title,
				CategoryId = model.CategoryId,
				Contents = model.Contents,
			};
			_newsApiRequest.Update(news);
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			_newsApiRequest.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
