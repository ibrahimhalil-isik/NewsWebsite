using ApiAccess.Abstract;
using Shared.Dtos;
using Shared.Helpers.Abstract;

namespace ApiAccess.Base
{
    public class CommentApiRequest : ICommentApiRequest
    {
        private readonly IRequestService _requestService;
        public CommentApiRequest(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public List<CommentDto> GetAll()
            => _requestService.Get<List<CommentDto>>("Comment/GetAllComment");

        public CommentDto GetById(int id)
            => _requestService.Get<CommentDto>("Comment/GetCommentById" + id);

        public CommentDto Add(CommentDto model)
            => _requestService.Post<CommentDto>("Comment/AddComment", model);

        public CommentDto Update(CommentDto model)
            => _requestService.Post<CommentDto>("Comment/UpdateComment", model);

        public bool Delete(int id)
            => _requestService.Get<bool>("Comment/DeleteComment/?id=" + id);
    }
}
