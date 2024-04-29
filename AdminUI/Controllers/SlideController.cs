using AdminUI.Models;
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Dtos;

namespace AdminUI.Controllers
{
	public class SlideController : Controller
	{
		private readonly ISlideApiRequest _slideApiRequest;
		private readonly ICommonApiRequest _commonApiRequest;
		private readonly INewsApiRequest _newsApiRequest;
		public SlideController(ISlideApiRequest slideApiRequest, ICommonApiRequest commonApiRequest, INewsApiRequest newsApiRequest)
		{
			_slideApiRequest = slideApiRequest;
			_commonApiRequest = commonApiRequest;
			_newsApiRequest = newsApiRequest;
		}

		public IActionResult Index() => View(_slideApiRequest.GetAll());

		public IActionResult Add()
		{
			var news = _newsApiRequest.GetAll().Select(x => new SelectListItem { Text = x.Title, Value = x.NewsId.ToString() }).ToList();
			SlideViewModel model = new SlideViewModel();
			model.News = news;
			return View(model);
		}

		[HttpPost]
		public IActionResult AddSlide(SlideViewModel model)
		{
			var imageUrl = _commonApiRequest.Upload(model.ImageFile);

			SlideDto slide = new SlideDto()
			{
				Title = model.Title,
				Content = model.Content,
				NewsId = model.NewsId,
				SlideStatus = model.SlideStatus,
				Image = imageUrl
			};
			var result = _slideApiRequest.Add(slide);

			return RedirectToAction("Index", "Slide");
		}

		public IActionResult Update(int id)
		{
			var news = _newsApiRequest.GetAll().Select(x => new SelectListItem { Text = x.Title, Value = x.NewsId.ToString() }).ToList();
			var model = _slideApiRequest.GetById(id);

			SlideViewModel slide = new SlideViewModel()
			{
				SlideId = model.SlideId,
				Title = model.Title,
				Content = model.Content,
				NewsId = model.NewsId,
				Image = model.Image,
				SlideStatus = model.SlideStatus,
				News = news
			};
			return View(slide);
		}

		[HttpPost]
		public IActionResult UpdateSlide(SlideViewModel model)
		{
			string imageUrl = model.Image;
			if (model.ImageFile != null)
			{
				imageUrl = _commonApiRequest.Upload(model.ImageFile);
			}

			SlideDto slide = new SlideDto()
			{
				SlideId = model.SlideId,
				Title = model.Title,
				Content = model.Content,
				NewsId = model.NewsId,
				Image = imageUrl,
				SlideStatus = model.SlideStatus,
			};
			_slideApiRequest.Update(slide);
			return RedirectToAction("Index", "Slide");
		}

		public IActionResult Delete(int id)
		{
			_slideApiRequest.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
