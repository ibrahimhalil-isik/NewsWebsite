using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsApiRequest _newsApiRequest;
        public HomeController(INewsApiRequest newsApiRequest)
        {
            _newsApiRequest = newsApiRequest;
        }
        public IActionResult Index()
        {
            var news = _newsApiRequest.GetAll();
            return View(news);
        }
    }
}
