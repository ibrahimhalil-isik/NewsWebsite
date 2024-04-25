using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace ApiUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService _slideService;
        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet]
        [Route("GetAllSlide")]
        public List<SlideDto> GetAll() => _slideService.GetAll();

        [HttpGet]
        [Route("GetSlideById")]
        public SlideDto GetById(int id) => _slideService.GetById(id);

        [HttpGet]
        [Route("DeleteSlide")]
        public bool Delete(int id) => _slideService.Delete(id);

        [HttpPost]
        [Route("AddSlide")]
        public SlideDto Add(SlideDto model) => _slideService.Add(model);

        [HttpPost]
        [Route("UpdateSlide")]
        public SlideDto Update(SlideDto model) => _slideService.Update(model);
    }
}
