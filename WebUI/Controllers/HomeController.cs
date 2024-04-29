using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISlideApiRequest _slideApiRequest;
		private readonly INewsApiRequest _newsApiRequest;
		public HomeController(ISlideApiRequest slideApiRequest, INewsApiRequest newsApiRequest)
		{
			_slideApiRequest = slideApiRequest;
			_newsApiRequest = newsApiRequest;
		}
		public IActionResult Index()
		{
			List<SlideDto> slide = _slideApiRequest.GetAll().OrderByDescending(x => x.SlideId).ToList();
			var news = _newsApiRequest.GetAll().OrderByDescending(x => x.NewsId).ToList();

			HomeViewModel model = new HomeViewModel();
			model.Slide = slide;
			model.News = news;

			return View(model);
		}
	}
}
