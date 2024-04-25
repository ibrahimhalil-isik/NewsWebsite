using ApiAccess.Abstract;
using Shared.Dtos;
using Shared.Helpers.Abstract;

namespace ApiAccess.Base
{
    public class NewsApiRequest : INewsApiRequest
    {
        private readonly IRequestService _requestService;
        public NewsApiRequest(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public List<NewsDto> GetAll() => _requestService.Get<List<NewsDto>>("News/GetAllNews");
        public NewsDto Add(NewsDto model)
        {
            return _requestService.Post<NewsDto>("News/AddNews", model);
        }
        public NewsDto GetById(int id) => _requestService.Get<NewsDto>("News/GetNewsById?id=" + id);

        public NewsDto Update(NewsDto model)
        {
            return _requestService.Post<NewsDto>("News/UpdateNews", model);
        }

        public bool Delete(int id)
        {
            return _requestService.Get<bool>("News/DeleteNews?id=" + id);
        }
    }
}
