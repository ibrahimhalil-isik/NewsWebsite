using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace ApiUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [Route("GetAllNews")]
        public List<NewsDto> GetAll() => _newsService.GetAll();

        [HttpGet]
        [Route("GetNewsById")]
        public NewsDto GetById(int id) => _newsService.GetById(id);

        [HttpGet]
        [Route("DeleteNews")]
        public bool Delete(int id) => _newsService.Delete(id);

        [HttpPost]
        [Route("AddNews")]
        public NewsDto Add(NewsDto model) => _newsService.Add(model);

        [HttpPost]
        [Route("UpdateNews")]
        public NewsDto Update(NewsDto model) => _newsService.Update(model);
    }
}
