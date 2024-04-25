using Shared.Dtos;

namespace ApiAccess.Abstract
{
    public interface ICommentApiRequest
    {
        List<CommentDto> GetAll();
        CommentDto GetById(int id);
        CommentDto Add(CommentDto model);
        CommentDto Update(CommentDto model);
        bool Delete(int id);
    }
}
