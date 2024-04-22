using Shared.Dtos;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<CommentDto> GetAll();
        CommentDto GetById(int id);
        CommentDto Add(CommentDto model);
        CommentDto Update(CommentDto model);
        bool Delete(int id);
    }
}
