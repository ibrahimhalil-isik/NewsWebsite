using ApiAccess.Abstract;
using Shared.Dtos;
using Shared.Helpers.Abstract;

namespace ApiAccess.Base
{
    public class SlideApiRequest : ISlideApiRequest
    {
        private readonly IRequestService _requestService;
        public SlideApiRequest(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public List<SlideDto> GetAll()
            => _requestService.Get<List<SlideDto>>("Slide/GetAllSlide");

        public SlideDto GetById(int id)
            => _requestService.Get<SlideDto>("Slide/GetSlideById?id=" + id);

        public SlideDto Add(SlideDto model)
            => _requestService.Post<SlideDto>("Slide/AddSlide", model);

        public SlideDto Update(SlideDto model)
            => _requestService.Post<SlideDto>("Slide/UpdateSlide", model);

        public bool Delete(int id)
            => _requestService.Get<bool>("Slide/DeleteSlide?id=" + id);
    }
}
